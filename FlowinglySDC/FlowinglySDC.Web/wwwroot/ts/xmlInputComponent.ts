interface DataExtract {
    tagName: string;
    tagData: string;
    isValid: boolean;
}

interface ValidationResult {
    isValid: boolean;
    costCentreDescription: string;
    totalCost: number;
    dataExtract: DataExtract[];
}

class XmlInputComponent {
    private inputArea: HTMLTextAreaElement;
    private highlightLayer: HTMLDivElement;
    private resultArea: HTMLTextAreaElement;
    private submitBtn: HTMLButtonElement;
    private toastNotification: HTMLDivElement;
    private inactivityTimer: number | null = null;
    private readonly inactivityDelay: number = 3000;

    constructor() {
        this.inputArea = document.getElementById("inputArea") as HTMLTextAreaElement;
        this.highlightLayer = document.getElementById("highlightLayer") as HTMLDivElement;
        this.resultArea = document.getElementById("resultArea") as HTMLTextAreaElement;
        this.submitBtn = document.getElementById("submitBtn") as HTMLButtonElement;
        this.toastNotification = document.getElementById("toastNotification") as HTMLDivElement;

        this.bindEvents();
    }

    private bindEvents(): void {
        this.inputArea.addEventListener("input", () => this.onInputChanged());
        this.inputArea.addEventListener("scroll", () => this.syncScroll());
        this.submitBtn.addEventListener("click", () => this.onSubmit());
        this.resultArea.addEventListener("click", () => this.copyToClipboard());
    }

    private syncScroll(): void {
        this.highlightLayer.scrollTop = this.inputArea.scrollTop;
        this.highlightLayer.scrollLeft = this.inputArea.scrollLeft;
    }

    private onInputChanged(): void {
        if (this.inactivityTimer !== null) {
            clearTimeout(this.inactivityTimer);
        }

        this.inactivityTimer = window.setTimeout(() => {
            this.validateMessage();
        }, this.inactivityDelay);
    }

