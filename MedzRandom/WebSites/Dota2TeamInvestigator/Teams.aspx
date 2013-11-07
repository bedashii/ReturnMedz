<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Teams.aspx.cs" Inherits="Teams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="position: absolute; margin-left: 200px; margin-top: 40px">
        <asp:ScriptManager runat="server" ID="ScriptManagerPlayers"></asp:ScriptManager>
        <asp:HiddenField runat="server" ID="HiddenFieldPageWidth" Value="0" />
        <asp:Panel runat="server" ID="PanelSearch" DefaultButton="ButtonSearch">
            <asp:Label runat="server" ID="LabelSearchBox" Text="Search"></asp:Label>
            <asp:TextBox runat="server" ID="TextBoxSearchBox"></asp:TextBox>
            <asp:Button runat="server" ID="ButtonSearch" Text="Search" OnClick="ButtonSearch_Click" />
        </asp:Panel>
        <asp:UpdatePanel runat="server" ID="UpdatePanelPlayers">
            <ContentTemplate>
                <asp:HiddenField runat="server" ID="HiddenFieldCurrentPage" Value="1" />
                <asp:HiddenField runat="server" ID="HiddenFieldTotalPages" Value="1" />
                <asp:ListView runat="server" ID="ListViewPlayers"
                    GroupItemCount="4" GroupPlaceholderID="groupPlaceHolder1"
                    ItemPlaceholderID="itemPlaceHolder1">
                    <LayoutTemplate>
                        <table>
                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <tr>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td>
                            <DotaUC:TeamControl ID="TeamControl" runat="server" Team="<%# Container.DataItem %>" />
                        </td>
                    </ItemTemplate>
                    <EmptyItemTemplate>
                    </EmptyItemTemplate>
                    <EmptyDataTemplate>
                    </EmptyDataTemplate>
                </asp:ListView>
                <div>
                    <asp:Button runat="server" ID="ButtonPrevious" OnClick="ButtonPrevious_OnClick" />
                    <asp:Button runat="server" ID="ButtonNext" OnClick="ButtonNext_OnClick" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
