using Forum.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Forum.Data.Repositories
{
    public class CommentsRepository : GenericRepository<Comment>, IDisposable, ICommentsRepository
    {
        public CommentsRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Comment> GetAnswersByThread(Answer answer)
        {
            return this.All().Where(x => x.Answer == answer).AsQueryable();
        }

        public void Dispose()
        {
        }
    }
}
