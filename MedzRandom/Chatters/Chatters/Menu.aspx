<%@ Page Language="C#" MasterPageFile="~/ChattersMaster.master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Chatters.Menu" Title="Menu" %>
<%@ Reference Control="~/Controls/menuItem.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="AccessDataSource1" EmptyDataText="There are no data records to display.">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Picture" HeaderText="Picture" SortExpression="Picture" />
        </Columns>
    </asp:GridView>--%>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="C:\Git-Dev\ReturnMedz\MedzRandom\Chatters\Database\ChattersDB.accdb" DeleteCommand="DELETE FROM `MenuItem` WHERE `ID` = ?" InsertCommand="INSERT INTO `MenuItem` (`ID`, `Title`, `Description`, `Picture`) VALUES (?, ?, ?, ?)" SelectCommand="SELECT `ID`, `Title`, `Description`, `Picture` FROM `MenuItem`" UpdateCommand="UPDATE `MenuItem` SET `Title` = ?, `Description` = ?, `Picture` = ? WHERE `ID` = ?">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
    </asp:AccessDataSource>
</asp:Content>