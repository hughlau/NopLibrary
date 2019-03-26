﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nl.Core.Infrastructure;
using Nl.WebFramework.Infrastructure.Extensions;

namespace Nl.WebFramework.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring MVC on application startup
    /// </summary>
    public class NopMvcStartup : INopStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //add MiniProfiler services
            services.AddNopMiniProfiler();

            //add WebMarkupMin services to the services container
            services.AddNopWebMarkupMin();

            //add and configure MVC feature
            services.AddNopMvc();

            //add custom redirect result executor
            services.AddNopRedirectResultExecutor();
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            //add MiniProfiler
            application.UseMiniProfiler();

            //use WebMarkupMin
            application.UseNopWebMarkupMin();

            //MVC routing
            application.UseNopMvc();
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order => 1000; //MVC should be loaded last
    }
}