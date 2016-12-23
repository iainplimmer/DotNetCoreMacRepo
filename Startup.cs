using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IainPlimmerApi.Interfaces;
using IainPlimmerApi.Repositories;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Diagnostics;

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
            services.AddResponseCompression();
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

            app.UseResponseCompression();       //  Let's GZIP the response!
            app.UseMiddleware<AuthenticateRequest>(); //  Let's add our own middleware to the solution
            app.UseDeveloperExceptionPage();    //  Show an exception page if things so awry
            app.UseMvc();                       //  Add MVC and Web API which are now one and the same
            app.UseStaticFiles();               //  Be able to access the wwwroot folder
            
            
        }
    }
}
