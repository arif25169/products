using Autofac;
using ProductsDomain.Orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDomain.IoC
{
    public class OrmModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdventureWorksContext>()
              .AsSelf()
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();
        }
    }
}