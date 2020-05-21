using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
            services.AuthenticationJWT(Configuration);
            services.AddDbContext<RepositoryContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DataContext"), b => b.MigrationsAssembly("UIL")));
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
