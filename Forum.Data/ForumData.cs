using Forum.Data.Repositories;
using Forum.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class ForumData : IForumData, IDisposable
    {
        private DbContext context;
        private IAnswersRepository answersRepository;
        private ICommentsRepository commentsRepository;
        private ISectionsRepository sectionsRepository;
        private IThreadsRepository threadsRepository;

        public ForumData(DbContext context, IAnswersRepository answersRepository, ICommentsRepository commentsRepository,
                         ISectionsRepository sectionsRepository, IThreadsRepository threadsRepository)
        {
            this.context = context;
            this.answersRepository = answersRepository;
            this.commentsRepository = commentsRepository;
            this.sectionsRepository = sectionsRepository;
            this.threadsRepository = threadsRepository;
        }

        public IAnswersRepository AnswersRepository
        {
            get { return this.answersRepository; }
        }

        public ICommentsRepository CommentsRepository
        {
            get { return this.commentsRepository; }
        }

        public IThreadsRepository ThreadsRepository
        {
            get { return this.threadsRepository; }
        }

        public ISectionsRepository SectionsRepository
        {
            get { return this.sectionsRepository; }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context?.Dispose();
            }
        }
    }
}
