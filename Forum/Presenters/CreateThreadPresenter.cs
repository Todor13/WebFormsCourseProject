using Forum.Data;
using Forum.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;
using Microsoft.AspNet.Identity;
using Forum.Views.Events;

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
            var sectionNames = new List<string>();
            foreach (var section in sections)
            {
                this.View.Model.Sections.Add(section.Name);
            }
        }

        private void Create(object sender, CreateThreadEventArgs e)
        {
            var thread = new Thread();

            var section = this.forumData.SectionsRepository.GetSectionByName(e.Section);
            thread.Section = section;
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId<int>();
            thread.UserId = userId;
            thread.Contents = e.Content;
            thread.Title = e.Title;
            thread.Published = DateTime.UtcNow;
            thread.IsVisible = true;
            

            this.forumData.ThreadsRepository.CreateThread(thread);
            this.forumData.Save();
        }
    }
}