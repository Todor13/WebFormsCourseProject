using Forum.Common;
using Forum.Data;
using Forum.MVP.Helpers;
using Forum.Views.ForumViews.EditViews;
using System;
using System.Web;
using WebFormsMvp;

namespace Forum.Presenters.ForumPresenters.EditPresenters
{
    public class CommentEditPresenter : Presenter<ICommentEditView>
    {
        private readonly IForumData forumData;

        public CommentEditPresenter(ICommentEditView view, IForumData forumData) : base(view)
        {
            this.forumData = forumData;

            this.View.GetComment += GetComment;
            this.View.EditComment += EditComment;
        }

        private void EditComment(object sender, ContentEventArgs e)
        {
            Comment comment;

            try
            {
                comment = this.forumData.CommentsRepository.GetCommentById(e.Id);
            }
            catch (Exception)
            {
                throw new HttpException(500, "Internal Server Error");
            }

            var content = e.Content.Trim();

            if (Validator.IsContentValid(content))
            {
                comment.Contents = content;
            }
            else
            {
                this.View.Model.Error = $"Content must be between {GlobalConstants.ContentMinLength} and {GlobalConstants.ContentMaxLength} characters long!";
                return;
            }

            try
            {
                this.forumData.CommentsRepository.UpdateComment(comment);
                this.forumData.Save();
            }
            catch (Exception)
            {
                throw new HttpException(500, "Internal Server Error");
            }
        }

        private void GetComment(object sender, GetByIdEventArgs e)
        {
            var comment = this.forumData.CommentsRepository.GetCommentById(e.Id);

            if (comment.IsVisible == true)
            {
                this.View.Model.Comment = comment;
            }
            else
            {
                this.View.Model.Error = "File not found!";
                return;
            }
        }
    }
}