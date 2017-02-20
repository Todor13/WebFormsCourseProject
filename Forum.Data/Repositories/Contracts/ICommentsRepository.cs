using System.Linq;

namespace Forum.Data.Repositories
{
    public interface ICommentsRepository
    {      
        IQueryable<Comment> GetCommentsByAnswer(Answer answer);
        void CreateComment(Comment comment);
        Comment GetCommentById(int id);
        void UpdateComment(Comment comment);
        void Dispose();
    }
}