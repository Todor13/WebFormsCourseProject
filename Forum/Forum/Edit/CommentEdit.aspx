<%@ Page Title="" Language="C#" MasterPageFile="~/Forum/Forum.master" AutoEventWireup="true" CodeBehind="CommentEdit.aspx.cs" Inherits="Forum.Forum.Edit.CommentEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ForumMainContent" runat="server">
      <table border="0">
        <tr>
            <td><asp:TextBox runat ="server" ID="TextBoxCommentContent" TextMode="MultiLine" Width="80em" Height="15em" Text="<%#: Model.Comment.Contents %>" /></td>
        </tr>
        <tr>
            <td>
                <div>
                    <%# Model.Comment %>
                    Commented by <%#: Model.Comment.AspNetUser.Email %> on
                    <%#: String.Format("{0:dd MMMM yyyy H:mm:ss}", Model.Comment.Published.ToLocalTime()) %>
                </div>
            </td>
        </tr>
    </table>
        <asp:LinkButton ID="LinkButtonSave" runat="server"
        OnClick="LinkButtonSave_Click" Text="Save" />
</asp:Content>
