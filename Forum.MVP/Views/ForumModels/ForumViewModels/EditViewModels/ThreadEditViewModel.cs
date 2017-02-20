using Forum.Data;
using System.Collections.Generic;

namespace Forum.Views.Models.ForumViewModels.EditViewModels
{
    public class ThreadEditViewModel
    {
        public Thread Thread { get; set; }
        public IList<string> Sections { get; set; }
        public string Error { get; set; }

        public ThreadEditViewModel()
        {
            this.Sections = new List<string>();
        }
    }
}