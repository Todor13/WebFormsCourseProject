using System.Linq;

namespace Forum.Data.Repositories
{
    public interface ICommentsRepository
    {
        void Dispose();
        IQueryable<Comment> GetAnswersByThread(Answer answer);
        void CreateComment(Comment comment);
    }
}