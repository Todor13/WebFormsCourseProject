using Forum.Data;
using Forum.Data.Repositories.Contracts;
using Forum.MVP.Views.UserViews;
using System;
using System.Web;
using WebFormsMvp;

namespace Forum.MVP.Presenters.UserPresenters
{
    public class EditUserPresenter : Presenter<IEditUserView>
    {
        private readonly IUsersData usersData;
        private AspNetUser currentUser;

        public EditUserPresenter(IEditUserView view, IUsersData usersData) : base(view)
        {
            this.usersData = usersData;

            this.View.GetUser += GetUser;
            this.View.UserEdit += EditUser;
            this.View.DeleteUser += DeleteUser;
        }

        private void DeleteUser(object sender, GetUserByIdEventArgs e)
        {
            if (this.currentUser == null || this.currentUser.Id != e.Id)
            {
                throw new HttpException(404, "File Not Found!");
            }

            //ToDo
        }

        private void EditUser(object sender, EditUserEventArgs e)
        {
            if (this.currentUser == null || this.currentUser.Id != e.Id)
            {
                throw new HttpException(404, "File Not Found!");
            }

            if (e.FirstName != null && e.FirstName != string.Empty)
            {
                this.currentUser.FirstName = e.FirstName;
            }

            if (e.LastName != null && e.FirstName != string.Empty)
            {
                this.currentUser.LastName = e.LastName;
            }

            if (e.PhoneNumber != null && e.PhoneNumber != string.Empty)
            {
                this.currentUser.PhoneNumber = e.PhoneNumber;
            }

            if (e.PostalCode != null && e.PostalCode != string.Empty)
            {
                this.currentUser.PostalCode = e.PostalCode;
            }

            if (e.State != null && e.State != string.Empty)
            {
                this.currentUser.State = e.State;
            }

            if (e.UserName != null && e.UserName != string.Empty)
            {
                this.currentUser.UserName = e.UserName;
            }

            if (e.Email != null && e.Email != string.Empty)
            {
                this.currentUser.Email = e.Email;
            }

            if (e.City != null && e.City != string.Empty)
            {
                this.currentUser.City = e.City;
            }

            if (e.Address != null && e.Address != string.Empty)
            {
                this.currentUser.Address = e.Address;
            }

            try
            {
                this.usersData.UsersRepository.UpdateUser(this.currentUser);
                this.usersData.Save();
            }
            catch (Exception)
            {
                throw new HttpException(500, "Internal Server Error");
            }
        }

        private void GetUser(object sender, GetUserByIdEventArgs e)
        {
            AspNetUser user;

            try
            {
                user = this.usersData.UsersRepository.GetUserById(e.Id);
                this.View.Model.User = user;
                this.currentUser = user;
            }
            catch (Exception)
            {
                throw new HttpException(500, "Internal Server Error");
            }         
        }
    }
}
