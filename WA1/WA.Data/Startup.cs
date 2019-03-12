using Autofac;
using WA.Data.Core;
using WA.Data.Core.Interfaces;
using WA.Data.Interfaces;
using WA.Data.Repositories;

namespace WA.Data
{
    public static class Startup
    {
        private static string _connectionString;

        /// <summary>
        /// startup configuration for dependency injection
        /// </summary>
        /// <param name="builder">container for autofac</param>
        /// <param name="connectionString">string for connection on db</param>
        /// <param name="connectionStringEdmx">string for connection on entity</param>
        public static void Configure(ContainerBuilder builder, string connectionString, string connectionStringEdmx)
        {
            _connectionString = connectionString;

            //using Autofac to 
            //register interfaces 
            builder.RegisterType<ContextFactory>().As<IContextFactory>()
                .InstancePerLifetimeScope()
                .WithParameter("cnString", connectionStringEdmx);

            builder.RegisterType<UserCredRepository>().As<IUserCredRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
