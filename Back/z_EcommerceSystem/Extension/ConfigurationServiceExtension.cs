
using Microsoft.Extensions.DependencyInjection;
using Repository.Implementation;
using Repository.Implementation.UserRepository;
using Repository.Interface;
using Repository.Interface.UserRepository;
using Services.IContract;
using Services.Services;

namespace TestApplication.Extension
{
    public static class ConfigurationServiceExtension
    {
         public static void configurationRepositoryMethod(this IServiceCollection services)
        {
             services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
             services.AddScoped(typeof(ICategoryRepository),typeof(CategoryRepository));
            services.AddScoped(typeof(IUntityOfWork),typeof(UntityOfWork));
           

        }
        public static void configurationServicesMethod(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
        }
    }
}