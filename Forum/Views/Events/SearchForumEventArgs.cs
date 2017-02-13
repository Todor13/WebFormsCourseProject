using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Views.Events
{
    public class SearchForumEventArgs : EventArgs
    {
        public string SearchTerm { get; set; }
        public int PageId { get; set; }

        public SearchForumEventArgs(string searchTerm, int pageId)
        {
            this.SearchTerm = searchTerm;
            this.PageId = pageId;
        }
    }
}