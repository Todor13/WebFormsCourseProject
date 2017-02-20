using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Views.Events.ForumEvents.EditEvents
{
    public class ThreadEditEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Section { get; set; }

        public ThreadEditEventArgs(string title, string content, string section)
        {
            this.Title = title;
            this.Content = content;
            this.Section = section;
        }
    }
}