using Library.Core.Api.Data.Context;
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
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(o =>
            o.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
    }
}
