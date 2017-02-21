using Forum.Data.Repositories.Base;
using Forum.Data.Repositories.Contracts;
using System.Collections;
using System.Linq;
using System.Data.Entity;
using System;

namespace Forum.Data.Repositories
{
    public class UsersRepository : GenericRepository<AspNetUser>, IUsersRepository, IDisposable
    {
        public UsersRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<AspNetUser> GetAllUsers()
        {
            return this.All();
        }

        public AspNetUser GetUserById(int id)
        {
            return this.GetById(id);
        }

        public void UpdateUser(AspNetUser user)
        {
            this.Update(user);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
