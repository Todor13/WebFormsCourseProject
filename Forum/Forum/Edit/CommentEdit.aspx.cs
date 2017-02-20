using Forum.Presenters.ForumPresenters.EditPresenters;
using Forum.Views.ForumModels.ForumViewModels.EditViewModels;
using Forum.Views.ForumViews.EditViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Forum.Forum.Edit
{
    [PresenterBinding(typeof(CommentEditPresenter))]
    public partial class CommentEdit : MvpPage<CommentEditViewModel>, ICommentEditView
    {
        public event EventHandler<ContentEventArgs> EditComment;
        public event EventHandler<GetByIdEventArgs> GetComment;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Page.RouteData.Values["id"];
            int commentId;

            commentId = Convert.ToInt32(id);
            this.GetComment?.Invoke(sender, new GetByIdEventArgs(commentId));
        }

        protected void LinkButtonSave_Click(object sender, EventArgs e)
        {
            var content = this.TextBoxCommentContent.Text;
            this.EditComment?.Invoke(sender, new ContentEventArgs(content));
            Response.Redirect("~/forum/threads/" + Model.Comment.Answer.ThreadId);
        }
    }
}