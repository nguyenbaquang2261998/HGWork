using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NLog;
using EventLog.Service.Consumer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventLog.Service.Consumer.Extensions.PushNotice;
using EventLog.Service.Consumer.Model;

namespace EventLog.Service.Consumer.Worker
{
    public abstract class BaseWorker : BackgroundService
    {
        private readonly Logger _logger;
        public BaseWorker()
        {
             _logger = LogManager.GetLogger(GetType().Name);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1);
            var config = InitKafkaConsumer();
            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                consumer.Subscribe(config.Topic);
                while (true)
                {
                    try
                    {
                        var consumeResult = consumer.Consume();
                        //var timeStart = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                        _logger.Info("Handle event: {0}", consumeResult.Message.Value);
                        var result = await HandleEvent(consumeResult);
                        //_logger.Info("Handle event end at {0}, process in {1} ms", DateTime.Now, DateTimeOffset.Now.ToUnixTimeMilliseconds() - timeStart);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Handle event error: {0}", ex.Message);
                    }
                }
            }
        }

        protected abstract Task<ProcessResponseModel> HandleEvent(ConsumeResult<Null, string> eventContent);

        protected abstract ConsumerInfo InitKafkaConsumer();
    }
}
