using Forum.MVP.Presenters.UserPresenters;
using Forum.MVP.Views.UserModels;
using Forum.MVP.Views.UserViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Forum.Users
{
    [PresenterBinding(typeof(EditUserPresenter))]
    public partial class EditUser : MvpPage<EditUserViewModel>, IEditUserView
    {
        public event EventHandler<GetUserByIdEventArgs> DeleteUser;
        public event EventHandler<EditUserEventArgs> UserEdit;
        public event EventHandler<GetUserByIdEventArgs> GetUser;
        
    

        protected void Page_Load(object sender, EventArgs e)
        {

        }

    }
}