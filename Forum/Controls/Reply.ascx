<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Reply.ascx.cs" Inherits="Forum.Controls.Reply" %>
<asp:Panel runat="server" ID="AnswerPanel">
    <h4>Reply</h4>
    <br />
    <asp:TextBox runat="server" ID="TextBoxReply" Width="100%" Height="15em" TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:Button runat="server" ID="PublishButton" Text="Publish" OnClick="PublishButton_Click" UseSubmitBehavior="false" />
    <asp:Button runat="server" ID="CancelButton" Text="Cancel" OnClick="CancelButton_Click" />

    <asp:RangeValidator ID="RangeValidatorTextBoxReply" runat="server" ErrorMessage="Your reply should be between 10 and 1500 characters long!" Type="String" ControlToValidate="TextBoxReply" MinimumValue="10" MaximumValue="15"></asp:RangeValidator>
</asp:Panel>
