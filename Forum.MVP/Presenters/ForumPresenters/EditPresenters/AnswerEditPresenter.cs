using Forum.Common;
using Forum.Data;
using Forum.MVP.Helpers;
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
            var content = e.Content.Trim();

            if (Validator.IsContentValid(content))
            {
                this.currentAnswer.Contents = content;
            }
            else
            {
                this.View.Model.Error = $"Content must be between {GlobalConstants.ContentMinLength} and {GlobalConstants.ContentMaxLength} characters long!";
                return;
            }

            try
            {
                this.forumData.AnswersRepository.UpdateAnswer(this.currentAnswer);
                this.forumData.Save();
            }
            catch (Exception)
            {
                this.View.Model.Error = "Something went wrong!";
                return;
            }
        }

        private void GetAnswer(object sender, GetByIdEventArgs e)
        {
            var answer = this.forumData.AnswersRepository.GetAnswerById(e.Id);

            if (answer.IsVisible == true)
            {
                this.View.Model.Answer = answer;
                this.currentAnswer = answer;
            }
            else
            {
                this.View.Model.Error = "File not found!";
                return;
            }
        }
    }
}