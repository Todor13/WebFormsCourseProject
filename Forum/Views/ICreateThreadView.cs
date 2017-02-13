using Forum.Models;
using Forum.Views.Events;
using System;
using WebFormsMvp;

namespace Forum.Views
{
    public interface ICreateThreadView : IView<CreateThreadViewModel>
    {
        event EventHandler<CreateThreadEventArgs> Create;
    }
}
