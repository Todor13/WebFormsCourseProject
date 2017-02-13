using Forum.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Forum.Data.Repositories
{
    public class ThreadsRepository : GenericRepository<Thread>, IThreadsRepository, IDisposable
    {
        public ThreadsRepository(DbContext context) : base(context)
        {
        }

        public void CreateThread(Thread thread)
        {
            this.Add(thread);
        }

        public IQueryable<Thread> GetAllThreads()
        {
            return this.All();
        }

        public Thread GetThreadById(int id)
        {
            return this.GetById(id);
        }


        public void Dispose()
        {
        }
    }
}
