using System.Web.Http.Validation;
using Autofac;
using Autofac.Integration.WebApi;
using FluentValidation;
using FluentValidation.WebApi;

namespace ProductsAPI.IoC
{
    public class ValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                   .Where(t => t.Name.EndsWith("Validator"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterType<FluentValidationModelValidatorProvider>().As<ModelValidatorProvider>();

            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().SingleInstance();

            base.Load(builder);
        }
    }
}