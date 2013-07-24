<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="subMenuControl.ascx.cs" Inherits="Chatters.Controls.subMenuControl" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<style type="text/css">
    .styleSubMenuTable {
        width: 800px;
        margin-left: 0;
        margin-right: auto;
        margin-bottom: 10px;
    }
</style>
<div>


    <table class="styleSubMenuTable">
        <tr>
            <td>
                <asp:Panel runat="server" ID="panelTitle" BorderStyle="Dashed">
                    <div align="center">
                        <asp:Label runat="server" ID="labelSubMenu" Font-Bold="True" Font-Names="Goudy Stout" Font-Size="XX-Large" ForeColor="Black" />
                    </div>

                </asp:Panel>
                <asp:CollapsiblePanelExtender
                    ID="CollapsiblePanelExtenderItemLinksPanel"
                    runat="server"
                    CollapseControlID="panelTitle"
                    CollapsedText="Show details..."
                    ExpandControlID="panelTitle"
                    Collapsed="True"
                    ExpandedText="Hide details..."
                    SuppressPostBack="True"
                    TargetControlID="menuItemPanel">
                </asp:CollapsiblePanelExtender>
            </td>
        </tr>
        <tr>
            <td>
                <div>
                    <asp:Panel runat="server" ID="menuItemPanel" BorderStyle="None">
                        <div style="text-align: center">
                            <asp:Label runat="server" ID="labelDescription"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
            </td>
        </tr>
    </table>
</div>
