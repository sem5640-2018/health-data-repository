﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HealthDataRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;

namespace HealthDataRepository
{
    public class Startup
    {

        private readonly IHostingEnvironment environment;

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            this.environment = environment;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<HealthDataRepositoryContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("HealthDataRepositoryContext")));

            if (!environment.IsDevelopment())
            {
                services.Configure<ForwardedHeadersOptions>(options =>
                {
                    var proxyAddresses = Dns.GetHostAddresses("http://nginx");
                    foreach (var ip in proxyAddresses)
                    {
                        options.KnownProxies.Add(ip);
                    }
                });
            }



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            UpdateDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UsePathBase("/health-data-repository");
                app.Use((context, next) =>
                {
                    context.Request.PathBase = new PathString("/health-data-repository");
                    return next();
                });
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }


        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<HealthDataRepositoryContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
