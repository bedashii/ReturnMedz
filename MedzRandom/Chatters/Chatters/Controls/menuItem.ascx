<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menuItem.ascx.cs" Inherits="Chatters.Controls.menuItem" %>

<style type="text/css">
    .auto-style1 {
        width: 50%;
        margin-top:1em;
	margin-left: 16em;
	margin-right: 2em;
    }
</style>

<table id="table" class="auto-style1" border="1">
    <tr>
        <td id="titleColumn" style="width:80%">
            <asp:Label runat="server" ID="labelTitle">Title</asp:Label>
        </td>
        <td id="priceColumn" style="width:20%">
            <asp:Label runat="server" ID="labelPrice">Price</asp:Label>
        </td>
    </tr>
    <tr>
        <td id="descriptionColumn" style="width:60%">
            <asp:Label runat="server" ID="labelDescription">Description</asp:Label>
        </td>
        <td id="pictureColumn" style="width:40%"></td>
    </tr>
</table>