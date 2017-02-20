using Forum.Views.Events.ForumEvents.EditEvents;
using Forum.Views.Models.ForumViewModels.EditViewModels;
using System;
using WebFormsMvp;

namespace Forum.Views.ForumViews.EditViews
{
    public interface IThreadEditView : IView<ThreadEditViewModel>
    {
        event EventHandler<GetByIdEventArgs> GetThread;
        event EventHandler<ThreadEditEventArgs> EditThread;
    }
}