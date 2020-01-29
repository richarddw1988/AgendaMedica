using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using AM.Service.Configurations;
using AM.Infra.CrossCutting;
using AutoMapper;
using AM.App.AutoMapper;
using Newtonsoft.Json.Serialization;

namespace AM.Service
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapperSetup();

            services.AddMvc(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                
                options.UseCentralRoutePrefix(new RouteAttribute("api"));
            }).AddJsonOptions(options =>
            {
                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null)
                    resolver = new CamelCasePropertyNamesContractResolver();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors();

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(c =>
            {
                c.WithOrigins("http://localhost:4200");
                c.AllowAnyHeader();
                c.AllowAnyMethod();
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
