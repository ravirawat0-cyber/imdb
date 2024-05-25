using Assignment3.Repository;
using Assignment3.Services.Interfaces;
using IMDB.CustomMiddleware;
using IMDB.Helper;
using IMDB.Interfaces;
using IMDB.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace IMDB
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
            services.AddScoped<DbContext>();
            services.AddScoped<ActorRepository>();
            services.AddScoped<ProducerRepository>();
            services.AddScoped<GenreRepository>();
            services.AddScoped<ExceptionHandlingMiddleware>();
            services.AddScoped<MovieRepository>();
            services.AddScoped<ReviewRepository>(); 
            services.AddScoped<IActorServices, ActorServices>();
            services.AddScoped<IProducerServices, ProducerServices>();
            services.AddScoped<IMovieServices, MovieServices>();
            services.AddScoped<IGenreServices, GenreServices>();
            services.AddScoped<IReviewServices, ReviewServices>();
            services.AddScoped<IDataHelper , DataHelper>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<ExceptionHandlingMiddleware>();
          
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
