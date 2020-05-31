using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAL.Data;
using BLL.Helpers;
using AutoMapper;
using BLL.Mappings;
using DAL.Data.Interfaces;
using DAL.Data.Repository;
using NLog;
using System.IO;
using UIL.Extensions;
using BLL.Services.InterfacesServices;
using Microsoft.AspNetCore.Mvc;
using UIL.ActionFilters;

namespace UIL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
           LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddControllers();
            services.AddCors();
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.ConfigureLoggerService();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ValidateItemExistsAttribute>();
            services.AuthenticationJWT(Configuration);
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.ConfigureSqlContext(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.ConfigureExceptionHandler(logger);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
