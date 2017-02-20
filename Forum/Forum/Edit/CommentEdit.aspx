<%@ Page Title="" Language="C#" MasterPageFile="~/Forum/Forum.master" AutoEventWireup="true" CodeBehind="CommentEdit.aspx.cs" Inherits="Forum.Forum.Edit.CommentEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ForumMainContent" runat="server">
    <h4><asp:Label runat="server" ID="LabelError" ForeColor="DarkRed" Text="<%# Model.Error %>" /></h4>
      <table border="0">
        <tr>
            <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldContent" runat="server" ErrorMessage="Content is required!" 
        ControlToValidate="TextBoxCommentContent" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidatorContent" ControlToValidate="TextBoxCommentContent" 
        ValidationExpression="^.{50,2500}$" runat="server" ForeColor="DarkRed" 
        ErrorMessage="Content length must be between 50 and 2500 characters long!"></asp:RegularExpressionValidator>
                <asp:TextBox runat ="server" ID="TextBoxCommentContent" TextMode="MultiLine" Width="80em" Height="15em" Text="<%#: Model.Comment.Contents %>" />

            </td>
        </tr>
        <tr>
            <td>
                <div>
                    Commented by <%#: Model.Comment.AspNetUser.Email %> on
                    <%#: String.Format("{0:dd MMMM yyyy H:mm:ss}", Model.Comment.Published.ToLocalTime()) %>
                </div>
            </td>
        </tr>
    </table>
        <asp:LinkButton ID="LinkButtonSave" runat="server"
        OnClick="LinkButtonSave_Click" Text="Save" CausesValidation="true" />
</asp:Content>
