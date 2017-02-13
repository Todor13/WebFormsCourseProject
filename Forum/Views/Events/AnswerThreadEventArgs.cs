using System;

namespace Forum.Views.Events
{
    public class AnswerThreadEventArgs : EventArgs
    {
        public string Content { get; set; }
        public int Id { get; set; }

        public AnswerThreadEventArgs(string content, int id)
        {
            this.Content = content;
            this.Id = id;
        }
    }
}