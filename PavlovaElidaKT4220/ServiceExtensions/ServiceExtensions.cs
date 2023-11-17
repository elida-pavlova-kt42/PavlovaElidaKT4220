using PavlovaElidaKT4220.Interfaces.StepenInterfaces;
using PavlovaElidaKT4220.Interfaces.PrepodInterfaces;
using PavlovaElidaKT4220.Interfaces;

namespace PavlovaElidaKT4220.ServiceInterfaces
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPrepodService, PrepodService>();
            services.AddScoped<IStepenService, StepenService>();

            return services;
        }
    }
}