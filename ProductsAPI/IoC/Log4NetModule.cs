using Autofac;
using Autofac.Core;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsAPI.IoC
{
    public class Log4NetModule : Module
    {
        private static void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            e.Parameters = e.Parameters.Union(
              new[]
              {
          new ResolvedParameter(
            (p, i) => p.ParameterType == typeof (ILog),
            (p, i) => LogManager.GetLogger(e.Component.Activator.LimitType))
              });
        }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing += OnComponentPreparing;
        }
    }
}