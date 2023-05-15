using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using EventLog.Service.Consumer.Worker;
using EventLog.Service.Consumer.Worker.Process;
using EventLog.Service.Consumer.Extensions.PushNotice;
using Microsoft.AspNetCore.Components;
using EventLog.Service.Consumer.Worker.Handle.EventLog;
using EventLog.Service.Consumer.Worker.Handle.Booking;

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

            services.AddSingleton<IPushNotice, PushNotice>();

            services.AddTransient<IBookingConsumerHandle, BookingConsumerHandle>();
            services.AddTransient<IEvenLogHandle, EvenLogHandle>();

            #region Queue instance
            var numThreadBookingImport = Convert.ToInt32(Configuration["BookingBroker:Instance"]);
            for (int i = 0; i < numThreadBookingImport; i++)
            {
                services.AddSingleton<IHostedService, BookingConsumer>();
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
