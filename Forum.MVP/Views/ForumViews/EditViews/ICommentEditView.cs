using Forum.Views.ForumModels.ForumViewModels.EditViewModels;
using System;
using WebFormsMvp;

namespace Forum.Views.ForumViews.EditViews
{
    public interface ICommentEditView : IView<CommentEditViewModel>
    {
        event EventHandler<ContentEventArgs> EditComment;
        event EventHandler<GetByIdEventArgs> GetComment;
    }
}
