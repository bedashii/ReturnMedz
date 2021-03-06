﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menuItem.ascx.cs" Inherits="Chatters.Controls.menuItem" %>

<style type="text/css">
    .auto-style2 {
        width: 100%;
    }

    #table {
        border: none;
        background-color: lightgreen;
        color: black;
        border-collapse: collapse;
    }

        #table td, table th {
            border: 0 solid transparent;
            margin-bottom: 10px;
        }

        #table tr:first-child th {
            border-top: 0;
        }

        #table tr:last-child td {
            border-bottom: 0;
        }

        #table tr td:first-child,
        table tr th:first-child {
            border-left: 0;
        }

        #table tr td:last-child,
        table tr th:last-child {
            border-right: 0;
        }
</style>

<table id="table" class="auto-style2" border="1">
    <tr>
        <td id="titleColumn" style="width: 80%">
            <asp:Label runat="server" ID="labelTitle" Font-Bold="true">Title</asp:Label>
        </td>
        <td id="priceColumn" style="width: 20%">
            <asp:Label runat="server" ID="labelPrice">Price</asp:Label>
        </td>
    </tr>
    <tr>
        <td id="descriptionColumn" style="width: 60%">
            <asp:Label runat="server" ID="labelDescription">Description</asp:Label>
        </td>
        <td id="pictureColumn" style="width: 40%">
            <asp:Image runat="server" ID="imagePlaceHolder"
                Width="100%" />
        </td>
    </tr>
</table>
<br />
