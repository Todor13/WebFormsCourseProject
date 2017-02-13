using Forum.Data;
using System.Collections.Generic;

namespace Forum.Views.Models
{
    public class ThreadViewModel
    {
        public Thread Thread { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}