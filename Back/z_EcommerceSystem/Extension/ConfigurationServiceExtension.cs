using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Repository.Implementation;
using Repository.Interface;
using z_EcommerceSystem.Services;

namespace TestApplication.Extension
{
    public static class ConfigurationServiceExtension
    {
         public static void configurationRepositoryMethod(this IServiceCollection services)
        {
             services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped(typeof(IUntityOfWork),typeof(UntityOfWork));
        }
        public static void configurationServicesMethod(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            //services.AddScoped<IJwtAuthenticationManager, JwtAuthenticationManager>();
        }
    }
}
 
 