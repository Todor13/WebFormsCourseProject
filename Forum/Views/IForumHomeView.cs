using Forum.Views.Events;
using Forum.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace Forum.Views
{
    public interface IForumHomeView : IView<ForumHomeViewModel>
    {
        event EventHandler<ForumHomeEventArgs> LoadPage;
    }
}
