using Forum.Presenters;
using Forum.Views;
using System;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;
using Forum.Views.Events;
using Forum.Views.Models;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Forum.Views.ForumViews.EditViews;

namespace Forum.Forum
{
    [PresenterBinding(typeof(ThreadPresenter))]
    public partial class Thread : MvpPage<ThreadViewModel>, IThreadView
    {
        private const string ThreadString = "Thread";

        public event EventHandler<ReplyEventArgs> Answer;
        public event EventHandler<GetByIdEventArgs> GetThread;
        public event EventHandler<ReplyEventArgs> Comment;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Page.RouteData.Values["id"];
            int threadId;

            threadId = Convert.ToInt32(id);
            this.GetThread?.Invoke(sender, new GetByIdEventArgs(threadId));

            if (this.Model.Thread.UserId == this.User.Identity.GetUserId<int>())
            {
                this.HyperLinkThreadEdit.Visible = true;
            }
        }

        protected void AnswerButton_Click(object sender, EventArgs e)
        {
            this.AnswerPanel.Visible = true;
            this.TextBoxAnswer.Focus();
        }

        protected void PublishButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var id = Page.RouteData.Values["id"];
                int threadId;
                threadId = Convert.ToInt32(id);
                var userId = User.Identity.GetUserId<int>();

                if (userId != 0)
                {
                    this.Answer?.Invoke(sender, new ReplyEventArgs(threadId, userId, this.TextBoxAnswer.Text));
                }
                else
                {
                    Response.Redirect("~/account/login");
                }
                

                this.AnswerPanel.Visible = false;
                this.TextBoxAnswer.Text = string.Empty;
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.AnswerPanel.Visible = false;
            this.TextBoxAnswer.Text = string.Empty;
        }

        protected void ListViewAnswers_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Comment")
            {
                ViewState.Add("RepeaterId", e.Item.ID);
            }

            if (e.CommandName == "CancelComment")
            {
                ViewState["CurrentAnswerId"] = null;
                ViewState["RepeaterId"] = null;
                ViewState["CommentText"] = null;
            }

            if (e.CommandName == "PublishComment")
            {
                TextBox textBoxComment = (TextBox)e.Item.FindControl("TextBoxComment");
                ViewState.Add("CommentText", textBoxComment.Text);

                if (Page.IsValid && ViewState["CurrentAnswerId"] != null)
                {
                    var answerId = Convert.ToInt32(ViewState["CurrentAnswerId"]);
                    var userId = User.Identity.GetUserId<int>();

                    if (userId != 0)
                    {
                        this.Comment?.Invoke(sender, new ReplyEventArgs(answerId, userId, textBoxComment.Text));
                    }
                    else
                    {
                        Response.Redirect("~/account/login");
                    }
                    
                    ViewState["CurrentAnswerId"] = null;
                    ViewState["RepeaterId"] = null;
                    ViewState["CommentText"] = null;
                }
            }
        }

        protected void ListViewAnswers_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListView listViewComments = (ListView)e.Item.FindControl("RepeaterComment");
            Data.Answer answer = ((Data.Answer)e.Item.DataItem);
            listViewComments.DataSource = answer.Comments;

            HyperLink answerEditLink = (HyperLink)e.Item.FindControl("HyperLinkAnswerEdit");

            if (answer.UserId == User.Identity.GetUserId<int>())
            {
                answerEditLink.Visible = true;
            }

            if (ViewState["RepeaterId"] != null && e.Item.ID == (string)ViewState["RepeaterId"])
            {
                Panel reply = (Panel)e.Item.FindControl("CommentPanel");
                reply.Visible = true;
                ViewState.Add("CurrentAnswerId", answer.Id);

                RegularExpressionValidator regExpValidator = (RegularExpressionValidator)e.Item.FindControl("RegularExpressionValidatorComment");
                TextBox tb = (TextBox)e.Item.FindControl("TextBoxComment");
                tb.Text = (string)ViewState["CommentText"];

                regExpValidator.ControlToValidate = tb.ID;
                regExpValidator.Validate();
                listViewComments.DataBind();
            }
            else
            {
                listViewComments.DataBind();
            }
        }
    }
}