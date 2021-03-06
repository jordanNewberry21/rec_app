using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using rec_app.Core;
using rec_app.Data;
using rec_app.Core.Services;
using rec_app.Services;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations; 


namespace rec_app.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "rec_app.Api", Version = "v1" });
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContextPool<RecAppDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("rec_app.Data")));
            services.AddTransient<IMusicService, MusicService>();
            services.AddTransient<IArtistService, ArtistService>();
            services.AddAutoMapper(typeof(Startup));
        }

        public class DesignTimeRecAppDbContext : IDesignTimeDbContextFactory<RecAppDbContext>
        {
            public RecAppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<RecAppDbContext>();
                // pass in design time connection string here
                optionsBuilder.UseNpgsql("Default");
                // return design time DB context
                return new RecAppDbContext(optionsBuilder.Options);
            }
        }

        //public class MyDesignTimeServices : IDesignTimeServices
        //{
        //    public void ConfigureDesignTimeServices(IServiceCollection services)
        //        => services.AddSingleton<IMigrationsCodeGenerator, MyMigrationsCodeGenerator>();
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "rec_app.Api v1"));
            }

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
