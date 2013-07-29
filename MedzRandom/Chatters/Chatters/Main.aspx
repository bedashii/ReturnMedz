<%@ Page Language="C#" MasterPageFile="~/ChattersMaster.master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Chatters.Main" Title="Home" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
                <asp:ServiceReference Path="~/WebServices/SlideShowWebService.asmx" />
            </Services>
    </asp:ScriptManager>
    <div style="text-align: center">
        <h2>HOME</h2>
    </div>
    <div style="text-align: center">
        <asp:Label runat="server" ID="labelIntoduction" Style="text-align: center" />
    </div>
    <div style="text-align: center">
        <h2>Trading Hours</h2>
        <h4>Monday to Sunday - 00:00 to 23:59</h4>
    </div>
    <div style="text-align: center">
        <asp:Image runat="server" ID="imageHome" Height="400px" Width="600"/>
        <asp:SlideShowExtender ID="SlideShowExtender1" runat="server"
            TargetControlID="imageHome"
            SlideShowServicePath="~/WebServices/SlideShowWebService.asmx"
            SlideShowServiceMethod="GetHomeSlides"
            AutoPlay="true"
            Loop="true" />
        <%--ImageTitleLabelID="imageTitle"--%>
        <%--ImageDescriptionLabelID="imageDescription"--%>
        <%--NextButtonID="nextButton" 
    PlayButtonText="Play" 
    StopButtonText="Stop" 
    PreviousButtonID="prevButton" 
    PlayButtonID="playButton" --%>
    </div>
</asp:Content>
