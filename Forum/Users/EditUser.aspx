<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Forum.Users.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:FormView ID="FormViewCustomer" runat="server" DataKeyName="Id" DataSource="<%# Model.User %>" ItemType="Forum.Data.AspNetUser">
            <ItemTemplate>
                <h4><%#: Item.FirstName%> <%#: Item.LastName%></h4>
                <table border="0">
                    <tr>
                        <td>Phone:</td>
                        <td><%#: Item.PhoneNumber %></td>
                    </tr>
                    <tr>
                        <td>E-Mail:</td>
                        <td><%#: Item.Email %></td>
                    </tr>
                     <tr>
                        <td>City:</td>
                        <td><%#: Item.City %></td>
                    </tr>
                    <tr>
                        <td>State:</td>
                        <td><%#: Item.State %></td>
                    </tr>
                     <tr>
                        <td>Postal Code:</td>
                        <td><%#: Item.PostalCode %></td>
                    </tr>
                      <tr>
                        <td>Address:</td>
                        <td><%#: Item.Address %></td>
                    </tr>
                </table>
                <hr />
            </ItemTemplate>
            <EditItemTemplate>
                  <h4><asp:TextBox runat="server" ID="TextBox1" Text="<%#: Item.FirstName %>" /> <asp:TextBox runat="server" ID="TextBox2" Text="<%#: Item.LastName %>" /></h4>
                <table border="0">
                    <tr>
                        <td>Phone:</td>
                        <td><asp:TextBox runat="server" ID="Phone" Text="<%#: Item.PhoneNumber %>" /></td>
                    </tr>
                    <tr>
                        <td>E-Mail:</td>
                        <td><asp:TextBox runat="server" ID="TextBox3" Text="<%#: Item.Email %>" /></td>
                    </tr>
                     <tr>
                        <td>City:</td>
                        <td><asp:TextBox runat="server" ID="TextBox4" Text="<%#: Item.City %>" /></td>
                    </tr>
                    <tr>
                        <td>State:</td>
                        <td><asp:TextBox runat="server" ID="TextBox5" Text="<%#: Item.State %>" /></td>
                    </tr>
                     <tr>
                        <td>Postal Code:</td>
                        <td><asp:TextBox runat="server" ID="TextBox6" Text="<%#: Item.PostalCode %>" /></td>
                    </tr>
                      <tr>
                        <td>Address:</td>
                        <td><asp:TextBox runat="server" ID="TextBox7" Text="<%#: Item.Address %>" /></td>
                    </tr>
                </table>
                <hr />
            </EditItemTemplate>
        </asp:FormView>
</asp:Content>
