using Forum.Data;
using Forum.Views;
using Forum.Views.Events;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
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

        private void Comment(object sender, CommentAnswerEventArgs e)
        {
            var comment = new Comment();

            var userId = HttpContext.User.Identity.GetUserId<int>();

            if (userId != 0)
            {
                comment.UserId = userId;
            }
            else
            {
                HttpContext.Response.Redirect("~/account/login");
                return;
            }

            var content = e.Content.Trim();

            if (content.Length > Common.Constants.ContentMinLength &&
                content.Length < Common.Constants.ContentMaxLength)
            {
                comment.Contents = content;
            }
            else
            {
                HttpContext.Server.Transfer("ErrorPage", true);
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
                HttpContext.Server.Transfer("500", true);
                return;
            }
        }

        private void Answer(object sender, AnswerThreadEventArgs e)
        {
            var answer = new Answer();
            var userId = HttpContext.User.Identity.GetUserId<int>();

            if (userId != 0)
            {
                answer.UserId = userId;
            }
            else
            {
                HttpContext.Response.Redirect("~/account/login");
                return;
                
            }

            var content = e.Content.Trim();

            if (content.Length > Common.Constants.ContentMinLength &&
                content.Length < Common.Constants.ContentMaxLength)
            {
                answer.Contents = content;
            }
            else
            {
                HttpContext.Server.Transfer("ErrorPage", true);
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
                HttpContext.Server.Transfer("500", true);
                return;
            }
            
        }

        private void GetThread(object sender, GetThreadEventArgs e)
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