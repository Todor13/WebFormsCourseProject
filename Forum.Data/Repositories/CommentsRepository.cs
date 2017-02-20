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

        public IQueryable<Comment> GetCommentsByAnswer(Answer answer)
        {
            return this.All().Where(x => x.Answer == answer).AsQueryable();
        }

        public void CreateComment(Comment comment)
        {
            this.Add(comment);
        }

        public Comment GetCommentById(int id)
        {
            return this.GetById(id);
        }

        public void UpdateComment(Comment comment)
        {
            this.Update(comment);
        }

        public void Dispose()
        {
        }
    }
}
