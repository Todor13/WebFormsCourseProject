<%@ Page Title="" Language="C#" MasterPageFile="~/Forum/Forum.master" AutoEventWireup="true" CodeBehind="CreateThread.aspx.cs" Inherits="Forum.Forum.CreateThread" ValidateRequest="false" %>

<asp:Content ContentPlaceHolderID="ForumMainContent" ID="CreateThreadContent" runat="server">
    <h1>Create Thread</h1>
    <br />
    <hr />
    <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
    <br />
    <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
    <br />
    <hr />
    <asp:Label ID="Label2" runat="server" Text="Select Section"></asp:Label>
    <br />
    <asp:DropDownList runat="server" ID="DropDownSections" DataSource="<%# Model.Sections %>"></asp:DropDownList>
    <br />
    <hr />
    <asp:Label ID="Label3" runat="server" Text="Content"></asp:Label>
    <br />
    <asp:TextBox ID="TextBoxContent" runat="server" Height="125px" Width="592px"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Create" OnClick="Button1_Click" />
    <hr />

</asp:Content>
