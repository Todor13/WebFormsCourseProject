﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forum/Forum.master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="Forum.Forum.Thread" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/Controls/Reply.ascx" TagName="Reply" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ForumMainContent" runat="server">
    <h3><%#:  Model.Thread.Title %></h3>
    <hr />
    <table border="0">
        <tr>
            <td><%#: Model.Thread.Contents %></td>
        </tr>
        <tr>
            <td>Published by <%#: Model.Thread.AspNetUser.Email %> on
                    <%#: String.Format("{0:dd/MMMM/yyyy H:mm:ss}", Model.Thread.Published) %> in 
                    <%#: Model.Thread.Section.Name %></td>
            <td>
                <asp:Button runat="server" ID="AnswerButton" Text="Answer" OnClick="AnswerButton_Click" /></td>
        </tr>
    </table>

    <asp:Panel runat="server" ID="AnswerPanel" Visible="false">
        <h4>Add Answer</h4>
        <br />
        <asp:TextBox runat="server" ID="TextBoxAnswer"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="PublishButton" Text="Publish" OnClick="PublishButton_Click" />
        <asp:Button runat="server" ID="CancelButton" Text="Cancel" OnClick="CancelButton_Click" />
    </asp:Panel>
    <br />

    <asp:ListView runat="server" ID="ListViewAnswers" ItemType="Forum.Data.Answer" DataSource="<%# Model.Answers %>" OnItemCommand="ListViewAnswers_ItemCommand" OnItemDataBound="ListViewAnswers_ItemDataBound">
        <LayoutTemplate>
            <h3>Answers</h3>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>

        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>

        <ItemTemplate>
            <div class="answers">
                <table border="0">
                    <tr>
                        <td><%#: Item.Contents %></td>
                    </tr>
                    <tr style="border-bottom:1px solid; margin-bottom:20em">
                        <td><div>Answered by <%#: Item.AspNetUser.Email %> on
                    <%#: String.Format("{0:dd/MMMM/yyyy H:mm:ss}", Item.Published) %>
                        </div></td>
                    </tr>
                    <asp:Repeater runat="server" ID="RepeaterComment" ItemType="Forum.Data.Comment">
                        <ItemTemplate>
                            <tr>
                                <td style="padding-left:5em">
                                    <div class="comment">
                                        <p><%#: Item.Contents %></p>
                                        <p>Commented by <%#: Item.AspNetUser.UserName %> on <%#: Item.Published %></p>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>              
                    </asp:Repeater>

                    <tr>
                        <td>
                            <asp:Button runat="server" CommandName="Comment" ID="ButtonComment" Text="Comment" UseSubmitBehavior="false" /></td>
                    </tr>
                    <tr>
                        <td>
                            <uc:Reply runat="server" ID="ReplyComment" Visible="false" OnPublishButtonClick="ReplyComment_PublishButtonClick" ReplyId="<%# Item.Id %>"></uc:Reply>
                        </td>
                    </tr>
                </table>

            </div>
        </ItemTemplate>
    </asp:ListView>


    <asp:DataPager ID="DataPagerAnswers" runat="server"
        PagedControlID="ListViewAnswers" PageSize="3"
        QueryStringField="page">
        <Fields>
            <asp:NextPreviousPagerField ShowFirstPageButton="true"
                ShowNextPageButton="false" ShowPreviousPageButton="false" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowLastPageButton="true"
                ShowNextPageButton="false" ShowPreviousPageButton="false" />
        </Fields>
    </asp:DataPager>
</asp:Content>
