using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Repositories.Contracts
{
    public interface IUsersRepository
    {
        IQueryable<AspNetUser> GetAllUsers();
        AspNetUser GetUserById(int id);
        void UpdateUser(AspNetUser user);
        void Dispose();
    }
}
