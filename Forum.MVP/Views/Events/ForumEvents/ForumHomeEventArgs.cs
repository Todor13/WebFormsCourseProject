using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Views.Events
{
    public class ForumHomeEventArgs
    {
        public int PageId { get; set; }

        public ForumHomeEventArgs(int pageId = 1)
        {
            this.PageId = pageId;
        }
    }
}