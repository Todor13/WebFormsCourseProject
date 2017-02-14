using Forum.Views;
using Forum.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using Forum.Views.Events;
using WebFormsMvp;
using Forum.Presenters;

namespace Forum.Forum
{
    [PresenterBinding(typeof(SearchForumPresenter))]
    public partial class Search : MvpPage<SearchForumViewModel>, ISearchForumView
    {
        public event EventHandler<SearchForumEventArgs> SearchThreads;

        protected void Page_Load(object sender, EventArgs e)
        {
            var searchTerm = this.Request.QueryString["query"];
            int page;

            if (int.TryParse(this.Request.QueryString["page"], out page))
            {
                this.SearchThreads?.Invoke(sender, new SearchForumEventArgs(searchTerm ,page));
            }
            else
            {
                this.SearchThreads?.Invoke(sender, new SearchForumEventArgs(searchTerm, 1));
            }

            var pagerSizeArray = new int[this.Model.PageCount];
            this.ThreadsPreview.ThreadsDataSource = this.Model.Threads;
            this.ThreadsPreview.PagerSize = pagerSizeArray;
            this.ThreadsPreview.DataBind();
        }

        protected void ThreadsPreview_SearchButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/forum/search?query=" + this.ThreadsPreview.SearchTerm);
        }

    }
}