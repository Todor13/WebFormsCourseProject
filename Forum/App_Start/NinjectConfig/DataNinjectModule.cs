using Forum.Data;
using Forum.Data.Repositories;
using Forum.Data.Repositories.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.App_Start.NinjectConfig
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<ForumDbContext>().InRequestScope();
            //this.Bind<IThreadsRepository>().To<ThreadsRepository>();
            //this.Bind<ISectionsRepository>().To<SectionsRepository>();
            //this.Bind<IAnswersRepository>().To<AnswersRepository>();
            //this.Bind<ICommentsRepository>().To<CommentsRepository>();
            //this.Bind<IForumData>().To<ForumData>();
        }
    }
}