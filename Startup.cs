using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IainPlimmerApi.Interfaces;
using IainPlimmerApi.Repositories;
using Newtonsoft.Json.Serialization;

namespace IainPlimmerApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(o => { 
                    if (o.SerializerSettings.ContractResolver != null)
                    {
                        var cr = o.SerializerSettings.ContractResolver as DefaultContractResolver;
                        //  We want a default JSON serialiser without all that camel case nonsense. 
                        //  So we set this here.
                        cr.NamingStrategy = null;
                    }
                });
                   
            services.AddTransient<IBlogPostRespository, BlogPostRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();           //
            app.UseStaticFiles();   // Be able to access the wwwroot folder
        }
    }
}
