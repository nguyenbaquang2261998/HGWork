using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;
using EventLog.Service.Consumer.Worker.Process;
using EventLog.Service.Consumer.Worker.Handle.EventLog;
using EventLog.Service.Consumer.Worker.Handle.Base;

namespace EventLog.Service.Consumer
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
             .AddEnvironmentVariables()
             .Build();
            NLog.LogManager.Configuration = new NLogLoggingConfiguration(builder.GetSection("NLog"));
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<ITaskConsumerHandle, TaskConsumerHandle>();
            services.AddTransient<IEvenLogHandle, EvenLogHandle>();

            #region Queue instance
            var numThreadTaskImport = Convert.ToInt32(Configuration["HGKBroker:Instance"]);
            for (int i = 0; i < numThreadTaskImport; i++)
            {
                services.AddSingleton<IHostedService, TaskConsumer>();
            }
            #endregion Queue instance
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
