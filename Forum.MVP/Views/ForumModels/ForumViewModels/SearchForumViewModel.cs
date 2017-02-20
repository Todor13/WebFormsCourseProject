using Forum.Data;
using System.Collections.Generic;

namespace Forum.Views.Models
{
    public class SearchForumViewModel
    {
        public IEnumerable<Thread> Threads { get; set; }
        public int PageCount { get; set; }
    }
}