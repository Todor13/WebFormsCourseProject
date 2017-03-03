using Forum.MVP.Presenters.UserPresenters;
using Forum.MVP.Views.UserModels;
using Forum.MVP.Views.UserViews;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Forum.Users
{
    [PresenterBinding(typeof(EditUserPresenter))]
    public partial class EditUser : MvpPage<EditUserViewModel>, IEditUserView
    {
        private int userId;
        public event EventHandler<GetUserByIdEventArgs> DeleteUser;
        public event EventHandler<EditUserEventArgs> UserEdit;
        public event EventHandler<GetUserByIdEventArgs> GetUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.TryParse(this.Request.QueryString["id"], out userId))
            {
                this.GetUser?.Invoke(sender, new GetUserByIdEventArgs(userId));
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (userId != 0)
            {
                var editUser = new EditUserEventArgs(userId);
                editUser.FirstName = this.TextBoxFirstName.Text;
                editUser.LastName = this.TextBoxLastName.Text;
                editUser.UserName = this.TextBoxUserName.Text;
                editUser.PhoneNumber = this.TextBoxPhone.Text;
                editUser.Email = this.TextBoxEmail.Text;
                editUser.City = this.TextBoxCity.Text;
                editUser.Address = this.TextBoxAddress.Text;
                this.UserEdit?.Invoke(sender, editUser);
                Response.Redirect("~/users/all");
            }         
        }
    }
}