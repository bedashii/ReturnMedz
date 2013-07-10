<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="subMenuControl.ascx.cs" Inherits="Chatters.Controls.subMenuControl" %>

<style type="text/css">
    .auto-style3 {
        width: 75%;
        /*margin-top: 100px;*/
        margin-left: 200px;
        margin-right: 200px;
        margin-bottom:10px;
    }
</style>
<table class="auto-style3">
    <tr>
        <td>
            <asp:Panel runat="server" ID="panelTitle" BorderStyle="Solid">
                <div align="center">
                    <asp:Label runat="server" ID="labelSubMenu" Font-Bold="True" Font-Names="Goudy Stout" Font-Size="XX-Large" ForeColor="Black" />
                </div>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel runat="server" ID="menuItemPanel" BorderStyle="Solid" />
        </td>
    </tr>
</table>
