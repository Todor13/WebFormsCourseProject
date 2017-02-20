using Forum.Views.ForumModels.ForumViewModels.EditViewModels;
using System;
using WebFormsMvp;

namespace Forum.Views.ForumViews.EditViews
{
    public interface IAnswerEditView : IView<AnswerEditViewModel>
    {
        event EventHandler<ContentEventArgs> EditAnswer;
        event EventHandler<GetByIdEventArgs> GetAnswer;
    }
}
