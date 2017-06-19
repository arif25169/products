using System.Configuration;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using log4net.Config;

[assembly: OwinStartup(typeof(ProductsAPI.App_Start.Startup))]

namespace ProductsAPI.App_Start
{
    /// <summary>
    /// Represents the entry point into an application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Specifies how the ASP.NET application will respond to individual HTTP request.
        /// </summary>
        /// <param name="app">Instance of <see cref="IAppBuilder"/>.</param>
        public void Configuration(IAppBuilder app)
        {
            CorsConfig.ConfigureCors(ConfigurationManager.AppSettings["cors"]);
            app.UseCors(CorsConfig.Options);

            var configuration = new HttpConfiguration();

            AutofacConfig.Configure(configuration);
            app.UseAutofacMiddleware(AutofacConfig.Container);

            FormatterConfig.Configure(configuration);
            RouteConfig.Configure(configuration);
            ServiceConfig.Configure(configuration);

            app.UseWebApi(configuration);
        }
    }
}