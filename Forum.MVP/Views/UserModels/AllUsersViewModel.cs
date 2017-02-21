using Forum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.MVP.Views.UserModels
{
    public class AllUsersViewModel
    {
        public IEnumerable<AspNetUser> Users { get; set; }
    }
}
