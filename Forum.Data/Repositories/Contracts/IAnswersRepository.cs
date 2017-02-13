using System.Linq;

namespace Forum.Data.Repositories
{
    public interface IAnswersRepository
    {
        void Dispose();
        IQueryable<Answer> GetAnswersByThread(Thread thread);
        IQueryable<Answer> GetAnswersByThreadId(int id);
        Answer GetAnswerById(int id);
    }
}