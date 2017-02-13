using Forum.Data;
using Forum.Views;
using Forum.Views.Events;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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

        private void Comment(object sender, CommentAnswerEventArgs e)
        {
            var comment = new Comment();

            comment.Contents = e.Content;
            comment.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId<int>();
            comment.Published = DateTime.UtcNow;
            comment.IsVisible = true;

            this.forumData.AnswersRepository.GetAnswerById(e.Id).Comments.Add(comment);
            this.forumData.Save();
        }

        private void Answer(object sender, AnswerThreadEventArgs e)
        {
            var answer = new Answer();

            answer.Contents = e.Content;
            answer.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId<int>();
            answer.Published = DateTime.UtcNow;
            answer.IsVisible = true;

            this.forumData.ThreadsRepository.GetThreadById(e.Id).Answers.Add(answer);
            this.forumData.Save();
        }

        private void GetThread(object sender, GetThreadEventArgs e)
        {
            var thread = this.forumData.ThreadsRepository.GetThreadById(e.Id);
            this.View.Model.Thread = thread;
            var answers = this.forumData.AnswersRepository.GetAnswersByThreadId(e.Id).ToArray();
            this.View.Model.Answers = answers;
        }
    }
}