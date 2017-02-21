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
        public int ThreadId { get; set; }

        public ThreadEditEventArgs(string title, string content, string section, int threadId)
        {
            this.Title = title;
            this.Content = content;
            this.Section = section;
            this.ThreadId = threadId;
        }
    }
}