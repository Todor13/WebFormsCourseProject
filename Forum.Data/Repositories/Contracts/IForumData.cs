using Forum.Data.Repositories;

namespace Forum.Data
{
    public interface IForumData
    {
        IAnswersRepository AnswersRepository { get; }
        ICommentsRepository CommentsRepository { get; }
        ISectionsRepository SectionsRepository { get; }
        IThreadsRepository ThreadsRepository { get; }

        void Dispose();
        void Save();
    }
}