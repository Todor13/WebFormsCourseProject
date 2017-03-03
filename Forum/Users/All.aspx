<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="All.aspx.cs" Inherits="Forum.Users.All" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <asp:GridView ID="GridViewUsers" runat="server" BorderStyle="Groove" AutoGenerateColumns="False" 
            AllowPaging="True" DataKeyNames="Id" DataSource="<%# Model.Users %>" EnablePersistedSelection="true" OnDataBound="GridViewUsers_DataBound">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="User Name" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="EMail" HeaderText="E-Mail" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="EditUser?id={0}"/>
            </Columns>
        </asp:GridView>
</asp:Content>
