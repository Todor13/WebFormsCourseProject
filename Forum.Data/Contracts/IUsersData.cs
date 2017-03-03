using Forum.Data.Repositories.Contracts;

namespace Forum.Data
{
    public interface IUsersData
    {
        IUsersRepository UsersRepository { get; }

        void Dispose();
        void Save();
    }
}