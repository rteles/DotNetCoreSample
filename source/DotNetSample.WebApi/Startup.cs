using AutoMapper;
using DotNetSample.Application.AutoMapper;
using DotNetSample.Application.Services;
using DotNetSample.Application.Services.Contracts;
using DotNetSample.Domain.Interfaces.Repository;
using DotNetSample.Domain.Interfaces.Service;
using DotNetSample.Domain.Services;
using DotNetSample.Infra.Repository.Context;
using DotNetSample.Infra.Repository.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DotNetSample.WebApi
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
            ConfigureAutoMapper(services);
            ConfigureDatabase(services);
            ConfigureApplicationServices(services);
            ConfigureControllers(services);
            ConfigureSwagger(services);
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
       
        private static void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<RepositoryContext>(opt =>
                opt.UseInMemoryDatabase("LocalRepository"));
        }
       
        private static void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAppService, UserAppService>();
        }
       
        private static void ConfigureControllers(IServiceCollection services)
        {
            services.AddControllers();
        }
        
        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "My API", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}