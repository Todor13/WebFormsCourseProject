using Forum.Presenters.ForumPresenters.EditPresenters;
using Forum.Views.ForumModels.ForumViewModels.EditViewModels;
using Forum.Views.ForumViews.EditViews;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Forum.Forum.Edit
{
    [PresenterBinding(typeof(AnswerEditPresenter))]
    public partial class AnswerEdit : MvpPage<AnswerEditViewModel>, IAnswerEditView
    {
        public event EventHandler<ContentEventArgs> EditAnswer;
        public event EventHandler<GetByIdEventArgs> GetAnswer;

        protected void Page_Load(object sender, EventArgs e)
        {
            var answerId = GetCurrentId();
            this.GetAnswer?.Invoke(sender, new GetByIdEventArgs(answerId));
        }

        protected void LinkButtonSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (User.Identity.GetUserId<int>() != this.Model.Answer.UserId &&
                !User.IsInRole("admin"))
                {
                    throw new HttpException(404, "File not found!");
                }

                var answerId = GetCurrentId();
                var content = this.TextBoxAnswerContent.Text;
                this.EditAnswer?.Invoke(sender, new ContentEventArgs(answerId, content));

                if (Model.Error == null)
                {
                    Response.Redirect("~/forum/threads/" + Model.Answer.ThreadId);
                }
            }            
        }

        private int GetCurrentId()
        {
            int Id;
            var id = Page.RouteData.Values["id"];
            try
            {
                Id = Convert.ToInt32(id);
                return Id;
            }
            catch (Exception)
            {
                throw new HttpException(404, "File Not Found!");
            }
        }
    }
}