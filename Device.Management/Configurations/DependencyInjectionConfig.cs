using Device.Management.Repository;
using Device.Management.Repository.Interfaces;
using Device.Management.Service;
using Device.Management.Service.Interfaces;

namespace Device.Management.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //Context
            services.AddScoped<IDeviceContext, DeviceContext>();
        
         
            //AppServices
            services.AddScoped<IDevicesService, DeviceService>();

            //Repository
            services.AddScoped<IDeviceRepository, DeviceRepository>();

        }
    }
}
