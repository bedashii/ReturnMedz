<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MatchControl.ascx.cs" Inherits="MatchControl" %>
<div style="
    position: relative;
    /*border: solid 1px;*/
    margin-bottom: 5px;
    margin-right: 5px;
    padding-left: 2px;"
    >
    <asp:ImageButton runat="server" ID="ImageButtonHero" Style="padding-top: 10px"/>
    <asp:Label runat="server" ID="LabelVictory" Text="Winner!" ForeColor="green" Style="position: absolute; left: 65px; top: 5px;" />
    <asp:Label runat="server" ID="LabelKDA" Text="K/D/A" Style="position: absolute; left: 65px; top: 30px;" />
    <table style="position: absolute; left: 130px; top: 0px;">
        <tr>
            <td>
                <asp:ImageButton runat="server" ID="ImageButtonItem1" Width="25px" Height="25px" />
            </td>
            <td>
                <asp:ImageButton runat="server" ID="ImageButtonItem2" Width="25px" Height="25px" />
            </td>
            <td>
                <asp:ImageButton runat="server" ID="ImageButtonItem3" Width="25px" Height="25px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton runat="server" ID="ImageButtonItem4" Width="25px" Height="25px" />
            </td>
            <td>
                <asp:ImageButton runat="server" ID="ImageButtonItem5" Width="25px" Height="25px" />
            </td>
            <td>
                <asp:ImageButton runat="server" ID="ImageButtonItem6" Width="25px" Height="25px" />
            </td>
        </tr>
    </table>
    <br />
    <br />
</div>
