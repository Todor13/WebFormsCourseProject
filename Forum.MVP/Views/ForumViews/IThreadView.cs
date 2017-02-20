using Forum.Views.Events;
using Forum.Views.ForumViews.EditViews;
using Forum.Views.Models;
using System;
using WebFormsMvp;

namespace Forum.Views
{
    public interface IThreadView : IView<ThreadViewModel>
    {
        event EventHandler<GetByIdEventArgs> GetThread;
        event EventHandler<ReplyEventArgs> Answer;
        event EventHandler<ReplyEventArgs> Comment;
    }
}