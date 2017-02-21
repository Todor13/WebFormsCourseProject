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
        private readonly IUsersRepository usersRepository;
        private AspNetUser currentUser;

        public EditUserPresenter(IEditUserView view, IUsersRepository usersRepository) : base(view)
        {
            this.usersRepository = usersRepository;

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

            if (e.FirstName != null)
            {
                this.currentUser.FirstName = e.FirstName;
            }

            if (e.LastName != null)
            {
                this.currentUser.LastName = e.LastName;
            }

            if (e.PhoneNumber != null)
            {
                this.currentUser.PhoneNumber = e.PhoneNumber;
            }

            if (e.PostalCode != null)
            {
                this.currentUser.PostalCode = e.PostalCode;
            }

            if (e.State != null)
            {
                this.currentUser.State = e.State;
            }

            if (e.UserName != null)
            {
                this.currentUser.UserName = e.UserName;
            }

            if (e.Email != null)
            {
                this.currentUser.Email = e.Email;
            }

            if (e.City != null)
            {
                this.currentUser.City = e.City;
            }

            if (e.Address != null)
            {
                this.currentUser.Address = e.Address;
            }

            try
            {
                this.usersRepository.UpdateUser(this.currentUser);
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
                user = this.usersRepository.GetUserById(e.Id);
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
