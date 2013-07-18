<%@ Page Language="C#" MasterPageFile="~/ChattersMaster.master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Chatters.Main" Title="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="text-align: center">
        <h1>HOME</h1>
    </div>
    <div style="text-align: center">
        <asp:Label runat="server" ID="labelIntoduction" Style="text-align: center" />
    </div>
    <div style="text-align: center">
        <h2>Trading Hours</h2>
        <h4>Monday to Sunday - 00:00 to 23:59</h4>
    </div>
    <div style="text-align: center">
        <asp:Image runat="server" ID="imageHome" />
    </div>
</asp:Content>
