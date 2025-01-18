using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAppTask.Services;
using MyAppTask.DAL;


namespace MyAppTask.Configuration
{
    public static class Configurations
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MappingProfile));
        }
        
        public static void AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var productConnectionString = configuration.GetConnectionString("DefaultConnection");
           
            services.AddDbContext<ProductContext>(options =>
            {
                options.UseSqlServer(productConnectionString);
            });
        }
    }
    
}
