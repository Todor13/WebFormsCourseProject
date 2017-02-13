using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Views.Events
{
    public class GetThreadEventArgs : EventArgs
    {
        public int Id { get; set; }

        public GetThreadEventArgs(int id)
        {
            this.Id = id;
        }
    }
}