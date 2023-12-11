using ManagementApp.Application.Repositories;
using ManagementApp.Infrastructure.DataContext;
using ManagementApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Api.Extensions
{
    public static class ApplicationServiceContainerExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<ManagementAppContext>(options => options.UseSqlServer(configuration.GetConnectionString("ManagementApp")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors(options => options.AddPolicy("ManagementAppPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

            return services;
        }
    }
}
