using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfraServiceRegistration
    {
        public static void AddInfraServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<IBrandService, BrandService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddScoped<IPictureService, PictureService>();
        }



    }
}
