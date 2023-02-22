﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TeamControl.ascx.cs" Inherits="Controls_TeamControl" %>

<div>
    <div style="position: relative; width: 350px; min-height: 128px; text-align: left; border: solid 1px Black; background-color: #EEEEEE;">
        <asp:ImageButton
            runat="server"
            ID="ImageButtonAvatar"
            Style="position: absolute; top: 0; left: 0;"
            Width="192px"
            Height="128px" OnClick="ImageButtonAvatar_Click" />
        <asp:Label
            runat="server"
            ID="LabelTeamName"
            Style="position: absolute; top: 0.5em; left: 193px; width: 156px; text-align: center" />
        <asp:Label
            runat="server"
            ID="LabelGamesPlayed"
            Style="position: absolute; top: 2em; left: 193px; width: 156px; text-align: center" />
        <asp:Label
            runat="server"
            ID="LabelWins"
            Style="position: absolute; top: 4em; left: 193px; width: 156px; text-align: center" />
    </div>
</div>