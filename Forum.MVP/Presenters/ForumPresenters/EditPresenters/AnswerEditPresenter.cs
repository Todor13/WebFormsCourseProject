using Forum.Data;
using Forum.Views.ForumViews.EditViews;
using System;
using System.Web;
using WebFormsMvp;

namespace Forum.Presenters.ForumPresenters.EditPresenters
{
    public class AnswerEditPresenter : Presenter<IAnswerEditView>
    {
        private readonly IForumData forumData;
        private Answer currentAnswer;

        public AnswerEditPresenter(IAnswerEditView view, IForumData forumData) : base(view)
        {
            this.forumData = forumData;

            this.View.GetAnswer += GetAnswer;
            this.View.EditAnswer += EditAnswer;
        }

        private void EditAnswer(object sender, ContentEventArgs e)
        {
            //if (HttpContext.User.Identity.GetUserId<int>() != this.currentAnswer.UserId &&
            //  !HttpContext.User.IsInRole("admin"))
            //{
            //    HttpContext.Response.Redirect("~/Errors/ErrorPage", true);
            //    return;
            //}

            var content = e.Content.Trim();

            if (content.Length > Common.GlobalConstants.ContentMinLength &&
                content.Length < Common.GlobalConstants.ContentMaxLength)
            {
                this.currentAnswer.Contents = content;
            }
            else
            {
               // HttpContext.Response.Redirect("~/Errors/ErrorPage", true);
                return;
            }

            try
            {
                this.forumData.AnswersRepository.UpdateAnswer(this.currentAnswer);
                this.forumData.Save();
            }
            catch (Exception)
            {
                //throw new HttpException(500, "Internal Server Error");
            }
        }

        private void GetAnswer(object sender, GetByIdEventArgs e)
        {
            var answer = this.forumData.AnswersRepository.GetAnswerById(e.Id);

            //if (answer.IsVisible == true && answer.UserId == HttpContext.User.Identity.GetUserId<int>())
            //{
            //    this.View.Model.Answer = answer;
            //    this.currentAnswer = answer;
            //}
            //else if (HttpContext.User.IsInRole("admin"))
            //{
            //    this.View.Model.Answer = answer;
            //    this.currentAnswer = answer;
            //}
            //else
            //{
            //    throw new HttpException(404, "Not found");
            //}
        }
    }
}