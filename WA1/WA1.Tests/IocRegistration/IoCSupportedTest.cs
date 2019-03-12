using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WA.Data.Interfaces;
using WA.Data.Repositories;


namespace WA1.Tests.IocRegistration
{
    public class IoCSupportedTest
    {
        private readonly IContainer _container;

        public IoCSupportedTest()
        {
            var builder = new ContainerBuilder();

            //creating fakes for test purposes, registration and building of container.
            builder.RegisterType<UserCredRepository>().As<IUserCredRepository>();

            _container = builder.Build();

            //resolvers for depencies
            var webapiResolver = new AutofacWebApiDependencyResolver(_container);
            GlobalConfiguration.Configuration.DependencyResolver = webapiResolver;
            
        }

        protected TEntity Resolve<TEntity>()
        {
            return _container.Resolve<TEntity>();
        }

        //use for clean up container after test finish.
        protected void ShutdownIoC()
        {
            _container.Dispose();
        }
    }
}
