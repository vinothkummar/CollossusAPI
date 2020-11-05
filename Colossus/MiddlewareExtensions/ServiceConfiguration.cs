using Colossus.Data;
using Colossus.Repository;
using Colossus.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Colossus.MiddlewareExtensions
{
    public static class ServiceConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(cfg =>
                cfg.UseLazyLoadingProxies().UseSqlServer(config.GetConnectionString("DefaultConnection"),

                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IFileStorageRepository, FileStorageRepository>();

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }
    }
}
