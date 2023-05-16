using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NLog;
using System.Threading.Tasks;
using EventLog.Service.Consumer.Model.Event;
using EventLog.Service.Consumer.Model;
using EventLog.Service.Consumer.Worker.Handle.Base;

namespace EventLog.Service.Consumer.Worker.Process
{
    public class TaskConsumer : BaseWorker
    {
        private readonly Logger _logger;
        private readonly IConfiguration _configuration;
        private readonly ITaskConsumerHandle _taskConsumerHandle;
        public TaskConsumer(IConfiguration configuration, ITaskConsumerHandle taskConsumerHandle)
        {
            _logger = LogManager.GetLogger(GetType().Name);
            _configuration = configuration;
            _taskConsumerHandle = taskConsumerHandle;
        }
        protected async override Task<ProcessResponseModel> HandleEvent(ConsumeResult<Null, string> eventContent)
        {
            var message = JsonConvert.DeserializeObject<MessageEvent<Null>>(eventContent.Message.Value);
            await _taskConsumerHandle.Handle(message.Type, eventContent.Message.Value);
            return new ProcessResponseModel { };
        }

        protected override ConsumerInfo InitKafkaConsumer()
        {
            return new ConsumerInfo
            {
                BootstrapServers = _configuration["HGKBroker:BootrapServer"],
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = _configuration["HGKBroker:SaslUserName"],
                SaslPassword = _configuration["HGKBroker:SaslPassword"],
                GroupId = _configuration["HGKBroker:Groupid"],
                AutoOffsetReset = AutoOffsetReset.Earliest,
                Topic = _configuration["HGKBroker:Topic"],
                SessionTimeoutMs = 45000
            };
        //https://confluent.cloud/environments/env-gn3733/clusters/lkc-7n3ojp/topics/task/overview

//# Required connection configs for Kafka producer, consumer, and admin
//            bootstrap.servers = pkc - lzvrd.us - west4.gcp.confluent.cloud:9092
//security.protocol = SASL_SSL
//sasl.mechanisms = PLAIN
//sasl.username = CJIKJZHWESQFRO3Q
//sasl.password = 3zA61fLHk5v0o5KbnhBReJlW + l4pio / LLyXKR7CqxyVXvhaw6KxUNJF2ubxlaJDR

            //# Best practice for higher availability in librdkafka clients prior to 1.7
            //session.timeout.ms = 45000

        }
    }
}
