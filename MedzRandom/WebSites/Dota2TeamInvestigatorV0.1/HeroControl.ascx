<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeroControl.ascx.cs" Inherits="HeroControl" %>
<div>
    <table>
        <tr>
            <td>
                <asp:ImageButton ID="ImageButtonHero" runat="server" />
            </td>
            <td>
                <asp:Label ID="LabelMatchesPlayedHeader" runat="server" Text="Played: "></asp:Label>
                <asp:Label ID="LabelMatchesPlayed" runat="server" Text="0"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LabelMatchesWonHeader" runat="server" Text="Wins: "></asp:Label>
                <asp:Label ID="LabelMatchesWon" runat="server" Text="0%"></asp:Label>
            </td>
        </tr>
    </table>
</div>