    private async validateMessage(): Promise<void> {
        const message = this.inputArea.value;
        if (!message.trim()) {
            this.highlightLayer.innerHTML = "";
            return;
        }

        try {
            const response = await fetch("/?handler=Validate", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(message)
            });

            if (response.ok) {
                const result: ValidationResult = await response.json();
                this.applyHighlighting(message, result);
            }
        } catch (error) {
            console.error("Validation failed:", error);
        }
    }

    private applyHighlighting(text: string, validationResult: ValidationResult): void {
        const leafTags: { tagName: string; cls: string }[] = [];
        const markerOnlyTags: { tagName: string; cls: string }[] = [];

        if (validationResult.dataExtract) {
            for (const extract of validationResult.dataExtract) {
                const cls = extract.isValid ? "xml-valid" : "xml-invalid";
                if (extract.tagData) {
                    leafTags.push({ tagName: extract.tagName, cls });
                } else {
                    markerOnlyTags.push({ tagName: extract.tagName, cls });
                }
            }
        }

        if (validationResult.isValid) {
            leafTags.push({ tagName: "total", cls: "xml-valid" });
            leafTags.push({ tagName: "cost_centre", cls: "xml-valid" });
        }

        let highlighted = this.escapeHtml(text);

        // Highlight leaf tags fully (opening + content + closing), content must not contain nested tags
        for (const { tagName, cls } of leafTags) {
            const escaped = this.escapeRegex(tagName);
            const regex = new RegExp(
                `(&lt;${escaped}(?:\\s[^&]*?)?&gt;)((?:(?!&lt;[a-zA-Z_/]).)*)(&lt;\\/${escaped}&gt;)`,
                "gs"
            );
            highlighted = highlighted.replace(regex, `<span class="${cls}">$1$2$3</span>`);
        }

        // Highlight wrapper and self-closing tags (only the tag markers, not content)
        for (const { tagName, cls } of markerOnlyTags) {
            const escaped = this.escapeRegex(tagName);
            const openRegex = new RegExp(`(&lt;${escaped}(?:\\s[^&]*?)?&gt;)`, "g");
            highlighted = highlighted.replace(openRegex, (match) => {
                if (match.includes("<span") || match.includes("</span>")) return match;
                return `<span class="${cls}">${match}</span>`;
            });
            const closeRegex = new RegExp(`(&lt;\\/${escaped}&gt;)`, "g");
            highlighted = highlighted.replace(closeRegex, (match) => {
                if (match.includes("<span") || match.includes("</span>")) return match;
                return `<span class="${cls}">${match}</span>`;
            });
            const selfRegex = new RegExp(`(&lt;${escaped}(?:\\s[^&]*?)?/&gt;)`, "g");
            highlighted = highlighted.replace(selfRegex, (match) => {
                if (match.includes("<span") || match.includes("</span>")) return match;
                return `<span class="${cls}">${match}</span>`;
            });
        }

        this.highlightLayer.innerHTML = highlighted;
    }

    private escapeHtml(text: string): string {
        return text
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#039;");
    }

    private escapeRegex(text: string): string {
        return text.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
    }

    private async onSubmit(): Promise<void> {
        const message = this.inputArea.value;
        if (!message.trim()) {
            return;
        }

        this.submitBtn.disabled = true;
        this.submitBtn.textContent = "Processing...";

        try {
            // Step 1: Validate first to highlight text
            const validateResponse = await fetch("/?handler=Validate", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(message)
            });

            if (!validateResponse.ok) {
                this.resultArea.value = "Error: Validation request failed.";
                return;
            }

            const validationResult: ValidationResult = await validateResponse.json();
            this.applyHighlighting(message, validationResult);

            if (!validationResult.isValid) {
                const hasTotalTag = /<total\b[^>]*>[\s\S]*?<\/total>/.test(message);
                const hasInvalidTags = validationResult.dataExtract?.some(e => !e.isValid) ?? false;
                const hasXmlTags = /<[^>]+>/.test(message);
                const hasNoExtractedData = !validationResult.dataExtract || validationResult.dataExtract.length === 0;

                if (hasXmlTags && hasNoExtractedData) {
                    this.resultArea.value = "Error: The message contains invalid XML tags. Please ensure all tags are properly opened and closed.";
                } else if (!hasTotalTag) {
                    this.resultArea.value = "Error: The message is missing the required <total> tag. A <total> tag with a valid value is needed to perform the calculation.";
                } else if (hasInvalidTags) {
                    this.resultArea.value = "Error: The message contains invalid XML tags. Please review the highlighted tags and correct them.";
                } else {
                    this.resultArea.value = "Error: The message failed validation. Please review the content and try again.";
                }
                return;
            }

            // Step 2: Calculate
            const calcResponse = await fetch("/?handler=Calculate", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(message)
            });

            if (calcResponse.ok) {
                const resultText = await calcResponse.text();
                try {
                    const parsed = JSON.parse(resultText);
                    this.resultArea.value = JSON.stringify(parsed, null, 2);
                } catch {
                    this.resultArea.value = resultText;
                }
            } else {
                this.resultArea.value = "Error: " + calcResponse.statusText;
            }
        } catch (error) {
            this.resultArea.value = "Error: Failed to communicate with server.";
            console.error("Submit failed:", error);
        } finally {
            this.submitBtn.disabled = false;
            this.submitBtn.textContent = "Submit";
        }
    }

    private async copyToClipboard(): Promise<void> {
        const text = this.resultArea.value;
        if (!text) return;

        try {
            await navigator.clipboard.writeText(text);
            this.resultArea.classList.add("copied-flash");
            this.showToast();

            setTimeout(() => {
                this.resultArea.classList.remove("copied-flash");
            }, 500);
        } catch (error) {
            console.error("Failed to copy:", error);
        }
    }

    private showToast(): void {
        this.toastNotification.classList.add("show");
        setTimeout(() => {
            this.toastNotification.classList.remove("show");
        }, 2000);
    }
}

document.addEventListener("DOMContentLoaded", () => {
    new XmlInputComponent();
});
