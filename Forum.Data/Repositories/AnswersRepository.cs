using Forum.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Forum.Data.Repositories
{
    public class AnswersRepository : GenericRepository<Answer>, IDisposable, IAnswersRepository
    {
        public AnswersRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Answer> GetAnswersByThread(Thread thread)
        {
            return this.All().Where(x => x.Thread == thread).AsQueryable();
        }

        public IQueryable<Answer> GetAnswersByThreadId(int id)
        {
            return this.All().Where(x => x.ThreadId == id).AsQueryable();
        }

        public Answer GetAnswerById(int id)
        {
            return this.GetById(id);
        }

        public void AddAnswer(int id)
        {

        }

        public void Dispose()
        {
        }
    }
}
