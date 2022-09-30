using DDDTraining.lifeSession.Application;
using DDDTraining.lifeSession.Application.CommandHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace DDDTraining.lifeSession.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.



        public void ConfigureServices(IServiceCollection services)
        {
            //application service
            services.AddSingleton(new ClassifiedAdsApplicationService());

            // command handler pattern
            services.AddScoped<IHandleCommand<Application.Contract.ClassifiedAds.V1.Create>,
                CreateClassifiedAdHandler>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClassifiedAds", Version = "v1" });
            });


            //services.AddScoped<IHandleCommand<V1.Create>>(c =>
            //    new RetryingCommandHandler<V1.Create>(
            //    new
            //    CreateClassifiedAdHandler(c.GetService<RavenDbEntityStore>())));
            //    services.AddScoped<IHandleCommand<V1.Create>>(c =>
            //    new RetryingCommandHandler<V1.Rename>(
            // new RenameClassifiedAdHandler(c.GetService<RavenDbEntityStore>())));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClassifiedAds v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
