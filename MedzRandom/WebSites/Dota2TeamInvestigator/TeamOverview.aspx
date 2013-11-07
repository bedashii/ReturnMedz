<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TeamOverview.aspx.cs" Inherits="TeamOverview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="position: relative">
        <div style="position: absolute;left: 48%">
            <h2>Team</h2>
        </div>
        <div id="TeamControlExtended" style="width: 90%; left: 5%; right: 5%">
            <dotauc:teamextendedcontrol runat="server" ID="TeamExtendedControl" style="position: absolute;width: 100%;height: 100%;" />
        </div>


        <div style="position: absolute;left: 45%; width: 10%">
            <h2>Top Team Games</h2>
        </div>
        <div style="position: absolute;left: 10%;width: 80%; right: 10%">
            <h3>derp</h3>
            <h3>derp</h3>
            <h3>derp</h3>
            <h3>derp</h3>
        </div>
    </div>
</asp:Content>

