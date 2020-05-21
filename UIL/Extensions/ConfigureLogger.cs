using BLL.Services;
using BLL.Services.InterfacesServices;
using Microsoft.Extensions.DependencyInjection;

namespace UIL.Extensions
{
    public static class ConfigureLogger
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
                services.AddScoped<ILoggerManager, LoggerManager>();
    }
}
