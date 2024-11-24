using LepskyiSystem.Api.Hubs;
using LepskyiSystem.Api.Services;

namespace LepskyiSystem.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ShopDbContext>();
            services.AddSignalR();
            services.AddControllers();
            ConfigureModels(services);
            ConfigureCustomServices(services);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<CraneDataHub>("/crane-data");
            });
        }

        private void ConfigureCustomServices(IServiceCollection services)
        {
            services.AddSingleton<AnomalyDetectionService>();
            services.AddSingleton<CraneDataAccountingService>();
        }

        private void ConfigureModels(IServiceCollection services)
        {

        }
    }
}
