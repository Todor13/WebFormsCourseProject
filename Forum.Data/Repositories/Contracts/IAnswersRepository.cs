using System.Linq;

namespace Forum.Data.Repositories
{
    public interface IAnswersRepository
    {
        IQueryable<Answer> GetAnswersByThread(Thread thread);
        IQueryable<Answer> GetAnswersByThreadId(int id);
        Answer GetAnswerById(int id);
        void CreateAnswer(Answer answer);
        void UpdateAnswer(Answer answer);
        void Dispose();
    }
}