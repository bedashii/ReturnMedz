<%@ Page Title="About Us" Language="C#" MasterPageFile="~/ChattersMaster.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Chatters.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center">
        <h2>About Us</h2>
    </div>
    <div style="text-align: center">
        <table style="margin-left:20%" width="50%">
            <tr>
                <td width="20%">
                    <asp:Image runat="server" ID="imageAboutUs" />
                </td>
                <td width="80%">
                    <asp:Label runat="server" ID="labelAboutUs" Style="text-align: center" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
