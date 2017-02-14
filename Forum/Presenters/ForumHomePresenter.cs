using Forum.Data;
using Forum.Views;
using Forum.Views.Events;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;

namespace Forum.Presenters
{
    public class ForumHomePresenter : Presenter<IForumHomeView>
    {
        private const int PageSize = Common.Constants.PageSize;

        private IForumData forumData;

        public ForumHomePresenter(IForumHomeView view, IForumData forumData) : base(view)
        {
            this.forumData = forumData;

            this.View.LoadPage += LoadPage;
        }

        private void LoadPage(object sender, ForumHomeEventArgs e)
        {
            this.View.Model.Threads = GetThreadsInRange(e.PageId);

        }

        private IEnumerable<Thread> GetThreadsInRange(int id = 1, int pageSize = PageSize)
        {
            var threadsCount = forumData.ThreadsRepository.GetAllThreads().Count(x => x.IsVisible);
            
            IEnumerable<Thread> threads;
            int page = 0;
            int pages = 0;

            if (threadsCount == 0)
            {
                threads = new List<Thread>();
            }
            else
            {
                if (threadsCount % pageSize == 0)
                {
                    pages = threadsCount / pageSize;
                }
                else
                {
                    pages = (threadsCount / pageSize) + 1;
                }

                if (id < 1)
                {
                    id = 1;
                }
                else if (id > pages)
                {
                    id = pages;
                }

                if (pageSize < 1)
                {
                    pageSize = 10;
                }

                page = id;

                this.View.Model.PageCount = threadsCount;

                threads = this.forumData.ThreadsRepository.GetAllThreads()
                    .Where(x => x.IsVisible)
                    .OrderByDescending(x => x.Published)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }

            return threads;
        }
    }
}