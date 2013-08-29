<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PlayerControl.ascx.cs" Inherits="PlayerControl" %>

<div>
    <table>
        <tr>
            <td>
                <asp:ImageButton runat="server" ID="ImageButtonAvatar" />
            </td>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="LabelPersonaName"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="LabelWins"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>