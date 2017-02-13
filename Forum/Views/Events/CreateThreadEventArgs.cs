using System;

namespace Forum.Views.Events
{
    public class CreateThreadEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Section { get; set; }

        public CreateThreadEventArgs(string title, string content, string section)
        {
            this.Title = title;
            this.Content = content;
            this.Section = section;
        }
    }
}