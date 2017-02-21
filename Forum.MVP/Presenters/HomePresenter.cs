using Forum.Common;
using Forum.Data;
using Forum.MVP.Views.ForumModels;
using System;
using System.Linq;
using WebFormsMvp;

namespace Forum.MVP.Presenters
{
    public class HomePresenter : Presenter<IView<HomeViewModel>>
    {
        private readonly IForumData forumData;

        public HomePresenter(IView<HomeViewModel> view, IForumData forumData) : base(view)
        {
            this.forumData = forumData;

            this.View.Load += Load;
        }

        private void Load(object sender, EventArgs e)
        {
            this.View.Model.NewestThreads = this.forumData.ThreadsRepository
                .GetAllThreads()
                .OrderByDescending(t => t.Published)
                .Take(GlobalConstants.DefaultPageThreadsCount)
                .ToArray();

            this.View.Model.MostDiscussedThreads = this.forumData.ThreadsRepository
                .GetAllThreads()
                .OrderByDescending(t => t.Answers.Count)
                .Take(GlobalConstants.DefaultPageThreadsCount)
                .ToArray();

            this.View.Model.ImportantThreads = this.forumData.ThreadsRepository
                .GetAllThreads()
                .Where(t => t.Section.Name == "Important")
                .OrderByDescending(x=>x.Published)
                .OrderByDescending(x => x.Answers.Max(a => a.Published))
                .Take(GlobalConstants.DefaultPageThreadsCount)
                .ToArray();
        }
    }
}
