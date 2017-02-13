using Forum.Presenters;
using Forum.Views;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using Forum.Views.Events;
using Forum.Views.Models;

namespace Forum.Forum
{
    [PresenterBinding(typeof(CreateThreadPresenter))]
    public partial class CreateThread : MvpPage<CreateThreadViewModel>, ICreateThreadView
    {
        public event EventHandler<CreateThreadEventArgs> Create;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var title = this.TextBoxTitle.Text;
            var content = this.TextBoxContent.Text;
            var section = this.DropDownSections.SelectedItem.Text;

            this.Create?.Invoke(sender, new CreateThreadEventArgs(title, content, section));
        }
    }
}