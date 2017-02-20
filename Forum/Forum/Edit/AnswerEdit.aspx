<%@ Page Title="" Language="C#" MasterPageFile="~/Forum/Forum.master" AutoEventWireup="true" CodeBehind="AnswerEdit.aspx.cs" Inherits="Forum.Forum.Edit.AnswerEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ForumMainContent" runat="server">
    <table border="0">
        <tr>
            <td><asp:TextBox runat ="server" ID="TextBoxAnswerContent" TextMode="MultiLine" Width="80em" Height="15em" Text="<%#: Model.Answer.Contents %>" /></td>
        </tr>
        <tr>
            <td>
                <div>
                    Answered by <%#: Model.Answer.AspNetUser.Email %> on
                    <%#: String.Format("{0:dd MMMM yyyy H:mm:ss}", Model.Answer.Published.ToLocalTime()) %>
                </div>
            </td>
        </tr>
    </table>
     <asp:LinkButton ID="LinkButtonSave" runat="server"
        OnClick="LinkButtonSave_Click" Text="Save" />
</asp:Content>
