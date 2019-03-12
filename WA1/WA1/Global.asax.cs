using Autofac;
using Autofac.Integration.Mvc;
using System.Web;
using WA.Service;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Reflection;
using Autofac.Integration.WebApi;

namespace WA1
{
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// application entry point
        /// here I register routes, bundles containerbuilder(autofac) and register controllers
        /// build container
        /// and resolve webapi dependencies
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            Startup.Configure(builder, AppSettings.ToServiceAppSettingsDto());

            RegisterAutofac(builder);

            var container = builder.Build();

            var webapiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webapiResolver;
        }

        private static void RegisterAutofac(ContainerBuilder builder)
        {

            RegisterControllers(builder);
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
        }
    }
}
