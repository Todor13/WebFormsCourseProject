using Forum.Presenters;
using Forum.Views;
using Forum.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using Forum.Views.Events;

namespace Forum.Forum
{
    [PresenterBinding(typeof(ForumHomePresenter))]
    public partial class Home : MvpPage<ForumHomeViewModel>, IForumHomeView
    {
        public event EventHandler<ForumHomeEventArgs> LoadPage;

        protected void Page_Load(object sender, EventArgs e)
        {

            int page;

            if (int.TryParse(this.Request.QueryString["page"], out page))
            {
                this.LoadPage?.Invoke(sender, new ForumHomeEventArgs(page));
            }
            else
            {
                this.LoadPage?.Invoke(sender, new ForumHomeEventArgs());
            }

            var pagerSizeArray = new int[this.Model.PageCount];
            this.ThreadsPreview.ThreadsDataSource = this.Model.Threads;
            this.ThreadsPreview.PagerSize = pagerSizeArray;
            this.ThreadsPreview.DataBind();
        }

        protected void ThreadsPreview_SearchButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Forum/Search?query=" + this.ThreadsPreview.SearchTerm);
        }
    }
}