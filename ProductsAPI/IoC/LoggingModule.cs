using System.Linq;
using Autofac;
using Autofac.Core;
using System.Web.Http.ExceptionHandling;
using log4net.Core;
using log4net;

namespace ProductsAPI.IoC
{
    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApiExceptionLogger>().As<IExceptionLogger>();
        }

        protected override void AttachToComponentRegistration(
            IComponentRegistry registry, IComponentRegistration registration)
        {
            registration.Preparing += AddLoggerParameter;
        }

        private static void AddLoggerParameter(object sender, PreparingEventArgs e)
        {
            var logParameter = new ResolvedParameter(
                (p, i) => p.ParameterType == typeof(ILogger),
                (p, i) => LogManager.GetLogger(e.Component.Activator.LimitType.FullName));

            e.Parameters = e.Parameters.Concat(new[] { logParameter });
        }
    }
}