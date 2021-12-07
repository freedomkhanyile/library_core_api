using Library.Core.Api.Data.Context;
using Library.Core.Api.Data.Services;
using Library.Core.Api.Data.Services.Contracts;
using Library.Core.Api.Data.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Api.Helpers.IoC
{
    public static class ContainerSetup
    {
        public static void Setup(
            IServiceCollection services,
            IConfiguration configuration)
        {
            AddDatabase(services, configuration);
            AddUnitOfWork(services);
            AddServices(services);
            AddMediatR(services);
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(o =>
            o.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        private static void AddUnitOfWork(IServiceCollection services)
        {
            services.AddScoped<DbContext>(o => o.GetService<ApplicationDbContext>());
            services.AddScoped<IUnitOfWork>(
                uow => new EFUnitOfWork(uow.GetRequiredService<ApplicationDbContext>()));
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
        }

        private static void AddMediatR(IServiceCollection services)
        {
            services.AddMediatR(typeof(BookService));
        }
    }
}
