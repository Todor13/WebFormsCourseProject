﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Reply.ascx.cs" Inherits="Forum.Controls.Reply" %>
    <asp:Panel runat="server" ID="AnswerPanel">
        <h4>Reply</h4>
        <br />
        <asp:TextBox runat="server" ID="TextBoxReply"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="PublishButton" Text="Publish" OnClick="PublishButton_Click" UseSubmitBehavior="false"/>
        <asp:Button runat="server" ID="CancelButton" Text="Cancel" OnClick="CancelButton_Click" />
    </asp:Panel>