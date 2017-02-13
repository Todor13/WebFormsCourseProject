using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Repositories
{
    public interface IThreadsRepository : IDisposable
    {
        IQueryable<Thread> GetAllThreads();
        void CreateThread(Thread thread);
        Thread GetThreadById(int id);
    }
}
