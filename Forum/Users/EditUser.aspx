<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Forum.Users.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h4>Name: 
        <asp:TextBox runat="server" ID="TextBoxFirstName" Text="<%#: Model.User.FirstName %>" />
        <asp:TextBox runat="server" ID="TextBoxLastName" Text="<%#: Model.User.LastName %>" /></h4>
    <table border="0">
        <tr>
            <td>Username:</td>
            <td>
                 <asp:TextBox runat="server" ID="TextBoxUserName" Text="<%#: Model.User.UserName %>" /></td>
            
        </tr>
        <tr>
            <td>Phone:</td>
            <td>
                <asp:TextBox runat="server" ID="TextBoxPhone" Text="<%#: Model.User.PhoneNumber %>" /></td>
        </tr>
        <tr>
            <td>E-Mail:</td>
            <td>
                <asp:TextBox runat="server" ID="TextBoxEmail" Text="<%#: Model.User.Email %>" /></td>
        </tr>
        <tr>
            <td>City:</td>
            <td>
                <asp:TextBox runat="server" ID="TextBoxCity" Text="<%#: Model.User.City %>" /></td>
        </tr>
        <tr>
            <td>Address:</td>
            <td>
                <asp:TextBox runat="server" ID="TextBoxAddress" Text="<%#: Model.User.Address %>" /></td>
        </tr>
    </table>
    <hr />
    <asp:Button runat="server" ID="ButtonSave" Text="Save" OnClick="ButtonSave_Click" />

</asp:Content>
