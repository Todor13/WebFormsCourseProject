using Forum.MVP.Presenters;
using Forum.MVP.Views.ForumModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Forum
{
    [PresenterBinding(typeof(HomePresenter))]
    public partial class _Default : MvpPage<HomeViewModel>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}