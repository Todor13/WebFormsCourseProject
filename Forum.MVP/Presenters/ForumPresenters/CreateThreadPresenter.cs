using Forum.Data;
using Forum.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;
using Forum.Views.Events;
using Forum.Common;
using Forum.MVP.Helpers;

namespace Forum.Presenters
{
    public class CreateThreadPresenter : Presenter<ICreateThreadView>
    {
        private IForumData forumData;

        public CreateThreadPresenter(ICreateThreadView view, IForumData forumData) : base(view)
        {
            this.forumData = forumData;

            this.View.Create += Create;
            this.View.Load += Load;
        }

        private void Load(object sender, EventArgs e)
        {
            IList<Section> sections = this.forumData.SectionsRepository.GetAllSections().ToList();

            foreach (var section in sections)
            {
                this.View.Model.Sections.Add(section.Name);
            }
        }

        private void Create(object sender, ThreadEventArgs e)
        {
            var thread = new Thread();

            try
            {
                thread.Section = this.forumData.SectionsRepository.GetSectionByName(e.Section);
            }
            catch (Exception)
            {
                this.View.Model.Error = "Something went wrong!";
            }

            var userId = e.UserId;

            if (userId != 0)
            {
                thread.UserId = e.UserId;
            }
            else
            {
                this.View.Model.Error = "Please, log in!";
                return;
            }
  
            var content = e.Content.Trim();

            if (Validator.IsContentValid(content))
            {
                thread.Contents = content;
            }
            else
            {
                this.View.Model.Error = $"Content must be between {GlobalConstants.ContentMinLength} and {GlobalConstants.ContentMaxLength} characters long!";
                return;
            }

            var title = e.Title.Trim();

            if (Validator.IsTitleValid(title))
            {
                thread.Title = title;
            }
            else
            {
                this.View.Model.Error = $"Title must be between {GlobalConstants.TitleMinLength} and {GlobalConstants.TitleMaxLength} characters long!";
                return;
            }
            
            thread.Published = DateTime.UtcNow;
            thread.IsVisible = true;

            try
            {
                this.forumData.ThreadsRepository.CreateThread(thread);
                this.forumData.Save();
            }
            catch (Exception)
            {
                this.View.Model.Error = "Something went wrong!";
                return;
            } 
        }
    }
}