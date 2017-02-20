using Forum.Presenters.ForumPresenters.EditPresenters;
using Forum.Views.ForumModels.ForumViewModels.EditViewModels;
using Forum.Views.ForumViews.EditViews;
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
            var id = Page.RouteData.Values["id"];
            int answerId;

            answerId = Convert.ToInt32(id);
            this.GetAnswer?.Invoke(sender, new GetByIdEventArgs(answerId));
            
        }

        protected void LinkButtonSave_Click(object sender, EventArgs e)
        {
            var content = this.TextBoxAnswerContent.Text;
            this.EditAnswer?.Invoke(sender, new ContentEventArgs(content));
            Response.Redirect("~/forum/threads/" + Model.Answer.ThreadId);
        }
    }
}