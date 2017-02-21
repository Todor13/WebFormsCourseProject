using Forum.MVP.Presenters.UserPresenters;
using Forum.MVP.Views.UserModels;
using System;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Forum.Users
{
    [PresenterBinding(typeof(AllUsersPresenter))]
    public partial class All : MvpPage<AllUsersViewModel>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void GridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (User.IsInRole("admin"))
            {
                e.Row.Cells[5].Visible = true;
            }
        }
    }
}