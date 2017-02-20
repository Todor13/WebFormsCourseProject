using Forum.Presenters;
using Forum.Views;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using Forum.Views.Events;
using Forum.Views.Models;
using Microsoft.AspNet.Identity;

namespace Forum.Forum
{
    [PresenterBinding(typeof(CreateThreadPresenter))]
    public partial class CreateThread : MvpPage<CreateThreadViewModel>, ICreateThreadView
    {
        protected const int TitleMinLength = Common.Constants.TitleMinLength;
        protected const int TitleMaxLength = Common.Constants.TitleMaxLength;
        protected const int ContentMinLength = Common.Constants.ContentMinLength;
        protected const int ContentMaxLength = Common.Constants.ContentMaxLength;

        public event EventHandler<ThreadEventArgs> Create;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.TextBoxContent.Focus();
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var title = this.TextBoxTitle.Text;
                var content = this.TextBoxContent.Text;
                var section = this.DropDownSections.SelectedItem.Text;
                var userId = this.User.Identity.GetUserId<int>();

                if (userId != 0)
                {
                    this.Create?.Invoke(sender, new ThreadEventArgs(title, content, section, userId));
                    Response.Redirect("~/forum/home");
                }
                else
                {
                    Response.Redirect("~/account/login");
                } 
            }
        }
    }
}