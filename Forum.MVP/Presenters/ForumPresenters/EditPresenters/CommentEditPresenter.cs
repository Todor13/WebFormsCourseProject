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
        private Comment currentComment;

        public CommentEditPresenter(ICommentEditView view, IForumData forumData) : base(view)
        {
            this.forumData = forumData;

            this.View.GetComment += GetComment;
            this.View.EditComment += EditComment;
        }

        private void EditComment(object sender, ContentEventArgs e)
        {
            var content = e.Content.Trim();

            if (Validator.IsContentValid(content))
            {
                this.currentComment.Contents = content;
            }
            else
            {
                this.View.Model.Error = $"Content must be between {GlobalConstants.ContentMinLength} and {GlobalConstants.ContentMaxLength} characters long!";
                return;
            }

            try
            {
                this.forumData.CommentsRepository.UpdateComment(this.currentComment);
                this.forumData.Save();
            }
            catch (Exception)
            {
                this.View.Model.Error = "Something went wrong!";
                return;
            }
        }

        private void GetComment(object sender, GetByIdEventArgs e)
        {
            var comment = this.forumData.CommentsRepository.GetCommentById(e.Id);

            if (comment.IsVisible == true)
            {
                this.View.Model.Comment = comment;
                this.currentComment = comment;
            }
            else
            {
                this.View.Model.Error = "File not found!";
                return;
            }
        }
    }
}