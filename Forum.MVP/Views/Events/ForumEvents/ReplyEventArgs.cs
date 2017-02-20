using System;

namespace Forum.Views.Events
{
    public class ReplyEventArgs : EventArgs
    {
        public string Content { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }

        public ReplyEventArgs(int id, int userId, string content)
        {
            this.Content = content;
            this.Id = id;
            this.UserId = userId;
        }
    }
}