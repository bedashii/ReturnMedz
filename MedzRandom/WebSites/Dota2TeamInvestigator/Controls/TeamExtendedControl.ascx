<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TeamExtendedControl.ascx.cs" Inherits="Controls_TeamExtendedControl" %>

<div>
    <asp:ImageButton runat="server" ID="ImageButtonTeamAvatar" Style="position: absolute; left: 0; top: 0;"
        Width="192px"
        Height="128px" />

    <asp:Label ID="LabelName" runat="server"
        style="position: absolute;top:0;left:200px;"
        />
    <asp:Label ID="LabelGamesPlayed" runat="server"
        style="position: absolute;top:30px;left:200px;"
        />
    <asp:Label ID="LabelWins" runat="server"
        style="position: absolute;top:60px;left:200px;"
        />
    <asp:Label ID="LabelLeaguesHeader" runat="server" Text="Leagues:"
        style="position: absolute;top:0px;left:400px;"
        />
    <asp:Label ID="LabelLeagues" runat="server" Text="Example 1"
        style="position: absolute;top:30px;left:400px;"
        />
    <asp:Label ID="LabelTournamentsHeader" runat="server" Text="Touraments:"
        style="position: absolute;top:60px;left:400px;"
        
        />
    <asp:Label ID="LabelTournaments" runat="server" Text="Example 1"
        style="position: absolute;top:90px;left:400px;"
        />
</div>
