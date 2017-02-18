using Forum.Presenters;
using Forum.Views;
using System;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;
using Forum.Views.Events;
using Forum.Views.Models;
using System.Web.UI.WebControls;

namespace Forum.Forum
{
    [PresenterBinding(typeof(ThreadPresenter))]
    public partial class Thread : MvpPage<ThreadViewModel>, IThreadView
    {
        private const string ThreadString = "Thread";
        public event EventHandler<AnswerThreadEventArgs> Answer;
        public event EventHandler<GetThreadEventArgs> GetThread;
        public event EventHandler<CommentAnswerEventArgs> Comment;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Page.RouteData.Values["id"];
            int threadId;

            threadId = Convert.ToInt32(id);
            this.GetThread?.Invoke(sender, new GetThreadEventArgs(threadId));

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
                this.Answer?.Invoke(sender, new AnswerThreadEventArgs(this.TextBoxAnswer.Text, threadId));

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
                ViewState["CurrentAnswerId"] = string.Empty;
                ViewState["RepeaterId"] = string.Empty;
                ViewState["CommentText"] = string.Empty;
            }

            if (e.CommandName == "PublishComment")
            {
                TextBox textBoxComment = (TextBox)e.Item.FindControl("TextBoxComment");
                ViewState.Add("CommentText", textBoxComment.Text);

                if (Page.IsValid && ViewState["CurrentAnswerId"] != null)
                {
                    var answerId = Convert.ToInt32(ViewState["CurrentAnswerId"]);
                    this.Comment?.Invoke(sender, new CommentAnswerEventArgs(answerId, textBoxComment.Text));
                    ViewState["CurrentAnswerId"] = string.Empty;
                    ViewState["RepeaterId"] = string.Empty;
                    ViewState["CommentText"] = string.Empty;
                }
            }
        }


        protected void ListViewAnswers_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Repeater repeater = (Repeater)e.Item.FindControl("RepeaterComment");
            Data.Answer answer = ((Data.Answer)e.Item.DataItem);
            repeater.DataSource = answer.Comments;

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
                repeater.DataBind();
            }
            else
            {
                repeater.DataBind();
            }
        }
    }
}