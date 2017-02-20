namespace Forum.Views.ForumViews.EditViews
{
    public class ContentEventArgs
    {
        public string Content { get; set; }

        public ContentEventArgs(string content)
        {
            this.Content = content;
        }
    }
}