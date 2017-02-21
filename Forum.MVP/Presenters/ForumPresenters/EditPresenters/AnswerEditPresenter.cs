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

        public AnswerEditPresenter(IAnswerEditView view, IForumData forumData) : base(view)
        {
            this.forumData = forumData;

            this.View.GetAnswer += GetAnswer;
            this.View.EditAnswer += EditAnswer;
        }

        private void EditAnswer(object sender, ContentEventArgs e)
        {
            Answer answer;

            try
            {
                answer = this.forumData.AnswersRepository.GetAnswerById(e.Id);
            }
            catch (Exception)
            {
                throw new HttpException(500, "Internal Server Error");
            }

            var content = e.Content.Trim();

            if (Validator.IsContentValid(content))
            {
                answer.Contents = content;
            }
            else
            {
                this.View.Model.Error = $"Content must be between {GlobalConstants.ContentMinLength} and {GlobalConstants.ContentMaxLength} characters long!";
                return;
            }

            try
            {
                this.forumData.AnswersRepository.UpdateAnswer(answer);
                this.forumData.Save();
            }
            catch (Exception)
            {
                throw new HttpException(500, "Internal Server Error");
            }
        }

        private void GetAnswer(object sender, GetByIdEventArgs e)
        {
            var answer = this.forumData.AnswersRepository.GetAnswerById(e.Id);

            if (answer.IsVisible == true)
            {
                this.View.Model.Answer = answer;
            }
            else
            {
                this.View.Model.Error = "File not found!";
                return;
            }
        }
    }
}