﻿using Contracts;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountOwnerServerAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
           {
               options.AddPolicy("CorsPolicy",
                   builder => builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
           });
        }



        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
                //We do not initialize any of the properties inside the options because we are just fine with the default values
            });
        }


        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
