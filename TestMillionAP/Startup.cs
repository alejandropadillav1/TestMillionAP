using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using TestMillionAP.Interface;
using TestMillionAP.Model;
using TestMillionAP.Services;
namespace TestMillionAP
{
    public class Startup
    {
        public Startup(IConfiguration configuration) { Configuration = configuration; }
        /// <summary>
        ///   Initial Setup configuration Dependency Injection
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Real Estate API");
            });
            app.UseSwagger();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        /// <summary>
        ///   Configuration Dependency Injection Services.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_CONNECTIONSTRING"]);
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Real Estate API - Developed by Alejandro Padilla", Contact = new OpenApiContact { Name = "Alejandro Padilla", Email = "alejandropadillav@yahoo.es" }, License = new OpenApiLicense { Name = "License Opensource", } });
            });
            services.AddXpoDefaultDataLayer(ServiceLifetime.Singleton, dl => dl
                .UseConnectionString(Configuration.GetConnectionString("MSSqlServer")).UseThreadSafeDataLayer(true).UseConnectionPool(false) // Remove this line if you use a database server like SQL Server, Oracle, PostgreSql, etc.
                .UseAutoCreationOption(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema).UseEntityTypes(typeof(Owner), typeof(Property), typeof(PropertyImage), typeof(PropertyTrace)));
            // Adding a dependency injection into a RealEstateXPO Services class - UnitOfWork, this is required to manage a database ORM XPO.
            // See the comments into a Model's folder class or in a RealEstateXPO Service class in order to get information about the ORM XPO instead of EF or EF Core.
            services.AddXpoDefaultUnitOfWork();
            services.AddScoped<IRealEstateServices, RealEstateXPOServices>();
        }
        public IConfiguration Configuration { get; }
    }
}
