<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/ChattersMaster.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Chatters.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center">
        <h2>Contact Us</h2>
    </div>
    <div>
        <table width="100%">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td width="50%">
                                <asp:Label runat="server" ID="labelAddressHeader" Text="Address" />
                            </td>
                            <td width="50%">
                                <asp:Label runat="server" ID="labelAddress" Text=""/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="labelContactNumberHeader" Text="Contact Number"/>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="labelContactNumber" Text=""/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="labelEmailHeader" Text="Email Address"/>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="labelEmail" Text=""/>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <h2>MAP GOES HERE</h2>
                </td>
            </tr>
        </table>
    </div>
    <div style="text-align:center">
        <h2>Leave Us a Message</h2>
    </div>
    <div>
        <table width="100%">
            <tr>
                <td width="20%">
                    <asp:Label runat="server" ID="labelNameHeader" Text="Name" />
                </td>
                <td width="80%">
                    <asp:TextBox runat="server" ID="textboxName" Width="200px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="labelTelEmail" Text="Telephone Number<BR>or<BR>Email Address" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="textboxTelEmail" Width="200px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="labelMessage" Text="Message" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="textboxMessage" TextMode="MultiLine" Width="400px" Height="200px"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>