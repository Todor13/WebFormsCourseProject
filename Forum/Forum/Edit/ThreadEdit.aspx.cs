using Forum.Views.ForumViews.EditViews;
using Forum.Views.Models.ForumViewModels.EditViewModels;
using System;
using System.Web.UI;
using WebFormsMvp.Web;
using Forum.Views.Events;
using WebFormsMvp;
using Forum.Presenters.EditPresenters;
using Forum.Views.Events.ForumEvents.EditEvents;
using Microsoft.AspNet.Identity;
using System.Web;

namespace Forum.Forum.Edit
{
    [PresenterBinding(typeof(ThreadEditPresenter))]
    public partial class ThreadEdit : MvpPage<ThreadEditViewModel>, IThreadEditView
    {
        public event EventHandler<ThreadEditEventArgs> EditThread;
        public event EventHandler<GetByIdEventArgs> GetThread;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserId<int>() != this.Model.Thread.UserId &&
                !User.IsInRole("admin"))
            {
                throw new HttpException(404, "File not found!");
            }
            else
            {
                var id = Page.RouteData.Values["id"];
                int threadId;

                threadId = Convert.ToInt32(id);
                this.GetThread?.Invoke(sender, new GetByIdEventArgs(threadId));
            }

            //todo dropdown selecteditem
        }

        protected void LinkButtonSave_Click(object sender, EventArgs e)
        {
            var title = this.TextBoxThreadTitle.Text;
            var content = this.TextBoxThreadContent.Text;
            var section = this.DropDownListSections.SelectedItem.Text;
            this.EditThread?.Invoke(sender, new ThreadEditEventArgs(title, content, section));
            Response.Redirect("~/forum/threads/" + Page.RouteData.Values["id"]);
        }
    }
}