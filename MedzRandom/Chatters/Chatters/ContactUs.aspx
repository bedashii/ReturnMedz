<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/ChattersMaster.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Chatters.ContactUs" %>

<%@ Register Assembly="Artem.Google" Namespace="Artem.Google.UI" TagPrefix="artem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="text-align: center">
        <h2>Contact Us</h2>
    </div>
    <div>
        <asp:Panel runat="server">
            <table>
                <tr>
                    <td width="135px">
                        <asp:Label runat="server" ID="labelAddressHeader" Text="Address" />
                    </td>
                    <td width="500px">
                        <asp:Label runat="server" ID="labelAddress" Text=""  />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="labelContactNumberHeader" Text="Contact Number" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="labelContactNumber" Text="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="labelEmailHeader" Text="Email Address" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="labelEmail" Text="" />
                    </td>
                </tr>
            </table>
            <artem:GoogleMap ID="GoogleMap1" runat="server" Zoom="18" MapType="Roadmap" Address="57 Lourensford Rd Helderberg, Somerset West 7130 South Africa">
                <markers>
                            <artem:Marker Position-Latitude="-34.076648" Position-Longitude="18.857795"/>
                        </markers>
            </artem:GoogleMap>
            <%--Latitude="-34.076648" Longitude="18.857795"--%>
        </asp:Panel>
    </div>
    <div style="text-align: center">
        <h2>Leave Us a Message</h2>
    </div>
    <div>
        <table width="100%">
            <tr>
                <td width="20%">
                    <asp:Label runat="server" ID="labelNameHeader" Text="Name" />
                </td>
                <td width="80%">
                    <asp:TextBox runat="server" ID="textboxName" Width="200px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="labelTelEmail" Text="Telephone Number<BR>or<BR>Email Address" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="textboxTelEmail" Width="200px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="labelMessage" Text="Message" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="textboxMessage" TextMode="MultiLine" Width="400px" Height="200px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
