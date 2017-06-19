using Autofac;
using Autofac.Integration.WebApi;
using ProductsAPI.Filters;
using System.Web.Http;

namespace ProductsAPI.IoC
{
    public class FiltersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbTransactionFilter>()
                .AsWebApiActionFilterFor<ApiController>()
                .InstancePerRequest();
        }
    }
}