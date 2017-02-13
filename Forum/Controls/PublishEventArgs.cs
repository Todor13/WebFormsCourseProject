using System;

namespace Forum.Controls
{
    public class PublishEventArgs : EventArgs
    {
        public string PublishText { get; set; }

        public PublishEventArgs(string text)
        {
            this.PublishText = text;
        }
    }
}