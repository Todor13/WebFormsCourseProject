using System;

namespace Forum.Views
{
    public class CommentAnswerEventArgs : EventArgs
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public CommentAnswerEventArgs(int id, string content)
        {
            this.Id = id;
            this.Content = content;
        }   
    }
}