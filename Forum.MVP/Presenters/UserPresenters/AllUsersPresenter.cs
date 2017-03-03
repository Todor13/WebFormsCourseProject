using Forum.Data;
using Forum.Data.Repositories.Contracts;
using Forum.MVP.Views.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace Forum.MVP.Presenters.UserPresenters
{
    public class AllUsersPresenter : Presenter<IView<AllUsersViewModel>>
    {
        private IUsersData usersData;

        public AllUsersPresenter(IView<AllUsersViewModel> view, IUsersData usersData) : base(view)
        {
            this.usersData = usersData;

            this.View.Load += Load;
        }

        private void Load(object sender, EventArgs e)
        {
            this.View.Model.Users = this.usersData.UsersRepository.GetAllUsers().ToArray();
        }
    }
}
