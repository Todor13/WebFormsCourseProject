using System;
using System.Linq;

namespace Forum.Data.Repositories
{
    public interface IThreadsRepository : IDisposable
    {
        IQueryable<Thread> GetAllThreads();
        void CreateThread(Thread thread);
        Thread GetThreadById(int id);
        void UpdateThread(Thread thread);
    }
}
