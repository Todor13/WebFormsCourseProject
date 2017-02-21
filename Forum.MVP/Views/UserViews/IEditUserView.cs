using Forum.MVP.Views.UserModels;
using System;
using WebFormsMvp;

namespace Forum.MVP.Views.UserViews
{
    public interface IEditUserView : IView<EditUserViewModel>
    {
        event EventHandler<GetUserByIdEventArgs> GetUser;
        event EventHandler<EditUserEventArgs> UserEdit;
        event EventHandler<GetUserByIdEventArgs> DeleteUser;
    }
}
