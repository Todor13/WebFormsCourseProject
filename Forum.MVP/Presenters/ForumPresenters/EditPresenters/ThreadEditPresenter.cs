﻿using Forum.Common;
using Forum.Data;
using Forum.MVP.Helpers;
using Forum.Views.Events.ForumEvents.EditEvents;
using Forum.Views.ForumViews.EditViews;
using System;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace Forum.Presenters.EditPresenters
{
    public class ThreadEditPresenter : Presenter<IThreadEditView>
    {
        private readonly IForumData forumData;

        public ThreadEditPresenter(IThreadEditView view, IForumData forumData) : base(view)
        {
            this.forumData = forumData;

            this.View.GetThread += GetThread;
            this.View.EditThread += EditThread;
        }

        private void EditThread(object sender, ThreadEditEventArgs e)
        {
            Thread thread;

            try
            {
                thread = this.forumData.ThreadsRepository.GetThreadById(e.ThreadId);
            }
            catch (Exception)
            {
                throw new HttpException(500, "Internal Server Error");
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

            Section section;
            var editedSection = e.Section;

            try
            {
                section = this.forumData.SectionsRepository.GetSectionByName(editedSection);
            }
            catch (Exception)
            {
                throw new HttpException(500, "Internal Server Error");
            }

            if (section != null)
            {
                thread.Section = section;
            }

            try
            {
                this.forumData.ThreadsRepository.UpdateThread(thread);
                this.forumData.Save();
            }
            catch (Exception)
            {
                throw new HttpException(500, "Internal Server Error");
            }
        }

        private void GetThread(object sender, GetByIdEventArgs e)
        {
            var thread = this.forumData.ThreadsRepository.GetThreadById(e.Id);

            if (thread.IsVisible == true)
            {
                this.View.Model.Thread = thread;
            }
            else
            {
                this.View.Model.Error = "File not found!";
                return;
            }

            var sections = this.forumData.SectionsRepository.GetAllSections().ToList();

            foreach (var section in sections)
            {
                this.View.Model.Sections.Add(section.Name);
            }
        }
    }
}