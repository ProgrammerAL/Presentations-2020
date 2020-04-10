using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comparison_SignalR_Service.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Comparison_SignalR_Service
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
            _ = services.AddControllers();
            _ = services.AddSignalR()               //Tell ASP.NET Core to load SignalR stuff
                        .AddMessagePackProtocol();  //Manually turn on MessagePack. Must reference NuGet: Microsoft.AspNetCore.SignalR.Protocols.MessagePack

            _ = services.AddSingleton<PersonUpdater>();// Must create a singleton instance of the thing that will update the clients
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }

            _ = app.UseHttpsRedirection();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
                _ = endpoints.MapHub<PeopleHub>("/PeopleHub");//Tell ASP.NET Core how to map the Hub - Very different from Controllers
            });

            _ = app.ApplicationServices.GetService<PersonUpdater>();//Need to create an instance of the singleton so it actually runs
        }
    }
}
