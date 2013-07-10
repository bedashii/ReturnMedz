<%@ Page Language="C#" MasterPageFile="~/ChattersMaster.master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Chatters.Menu" Title="Menu" %>

<%@ Reference Control="~/Controls/menuItem.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="margin-left:35%">
        <asp:Label runat="server" ID="labelHeader" Font-Size="XX-Large" Text="Menu" Font-Bold="True" Font-Names="Goudy Stout" />
    </div>
</asp:Content>
