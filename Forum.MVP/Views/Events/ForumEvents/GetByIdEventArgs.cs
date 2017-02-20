namespace Forum.Views.ForumViews.EditViews
{
    public class GetByIdEventArgs
    {
        public int Id { get; set; }

        public GetByIdEventArgs(int id)
        {
            this.Id = id;
        }
    }
}