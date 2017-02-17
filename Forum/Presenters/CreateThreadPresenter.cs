using Forum.Data;
using Forum.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;
using Microsoft.AspNet.Identity;
using Forum.Views.Events;
using System.IO;

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

        private void Create(object sender, CreateThreadEventArgs e)
        {
            var thread = new Thread();

            try
            {
                thread.Section = this.forumData.SectionsRepository.GetSectionByName(e.Section);
            }
            catch (Exception)
            {
                HttpContext.Server.Transfer("NoFileErrorPage", true);
                return;
            }
            
            var userId = HttpContext.User.Identity.GetUserId<int>();

            if (userId != 0)
            {
                thread.UserId = userId;
            }
            else
            {
                HttpContext.Server.Transfer("Login", true);
                return;
            }

            var content = e.Content.Trim();

            if (content.Length > Common.Constants.ContentMinLength &&
                content.Length < Common.Constants.ContentMaxLength)
            {
                thread.Contents = content;
            }
            else
            {
                HttpContext.Server.Transfer("ErrorPage", true);
                return;
            }

            var title = e.Title.Trim();

            if (title.Length > Common.Constants.TitleMinLength &&
                title.Length < Common.Constants.TitleMaxLength)
            {
                thread.Title = title;
            }
            else
            {
                HttpContext.Server.Transfer("ErrorPage", true);
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
                HttpContext.Server.Transfer("500", true);
            } 
        }
    }
}