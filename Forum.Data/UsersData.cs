using Forum.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class UsersData : IDisposable, IUsersData
    {
        private DbContext context;
        private IUsersRepository userRepository;

        public UsersData(DbContext context, IUsersRepository userRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
        }

        public IUsersRepository UsersRepository
        {
            get { return this.userRepository; }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context?.Dispose();
            }
        }
    }
}
