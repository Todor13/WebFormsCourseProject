using System;

namespace Forum.MVP.Views.UserViews
{
    public class GetUserByIdEventArgs : EventArgs
    {
        public int Id { get; set; }

        public GetUserByIdEventArgs(int id)
        {
            this.Id = id;
        }
    }
}