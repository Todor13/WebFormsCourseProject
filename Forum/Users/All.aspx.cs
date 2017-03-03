using Forum.MVP.Presenters.UserPresenters;
using Forum.MVP.Views.UserModels;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Forum.Users
{
    [PresenterBinding(typeof(AllUsersPresenter))]
    public partial class All : MvpPage<AllUsersViewModel>
    {
        const int indexOfColumn = 5;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GridViewUsers_DataBound(object sender, EventArgs e)
        {
            if (!User.IsInRole("admin"))
            {
                this.GridViewUsers.Columns[indexOfColumn].Visible = false;
            }
        }
    }
}