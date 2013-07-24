<%@ Page Language="C#" MasterPageFile="~/ChattersMaster.master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Chatters.Menu" Title="Menu" %>

<%@ Reference Control="~/Controls/menuItem.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="margin-left: auto;margin-right: auto; width: 80px;">
        <asp:Label runat="server" ID="labelHeader" Font-Size="XX-Large" Text="Menu" Font-Bold="True" Font-Names="Goudy Stout" Width="80px"/>
    </div>
    <div style="margin-left: auto;margin-right: auto; width: 800px;">
    <asp:PlaceHolder runat="server" ID="placeHolderSubMenus"></asp:PlaceHolder>
        </div>
</asp:Content>