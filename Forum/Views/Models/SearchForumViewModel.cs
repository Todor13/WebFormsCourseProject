using Forum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Views.Models
{
    public class SearchForumViewModel
    {
        public IEnumerable<Thread> Threads { get; set; }
        public int PageCount { get; set; }
    }
}