<%@ Page Title="" Language="C#" MasterPageFile="~/Forum/Forum.master" AutoEventWireup="true" CodeBehind="ThreadEdit.aspx.cs" Inherits="Forum.Forum.Edit.ThreadEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ForumMainContent" runat="server">
    <h4><asp:Label runat="server" ID="LabelError" ForeColor="DarkRed" Text="<%# Model.Error %>" /></h4>
    <br />
    <h4>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" Display="Dynamic" ControlToValidate="TextBoxThreadTitle"
             
         runat="server" ForeColor="DarkRed" ErrorMessage="Title is required!"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" ControlToValidate="TextBoxThreadTitle" 
        ValidationExpression="^.{7,100}$" runat="server" ForeColor="DarkRed"
         ErrorMessage="Title length must be between 7 and 100 characters long!"></asp:RegularExpressionValidator>
        <asp:TextBox runat="server" ID="TextBoxThreadTitle" Text="<%#: Model.Thread.Title %>" Width="30em" Height="3em" TextMode="MultiLine" /></h4>
    <hr />
    <table border="0">
        <tr>
            <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldContent" runat="server" ErrorMessage="Content is required!" 
        ControlToValidate="TextBoxThreadContent" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidatorContent" ControlToValidate="TextBoxThreadContent" 
        ValidationExpression="^.{50,2500}$" runat="server" ForeColor="DarkRed" 
        ErrorMessage="Content length must be between 50 and 2500 characters long!"></asp:RegularExpressionValidator>
                <asp:TextBox runat="server" ID="TextBoxThreadContent" Width="80em" Height="15em" Text="<%#: Model.Thread.Contents %>" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td>Published by <%#: Model.Thread.AspNetUser.Email %> on
                    <%#: String.Format("{0:dd MMMM yyyy H:mm:ss}", Model.Thread.Published.ToLocalTime()) %> in 
                    <asp:DropDownList runat="server" ID="DropDownListSections" DataSource="<%# Model.Sections %>" AutoPostBack="false"/></td>
        </tr>
    </table>
    <asp:LinkButton ID="LinkButtonSave" runat="server"
        OnClick="LinkButtonSave_Click" Text="Save" CausesValidation="true" />
</asp:Content>
