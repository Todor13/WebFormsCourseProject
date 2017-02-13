using Ninject.Modules;
using Ninject.Extensions.Conventions;
using System;
using System.Reflection;
using System.Linq;

namespace Forum.App_Start.NinjectConfig
{
    public class BasicNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x.FromThisAssembly()
            .SelectAllClasses()
            .BindAllInterfaces());

            this.Bind(x => x.From("Forum.Data")
           .SelectAllClasses()
           .BindAllInterfaces());
        }
    }
}