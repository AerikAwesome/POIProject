using System.Data;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using POI.Common.Models;
using POI.Data.Repositories;
using POI.Data.Repositories.Management;
using POI.Data.Repositories.Management.Static;
using POI.Data.Repositories.Public;

namespace POI.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "9292POI API", Version = "v1" });
            });
            //Read config
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var config = builder.Build();
            //Add repositories
            services.AddTransient<IDbConnection>(c => new SqlConnector(config).GetConnection());
            services.AddTransient<IProvider<Place>, StaticPlaceRepository>();
            services.AddTransient<IProcessor<Place>, StaticPlaceRepository>();
            services.AddTransient<IPublicPlaceProvider, ReadOnlyStaticPlaceRepository>();

            services.AddTransient<IEventProvider, StaticEventRepository>();
            services.AddTransient<IProcessor<Event>, StaticEventRepository>();

            services.AddTransient<IScheduleProvider, StaticScheduleRepository>();
            services.AddTransient<IProcessor<Schedule>, StaticScheduleRepository>();

            services.AddTransient<IPublicPlaceProvider, ReadOnlyStaticPlaceRepository>();
            //services.AddTransient<IPlaceProvider>(r => new DbPlaceRepository(config["ConnectionString:POIDatabase"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "9292POI API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
