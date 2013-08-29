<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PlayerControl.ascx.cs" Inherits="PlayerControl" %>
<%@ Reference Control="~/HeroControl.ascx" %>
<%@ Reference Control="~/MatchControl.ascx" %>
<div style=
    "
    float: left; 
    
    border-top: solid 5px;
    border-left: solid 5px;
    border-right: solid 5px;
    border-bottom: solid 5px;

    padding-left: 6px;
    padding-right: 6px;
    ">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="LabelSteamID" runat="server" Text="Steam ID: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxSteamID" Text="00000000"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelSteamNameHeader" runat="server" Text="Name: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LabelSteamName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div runat="server" id="divHeros">
    </div>
    <div runat="server" id="divLastMatches">
    </div>
</div>
