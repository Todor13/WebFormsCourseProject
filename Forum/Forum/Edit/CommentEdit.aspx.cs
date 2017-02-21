using Forum.Presenters.ForumPresenters.EditPresenters;
using Forum.Views.ForumModels.ForumViewModels.EditViewModels;
using Forum.Views.ForumViews.EditViews;
using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.UI;
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
            var commentId = GetCurrentId();
            this.GetComment?.Invoke(sender, new GetByIdEventArgs(commentId));
        }

        protected void LinkButtonSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (User.Identity.GetUserId<int>() != this.Model.Comment.UserId &&
                !User.IsInRole("admin"))
                {
                    throw new HttpException(404, "File not found!");
                }

                var commentId = GetCurrentId();
                var content = this.TextBoxCommentContent.Text;
                this.EditComment?.Invoke(sender, new ContentEventArgs(commentId, content));

                if (Model.Error == null)
                {
                    Response.Redirect("~/forum/threads/" + Model.Comment.Answer.ThreadId);
                }
            }
        }

        private int GetCurrentId()
        {
            int Id;
            var id = Page.RouteData.Values["id"];
            try
            {
                Id = Convert.ToInt32(id);
                return Id;
            }
            catch (Exception)
            {
                throw new HttpException(404, "File Not Found!");
            }
        }
    }
}