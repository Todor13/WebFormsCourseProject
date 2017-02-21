namespace Forum.Views.ForumViews.EditViews
{
    public class ContentEventArgs
    {
        public string Content { get; set; }
        public int Id { get; set; }

        public ContentEventArgs(int id ,string content)
        {
            this.Content = content;
            this.Id = id;
        }
    }
}