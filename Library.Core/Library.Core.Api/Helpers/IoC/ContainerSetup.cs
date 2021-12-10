﻿using Library.Core.Api.Data.Context;
using Library.Core.Api.Data.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System;

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
            AddMediatR(services);
            AddCors(services);
            AddJsonSerializer(services);
        }

        private static void AddJsonSerializer(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson( _ => 
            _.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(_ => _.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        private static void AddCors(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("CorsPolicy", _ => _
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            });
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


        private static void AddMediatR(IServiceCollection services)
        {
            services.AddMediatR(typeof(EFUnitOfWork));
        }
    }
}
