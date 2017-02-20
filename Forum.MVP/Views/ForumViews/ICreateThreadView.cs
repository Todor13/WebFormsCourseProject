using Forum.Views.Events;
using Forum.Views.Models;
using System;
using WebFormsMvp;

namespace Forum.Views
{
    public interface ICreateThreadView : IView<CreateThreadViewModel>
    {
        event EventHandler<ThreadEventArgs> Create;
    }
}
