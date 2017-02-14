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

            comment.Contents = e.Content;
            comment.UserId = HttpContext.User.Identity.GetUserId<int>();
            comment.Published = DateTime.UtcNow;
            comment.IsVisible = true;
            comment.AnswerId = e.Id;

            this.forumData.CommentsRepository.CreateComment(comment);
            this.forumData.Save();
        }

        private void Answer(object sender, AnswerThreadEventArgs e)
        {
            var answer = new Answer();

            answer.Contents = e.Content;
            answer.UserId = HttpContext.User.Identity.GetUserId<int>();
            answer.Published = DateTime.UtcNow;
            answer.IsVisible = true;
            answer.ThreadId = e.Id;

            this.forumData.AnswersRepository.CreateAnswer(answer);
            this.forumData.Save();
        }

        private void GetThread(object sender, GetThreadEventArgs e)
        {
            var thread = this.forumData.ThreadsRepository.GetThreadById(e.Id);
            if (thread.IsVisible == true)
            {
                this.View.Model.Thread = thread;
            }
            
            var answers = this.forumData.AnswersRepository.GetAnswersByThreadId(e.Id).Where(a=>a.IsVisible == true).ToArray();
            this.View.Model.Answers = answers;
        }
    }
}