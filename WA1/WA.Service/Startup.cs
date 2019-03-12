using Autofac;
using WA.Service.Dto;
using WA.Service.Interfaces;
using WA.Service.Services;

namespace WA.Service
{
    public static class Startup
    {
        public static void Configure(ContainerBuilder builder, AppSettingsDto settings)
        {
            AppSettings.Init(settings);

            Data.Startup.Configure(builder, AppSettings.WAConnectionString, AppSettings.WAEdmxConnectionString);

            builder.RegisterType<UserCredService>().As<IUserCredService>();
        }
    }
}
