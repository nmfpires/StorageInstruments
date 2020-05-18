using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StorageInstruments.Config;
using StorageInstruments.Data;
using StorageInstruments.DataContract;
using StorageInstruments.Service;

namespace StorageInstruments
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
            services = GenericConfiguration.Config(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app = GenericConfiguration.AppBuilderConfiguration(app, env.IsDevelopment());

            app = SwaggerConfiguration.AppBuilderConfig(app);
        }
    }
}
