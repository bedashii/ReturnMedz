<%@ Page Title="About Us" Language="C#" MasterPageFile="~/ChattersMaster.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Chatters.AboutUs" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/WebServices/SlideShowWebService.asmx" />
        </Services>
    </asp:ScriptManager>
    <div style="text-align: center">
        <h2>About Us</h2>
    </div>
    <div style="text-align: center">
        <asp:Label runat="server" ID="labelAboutUs" Style="text-align: center" />
        <br/>
        <br/>
        <asp:Image runat="server" ID="imageAboutUs" Width="600" Height="400" />
                    <asp:SlideShowExtender ID="SlideShowExtender1" runat="server"
                        TargetControlID="imageAboutUs"
                        SlideShowServicePath="~/WebServices/SlideShowWebService.asmx"
                        SlideShowServiceMethod="GetAboutUsSlides"
                        AutoPlay="true"
                        Loop="true" />
    </div>
</asp:Content>
