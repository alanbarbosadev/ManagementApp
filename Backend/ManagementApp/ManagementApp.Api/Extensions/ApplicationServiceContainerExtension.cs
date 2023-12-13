using FluentValidation;
using FluentValidation.AspNetCore;
using ManagementApp.Api.Errors;
using ManagementApp.Application.Features.Auth.Commands.Register;
using ManagementApp.Application.Repositories;
using ManagementApp.Infrastructure.DataContext;
using ManagementApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Api.Extensions
{
    public static class ApplicationServiceContainerExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ManagementAppContext>(options => options.UseSqlServer(configuration.GetConnectionString("ManagementApp")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddCors(options => options.AddPolicy("ManagementAppPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<RegisterCommandValidator>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToArray();

                    var errorsResponse = new ApiValidationErrorResponse(400, errors)
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorsResponse);
                };
            });

            return services;
        }
    }
}
