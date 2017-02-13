using Forum.Data;
using Forum.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace Forum.Presenters
{
    public class SearchForumPresenter : Presenter<ISearchForumView>
    {
        private const int PageSize = Common.Constants.PageSize;

        private IForumData forumData;

        public SearchForumPresenter(ISearchForumView view, IForumData forumData) : base(view)
        {
            this.forumData = forumData;

            this.View.SearchThreads += SearchThreads;
        }

        private void SearchThreads(object sender, Views.Events.SearchForumEventArgs e)
        {
            this.View.Model.Threads = GetThreadsBySearchTerm(e.SearchTerm, e.PageId);
        }

        private IEnumerable<Thread> GetThreadsBySearchTerm(string searchTerm, int id = 1, int pageSize = PageSize)
        {
            var threadsCount = forumData.ThreadsRepository.GetAllThreads().Count(x => x.IsVisible &&
            x.Title.Contains(searchTerm) || x.Contents.Contains(searchTerm));

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
                    .Where(x => x.IsVisible && x.Title.Contains(searchTerm) || x.Contents.Contains(searchTerm))
                    .OrderByDescending(x => x.Published)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }

            return threads;
        }
    }
}