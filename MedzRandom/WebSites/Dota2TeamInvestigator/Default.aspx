<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Reference Control="~/PlayerControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br/>
        <asp:Panel runat="server" ID="PanelTeamSearch">
            <asp:Label runat="server" ID="LabelTeamSearch" Text="Team Name" />
            <asp:TextBox runat="server" ID="TextBoxTeamName" />
            <asp:Button runat="server" ID="ButtonTeamSearch" Width="60px" Text="Search" OnClick="ButtonTeamSearch_Click" />
        </asp:Panel>
        <br/>
        <asp:Panel runat="server" ID="PanelPlayers" />
    </form>
</body>
</html>
