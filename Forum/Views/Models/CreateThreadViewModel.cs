using System.Collections.Generic;

namespace Forum.Views.Models
{
    public class CreateThreadViewModel
    {
        public IList<string> Sections { get; private set; }

        public CreateThreadViewModel()
        {
            this.Sections = new List<string>();
        }
    }
}