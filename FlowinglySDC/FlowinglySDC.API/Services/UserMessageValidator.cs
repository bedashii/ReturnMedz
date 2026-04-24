using System.Text.RegularExpressions;
using FlowinglySDC.API.Models;

namespace FlowinglySDC.API.Services
{
    public class UserMessageValidator
    {
        public UserMessageValidationResult Validate(string message)
        {
            var result = new UserMessageValidationResult();

            var xmlTagsValid = ValidateXMLTags(message, result);

            if (!xmlTagsValid)
            {
                return result;
            }

            PopulateCostCentreDescription(message, result);
            PopulateDataExtract(message, result);

            var totalTagValid = ValidateTotalTag(message);

            if (!totalTagValid)
            {
                return result;
            }

            result.IsValid = true;

            PopulateTotal(message, result);

            return result;
        }

        private bool ValidateXMLTags(string message, UserMessageValidationResult result)
        {
            // Check that the message contains at least one XML tag
            var tagPattern = new Regex(@"<[^>]+>");
            if (!tagPattern.IsMatch(message))
            {
                return false;
            }

            // Find all opening tags, closing tags, and self-closing tags
            var openingTags = Regex.Matches(message, @"<(?!/)([a-zA-Z_][\w]*)[^>]*/?>")
                .Select(m => new { Match = m, TagName = m.Groups[1].Value, IsSelfClosing = m.Value.EndsWith("/>") })
                .ToList();

            var closingTags = Regex.Matches(message, @"</([a-zA-Z_][\w]*)>")
                .Select(m => m.Groups[1].Value)
                .ToList();

            foreach (var tag in openingTags)
            {
                if (tag.IsSelfClosing)
                {
                    continue;
                }

                if (!closingTags.Contains(tag.TagName))
                {
                    return false;
                }

                closingTags.Remove(tag.TagName);
            }

            // Any remaining closing tags without matching opening tags
            if (closingTags.Count > 0)
            {
                return false;
            }

            return true;
        }

        private bool ValidateTotalTag(string message)
        {
            var totalTagPattern = new Regex(@"<total\b[^>]*>(.*?)</total>", RegexOptions.Singleline);
            return totalTagPattern.IsMatch(message);
        }

        private void PopulateTotal(string message, UserMessageValidationResult result)
        {
            var totalTagPattern = new Regex(@"<total\b[^>]*>(.*?)</total>", RegexOptions.Singleline);
            var match = totalTagPattern.Match(message);

            if (match.Success)
            {
                var totalData = match.Groups[1].Value.Trim();

                if (string.IsNullOrEmpty(totalData) || totalData == "0")
                {
                    result.TotalCost = 0;
                }
                else if (decimal.TryParse(totalData, out var totalValue))
                {
                    result.TotalCost = totalValue;
                }
                else
                {
                    result.IsValid = false;
                    result.TotalCost = 0;
                }
            }
        }

        private void PopulateCostCentreDescription(string message, UserMessageValidationResult result)
        {
            var costCentrePattern = new Regex(@"<cost_centre\b[^>]*>(.*?)</cost_centre>", RegexOptions.Singleline);
            var match = costCentrePattern.Match(message);

            if (match.Success)
            {
                result.CostCentreDescription = match.Groups[1].Value.Trim();
            }
        }

        private void PopulateDataExtract(string message, UserMessageValidationResult result)
        {
            // Match self-closing tags
            var selfClosingPattern = new Regex(@"<([a-zA-Z_][\w]*)\b[^>]*/>");
            // Match leaf tags (content contains no child tags)
            var leafPattern = new Regex(@"<([a-zA-Z_][\w]*)\b[^>]*>([^<]*)</\1>", RegexOptions.Singleline);
            // Match wrapper tags (content starts with a child tag)
            var wrapperPattern = new Regex(@"<([a-zA-Z_][\w]*)\b[^>]*>\s*<[a-zA-Z_][\s\S]*?</\1>", RegexOptions.Singleline);

            foreach (Match match in selfClosingPattern.Matches(message))
            {
                var tagName = match.Groups[1].Value;
                if (IsExcludedTag(tagName)) continue;

                result.DataExtract.Add(new DataExtract
                {
                    TagName = tagName,
                    TagData = string.Empty,
                    IsValid = true
                });
            }

            foreach (Match match in leafPattern.Matches(message))
            {
                var tagName = match.Groups[1].Value;
                if (IsExcludedTag(tagName)) continue;

                result.DataExtract.Add(new DataExtract
                {
                    TagName = tagName,
                    TagData = match.Groups[2].Value.Trim(),
                    IsValid = true
                });
            }

            foreach (Match match in wrapperPattern.Matches(message))
            {
                var tagName = match.Groups[1].Value;
                if (IsExcludedTag(tagName)) continue;

                result.DataExtract.Add(new DataExtract
                {
                    TagName = tagName,
                    TagData = string.Empty,
                    IsValid = true
                });
            }
        }

        private static bool IsExcludedTag(string tagName)
        {
            return string.Equals(tagName, "cost_centre", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(tagName, "total", StringComparison.OrdinalIgnoreCase);
        }
    }
}
