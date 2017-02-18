<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Reply.ascx.cs" Inherits="Forum.Controls.Reply" %>
<asp:Panel runat="server" ID="AnswerPanel">
    <h4>Reply</h4>
    <br />
     <asp:RegularExpressionValidator ID="RegularExpressionValidatorContent" ControlToValidate="TextBoxReply" 
        ValidationExpression="^.{50,2500}$" runat="server" ForeColor="DarkRed" 
        ErrorMessage="Reply length must be between 50 and 2500 characters long!" EnableClientScript="false"></asp:RegularExpressionValidator>
    <asp:TextBox runat="server" ID="TextBoxReply" Width="100%" Height="15em" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <asp:Button runat="server" ID="PublishButton" Text="Publish" CausesValidation="true" OnClick="PublishButton_Click" />
    <asp:Button runat="server" ID="CancelButton" Text="Cancel" OnClick="CancelButton_Click" />

</asp:Panel>
