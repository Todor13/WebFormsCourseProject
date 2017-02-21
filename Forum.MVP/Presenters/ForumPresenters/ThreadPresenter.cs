using Forum.Common;
using Forum.Data;
using Forum.MVP.Helpers;
using Forum.Views;
using Forum.Views.Events;
using Forum.Views.ForumViews.EditViews;
using System;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace Forum.Presenters
{
    public class ThreadPresenter : Presenter<IThreadView>
    {
        private IForumData forumData;
        public ThreadPresenter(IThreadView view, IForumData forumData) : base(view)
        {
            this.forumData = forumData;

            this.View.GetThread += GetThread;
            this.View.Answer += Answer;
            this.View.Comment += Comment;
        }

        private void Comment(object sender, ReplyEventArgs e)
        {
            var comment = new Comment();

            var userId = e.UserId;

            if (userId != 0)
            {
                comment.UserId = userId;
            }
            else
            {
                this.View.Model.Error = "Please, log in!";
                return;
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

            comment.Published = DateTime.UtcNow;
            comment.IsVisible = true;
            comment.AnswerId = e.Id;

            try
            {
                this.forumData.CommentsRepository.CreateComment(comment);
                this.forumData.Save();
            }
            catch (Exception)
            {
                throw new HttpException(500, "Internal Server Error");
            }
        }

        private void Answer(object sender, ReplyEventArgs e)
        {
            var answer = new Answer();

            var userId = e.UserId;

            if (userId != 0)
            {
                answer.UserId = userId;
            }
            else
            {
                this.View.Model.Error = "Please, log in!";
                return;
            }

            var content = e.Content.Trim();

            if (Validator.IsContentValid(content))
            {
                answer.Contents = content;
            }
            else
            {
                this.View.Model.Error = $"Content must be between {GlobalConstants.ContentMinLength} and {GlobalConstants.ContentMaxLength} characters long!";
                return;
            }

            answer.ThreadId = e.Id;
            answer.Published = DateTime.UtcNow;
            answer.IsVisible = true;

            try
            {
                this.forumData.AnswersRepository.CreateAnswer(answer);
                this.forumData.Save();
            }
            catch (Exception)
            {
                throw new HttpException(500, "Internal Server Error");
            }
            
        }

        private void GetThread(object sender, GetByIdEventArgs e)
        {
            var thread = this.forumData.ThreadsRepository.GetThreadById(e.Id);
            if (thread.IsVisible == true)
            {
                this.View.Model.Thread = thread;
            }

            var answers = this.forumData.AnswersRepository.GetAnswersByThreadId(e.Id).Where(a => a.IsVisible == true).ToList();
            foreach (var answer in answers)
            {
                answer.Comments.OrderBy(c => c.Published);
            }

            this.View.Model.Answers = answers;
        }
    }
}