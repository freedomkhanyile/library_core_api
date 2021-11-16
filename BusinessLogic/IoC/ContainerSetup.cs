using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using BusinessLogic.Services;
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
            AddServices (services);
        }

        public static void AddServices(IServiceCollection services)
        {
            // We use some features that come with ASPNet to map our service using Namespace attributes.
            // Service type (Well loop through this object)
            var serviceType = typeof (BookService);
            var types =
                (
                from t in serviceType.GetTypeInfo().Assembly.GetTypes()
                where
                t.Namespace == serviceType.Namespace && // namespace BusinessLogic.Services
                t.GetTypeInfo().IsClass && // Returns all concrete class under the namespace.
                t
                    .GetTypeInfo()
                    .GetCustomAttribute<CompilerGeneratedAttribute>() ==
                null
                select t
                ).ToArray();

            // Get interfaces for these services
            foreach (var type in types)
            {
                var iServiceType = type.GetTypeInfo().GetInterfaces().First();
                services.AddTransient (iServiceType, type);
            }
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
