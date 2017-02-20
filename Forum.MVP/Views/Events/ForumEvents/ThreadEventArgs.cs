using System;

namespace Forum.Views.Events
{
    public class ThreadEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Section { get; set; }
        public int UserId { get; set; }

        public ThreadEventArgs(string title, string content, string section, int userId)
        {
            this.Title = title;
            this.Content = content;
            this.Section = section;
            this.UserId = userId;
        }
    }
}