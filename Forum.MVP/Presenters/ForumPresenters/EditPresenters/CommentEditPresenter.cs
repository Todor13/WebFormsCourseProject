using Forum.Data;
using Forum.Views.ForumViews.EditViews;
using System;
using System.Web;
using WebFormsMvp;

namespace Forum.Presenters.ForumPresenters.EditPresenters
{
    public class CommentEditPresenter : Presenter<ICommentEditView>
    {
        private readonly IForumData forumData;
        private Comment currentComment;

        public CommentEditPresenter(ICommentEditView view, IForumData forumData) : base(view)
        {
            this.forumData = forumData;

            this.View.GetComment += GetComment;
            this.View.EditComment += EditComment;
        }

        private void EditComment(object sender, ContentEventArgs e)
        {
            //if (HttpContext.User.Identity.GetUserId<int>() != this.currentComment.UserId &&
            //  !HttpContext.User.IsInRole("admin"))
            //{
            //    HttpContext.Response.Redirect("~/Errors/ErrorPage", true);
            //    return;
            //}

            var content = e.Content.Trim();

            if (content.Length > Common.GlobalConstants.ContentMinLength &&
                content.Length < Common.GlobalConstants.ContentMaxLength)
            {
                this.currentComment.Contents = content;
            }
            else
            {
                //HttpContext.Response.Redirect("~/Errors/ErrorPage", true);
                return;
            }

            try
            {
                this.forumData.CommentsRepository.UpdateComment(this.currentComment);
                this.forumData.Save();
            }
            catch (Exception)
            {
                //throw new HttpException(500, "Internal Server Error");
            }
        }

        private void GetComment(object sender, GetByIdEventArgs e)
        {
            var comment = this.forumData.CommentsRepository.GetCommentById(e.Id);

            //if (comment.IsVisible == true && comment.UserId == HttpContext.User.Identity.GetUserId<int>())
            //{
            //    this.View.Model.Comment = comment;
            //    this.currentComment = comment;
            //}
            //else if (HttpContext.User.IsInRole("admin"))
            //{
            //    this.View.Model.Comment = comment;
            //    this.currentComment = comment;
            //}
            //else
            //{
            //    throw new HttpException(404, "Not found");
            //}
        }
    }
}