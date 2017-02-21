using Forum.Data;
using System.Collections;
using System.Collections.Generic;

namespace Forum.MVP.Views.ForumModels
{
    public class HomeViewModel
    {
        public IEnumerable<Thread> NewestThreads { get; set; }
        public IEnumerable<Thread> MostDiscussedThreads { get; set; }
        public IEnumerable<Thread> ImportantThreads { get; set; }
    }
}
