using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NLog;
using System.Threading.Tasks;
using EventLog.Service.Consumer.Extensions.PushNotice;
using EventLog.Service.Consumer.Model.Event;
using EventLog.Service.Consumer.Model;
using EventLog.Service.Consumer.Worker.Handle.Booking;

namespace EventLog.Service.Consumer.Worker.Process
{
    public class BookingConsumer : BaseWorker
    {
        private readonly Logger _logger;
        private readonly IPushNotice _pushNotice;
        private readonly IConfiguration _configuration;
        private readonly IBookingConsumerHandle _bookingConsumerHandle;
        public BookingConsumer(IPushNotice pushNotice, IConfiguration configuration, IBookingConsumerHandle bookingConsumerHandle)
        {
            _logger = LogManager.GetLogger(GetType().Name);
            _pushNotice = pushNotice;
            _configuration = configuration;
            _bookingConsumerHandle = bookingConsumerHandle;
        }
        protected async override Task<ProcessResponseModel> HandleEvent(ConsumeResult<Null, string> eventContent)
        {
            var message = JsonConvert.DeserializeObject<MessageEvent<Null>>(eventContent.Message.Value);
            await _bookingConsumerHandle.Handle(message.Type, eventContent.Message.Value);
            return new ProcessResponseModel { };
        }

        protected override ConsumerInfo InitKafkaConsumer()
        {
            return new ConsumerInfo
            {
                BootstrapServers = _configuration["BookingBroker:BootrapServer"],
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.ScramSha512,
                SaslUsername = _configuration["BookingBroker:SaslUserName"],
                SaslPassword = _configuration["BookingBroker:SaslPassword"],
                GroupId = _configuration["BookingBroker:Groupid"],
                AutoOffsetReset = AutoOffsetReset.Earliest,
                Topic = _configuration["BookingBroker:Topic"]
            };
        }
    }
}
