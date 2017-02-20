using Forum.Data;
using System.Collections.Generic;

namespace Forum.Views.Models
{
    public class ForumHomeViewModel
    {
        public IEnumerable<Thread> Threads { get; set; }
        public int PageCount { get; set; }
    }
}