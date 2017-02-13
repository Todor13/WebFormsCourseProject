using Forum.Views.Events;
using Forum.Views.Models;
using System;
using WebFormsMvp;

namespace Forum.Views
{
    public interface IThreadView : IView<ThreadViewModel>
    {
        event EventHandler<GetThreadEventArgs> GetThread;
        event EventHandler<AnswerThreadEventArgs> Answer;
        event EventHandler<CommentAnswerEventArgs> Comment;
    }
}