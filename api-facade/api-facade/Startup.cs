using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit.MultiBus;
using MassTransit;
using Okta.AspNet;
using Okta.AspNetCore;
using Troupon.Events;

namespace api_facade
{
    public class Startup
    {
        public Startup(
            IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddAuthentication(
                    options =>
                    {
                        options.DefaultAuthenticateScheme = OktaDefaults.ApiAuthenticationScheme;
                        options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
                        options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;
                    })
                .AddOktaWebApi(
                    new OktaWebApiOptions()
                    {
                        OktaDomain = Configuration["Okta:OktaDomain"],
                        Audience = "crm-api-backend",
                    });

            services.AddCors();

            services.AddAuthorization();

            services.AddControllers();
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc(
                        "v1",
                        new OpenApiInfo {Title = "api_facade", Version = "v1"});
                });

            services.AddMassTransit(
                x =>
                {
                    x.UsingRabbitMq((
                        context,
                        cfg) => cfg.Host(
                        "localhost",
                        "Troupon"));
                    x.AddRequestClient<DealsRequested>();
                });

            services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            app.Use(
                async (
                    ctx,
                    next) =>
                {
                    await next();

                    if (ctx.Response.StatusCode == 204)
                    {
                        ctx.Response.ContentLength = 0;
                    }
                });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(
                    c => c.SwaggerEndpoint(
                        "/swagger/v1/swagger.json",
                        "api_facade v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseCors(
                x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
