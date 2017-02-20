<%@ Page Title="" Language="C#" MasterPageFile="~/Forum/Forum.master" AutoEventWireup="true" CodeBehind="ThreadEdit.aspx.cs" Inherits="Forum.Forum.Edit.ThreadEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ForumMainContent" runat="server">
    <h3>
        <asp:TextBox runat="server" ID="TextBoxThreadTitle" Text="<%#: Model.Thread.Title %>" Width="30em" Height="3em" TextMode="MultiLine" /></h3>
    <hr />
    <table border="0">
        <tr>
            <td>
                <asp:TextBox runat="server" ID="TextBoxThreadContent" Width="80em" Height="15em" Text="<%#: Model.Thread.Contents %>" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td>Published by <%#: Model.Thread.AspNetUser.Email %> on
                    <%#: String.Format("{0:dd MMMM yyyy H:mm:ss}", Model.Thread.Published.ToLocalTime()) %> in 
                    <asp:DropDownList runat="server" ID="DropDownListSections" DataSource="<%# Model.Sections %>" AutoPostBack="false"/></td>
        </tr>
    </table>
    <asp:LinkButton ID="LinkButtonSave" runat="server"
        OnClick="LinkButtonSave_Click" Text="Save" />
</asp:Content>
