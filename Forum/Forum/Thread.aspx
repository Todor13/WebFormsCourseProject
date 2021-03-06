﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forum/Forum.master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="Forum.Forum.Thread" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/Controls/Reply.ascx" TagName="Reply" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ForumMainContent" runat="server">
    <h3><%#: Model.Thread.Title %></h3>
    <asp:HyperLink runat="server" ID="HyperLinkThreadEdit" NavigateUrl='<%# GetRouteUrl("ForumThreadEdit", new {id = Model.Thread.Id}) %>' Text="Edit" Visible="false" />
    <hr />
    <table border="0">
        <tr>
            <td><%#: Model.Thread.Contents %></td>
        </tr>
        <tr>
            <td>Published by <%#: Model.Thread.AspNetUser.Email %> on
                    <%#: String.Format("{0:dd MMMM yyyy H:mm:ss}", Model.Thread.Published.ToLocalTime()) %> in 
                    <%#: Model.Thread.Section.Name %></td>
            <td>
                <asp:Button runat="server" ID="AnswerButton" Text="Answer" OnClick="AnswerButton_Click" />
            </td>
        </tr>
    </table>

    <asp:UpdatePanel runat="server" ID="UpdatePanelAnswer" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel runat="server" ID="AnswerPanel" Visible="false">
                <h4>Add Answer</h4>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldAnswer" runat="server" ErrorMessage="Answer is empty!"
                    ControlToValidate="TextBoxAnswer" Display="Dynamic" ForeColor="DarkRed" EnableClientScript="false"></asp:RequiredFieldValidator>
<%--                <asp:RegularExpressionValidator ID="RegularExpressionValidatorContent" EnableClientScript="false" ControlToValidate="TextBoxAnswer"
                    ValidationExpression="^.{50,2500}$" runat="server" ForeColor="DarkRed"
                    ErrorMessage="Answer length must be between 50 and 2500 characters long!"></asp:RegularExpressionValidator>--%>
                <asp:TextBox runat="server" ID="TextBoxAnswer" Width="100%" Height="15em" TextMode="MultiLine"></asp:TextBox>
                <br />
                <br />
                <asp:Button runat="server" ID="PublishButton" Text="Publish" OnClick="PublishButton_Click" />
                <asp:Button runat="server" ID="CancelButton" Text="Cancel" OnClick="CancelButton_Click" />
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="AnswerButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <br />
    <asp:UpdatePanel runat="server" ID="UpdatePanelAnswersComments">
        <ContentTemplate>
            <asp:ListView runat="server" ID="ListViewAnswers" ItemType="Forum.Data.Answer" DataSource="<%# Model.Answers %>" OnItemCommand="ListViewAnswers_ItemCommand" OnItemDataBound="ListViewAnswers_ItemDataBound">
                <LayoutTemplate>
                    <h3>Answers</h3>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </LayoutTemplate>

                <ItemTemplate>
                    <div class="answers">
                        <table border="0">
                            <tr>
                                <td><%#: Item.Contents %></td>
                            </tr>
                            <tr style="border-bottom: 1px solid; margin-bottom: 20em">
                                <td>
                                    <div>
                                        Answered by <%#: Item.AspNetUser.Email %> on
                    <%#: String.Format("{0:dd MMMM yyyy H:mm:ss}", Item.Published.ToLocalTime()) %>
                                    </div>
                                    <asp:HyperLink runat="server" ID="HyperLinkAnswerEdit" NavigateUrl='<%# GetRouteUrl("ForumAnswerEdit", new { id = Item.Id })%>' Text="Edit" Visible="false" />
                                </td>
                            </tr>
                            <asp:ListView runat="server" ID="RepeaterComment" ItemType="Forum.Data.Comment">
                                <LayoutTemplate>
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                </LayoutTemplate>

                                <ItemTemplate>
                                    <tr>
                                        <td style="padding-left: 5em">
                                            <div class="comment">
                                                <p><%#: Item.Contents %></p>
                                                <p>Commented by <%#: Item.AspNetUser.UserName %> on <%#:  String.Format("{0:dd MMMM yyyy H:mm:ss}", Item.Published.ToLocalTime()) %></p>
                                                <asp:HyperLink runat="server" ID="HyperLinkThreadEdit" NavigateUrl='<%# GetRouteUrl("ForumCommentEdit", new {id = Item.Id}) %>' Text="Edit" Visible="<%# IsVisible(Item) %>" />
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                            <tr>
                                <td>
                                    <asp:Button runat="server" CommandName="Comment" ID="ButtonComment" Text="Comment" UseSubmitBehavior="false" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel runat="server" ID="CommentPanel" Visible="false">
                                        <h4>Add Comment</h4>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldComment" runat="server" ErrorMessage="Comment is empty!"
                                            ControlToValidate="TextBoxComment" Display="Dynamic" ForeColor="DarkRed" EnableClientScript="false"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorComment"
                                            EnableClientScript="false" ControlToValidate="TextBoxComment"
                                            ValidationExpression="^.{50,2500}$" runat="server" ForeColor="DarkRed"
                                            ErrorMessage="Comment length must be between 50 and 2500 characters long!"></asp:RegularExpressionValidator>
                                        <asp:TextBox runat="server" ID="TextBoxComment" Width="100%" Height="15em" TextMode="MultiLine"></asp:TextBox>
                                        <br />
                                        <br />
                                        <asp:Button runat="server" ID="ButtonCommentPublish" Text="Publish" CommandName="PublishComment" />
                                        <asp:Button runat="server" ID="CancelButton" Text="Cancel" CommandName="CancelComment" />
                                    </asp:Panel>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
