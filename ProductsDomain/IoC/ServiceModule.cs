using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDomain.Ioc
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // register all services
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces();
        }
    }
}