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
        private IUsersRepository usersRepository;

        public AllUsersPresenter(IView<AllUsersViewModel> view, IUsersRepository usersRepository) : base(view)
        {
            this.usersRepository = usersRepository;

            this.View.Load += Load;
        }

        private void Load(object sender, EventArgs e)
        {
            this.View.Model.Users = this.usersRepository.GetAllUsers().ToArray();
        }
    }
}
