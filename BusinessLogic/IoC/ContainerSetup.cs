using Data;
using Data.Contracts;
using Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.IoC
{
    public static class ContainerSetup
    {
        public static void SetUp(
            IServiceCollection services,
            IConfiguration configuration
        )
        {
            AddUnitOfWork (services, configuration);
            ConfigureCors (services);
        }

        private static void AddUnitOfWork(
            IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString =
                configuration["ConnectionStrings:DefaultConnection"];

            services
                .AddDbContext<LibraryDbContext>(options =>
                    options.UseSqlServer(connectionString));

            services
                .AddScoped<IUnitOfWork>(uow =>
                    new EFUnitOfWork(uow
                            .GetRequiredService<LibraryDbContext>()));
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services
                .AddCors(options =>
                {
                    options
                        .AddPolicy("CorsPolicy",
                        builder =>
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod());
                });
        }
    }
}
