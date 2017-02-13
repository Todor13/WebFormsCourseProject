using Forum.Presenters;
using Forum.Views;
using System;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;
using Forum.Views.Events;
using Forum.Views.Models;
using System.Web.UI.WebControls;
using Forum.Controls;
using Forum.Data;
using System.Collections;
using System.Data;

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

            try
            {
                threadId = Convert.ToInt32(id);
                this.GetThread?.Invoke(sender, new GetThreadEventArgs(threadId));

            }
            catch (Exception ex)
            {
                //TODO Server.Transfer("NoFileErrorPage.aspx", true);
            }
        }



        protected void AnswerButton_Click(object sender, EventArgs e)
        {
            this.AnswerPanel.Visible = true;
        }

        protected void PublishButton_Click(object sender, EventArgs e)
        {
            var id = Page.RouteData.Values["id"];
            int threadId;
            try
            {
                threadId = Convert.ToInt32(id);
                this.Answer?.Invoke(sender, new AnswerThreadEventArgs(this.TextBoxAnswer.Text, threadId));
            }
            catch
            {

            }

            this.AnswerPanel.Visible = false;
            this.TextBoxAnswer.Text = string.Empty;

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.AnswerPanel.Visible = false;
            this.TextBoxAnswer.Text = string.Empty;
        }

        string id;
        protected void ListViewAnswers_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Comment")
            {
                id = e.Item.ID;
            }
        }

        
        protected void ListViewAnswers_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Repeater repeater = (Repeater)e.Item.FindControl("RepeaterComment");
            Data.Answer answer = ((Data.Answer)e.Item.DataItem);
            repeater.DataSource = answer.Comments;         
            repeater.DataBind();


            if (id != null && e.Item.ID == id)
            {
                Reply reply = (Reply)e.Item.FindControl("ReplyComment");
                reply.Visible = true;
                ViewState.Add("CurrentAnswerId", answer.Id);
            }
        }

        protected void ReplyComment_PublishButtonClick(object sender, PublishEventArgs e)
        {
            if (e.PublishText != null && ViewState["CurrentAnswerId"] != null)
            {
                var answerId = Convert.ToInt32(ViewState["CurrentAnswerId"]);
                this.Comment?.Invoke(sender, new CommentAnswerEventArgs(answerId, e.PublishText));
            }
        }

    
    }
}