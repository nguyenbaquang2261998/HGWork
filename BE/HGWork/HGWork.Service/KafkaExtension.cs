using Confluent.Kafka;
using HGWork.DTO.Kafka;
using HGWork.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HGWork.Service
{
    public class KafkaExtension : IKafkaExtension
    {
        private readonly IProducer<Null, string> _kafkaProducer;
        public KafkaExtension(IProducer<Null, string> kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }

        public async Task<ProduceResponse<TData>> ProduceEventKafka<TData>(string topic, MessageEvent<TData> message)
        {
            try
            {
                var messageContent = JsonConvert.SerializeObject(message);
                var eventContent = new Message<Null, string> { Value = messageContent };

                var res = await _kafkaProducer.ProduceAsync(topic, eventContent);
                if (res.Status == PersistenceStatus.Persisted)
                {
                    return new ProduceResponse<TData>
                    {
                        StatusCode = 200,
                        Message = "Success",
                        ListMessageError = new List<MessageEvent<TData>>()
                    };
                }
                return new ProduceResponse<TData>
                {
                    StatusCode = 200,
                    Message = "Error",
                    ListMessageError = new List<MessageEvent<TData>>() { message }
                };
            }
            catch
            {
                return new ProduceResponse<TData>
                {
                    StatusCode = 400,
                    Message = "Error",
                    ListMessageError = new List<MessageEvent<TData>>() { message }
                };
            }
        }

        public string GenStreamId(string input)
        {
            var guid = "";
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                Guid result = new Guid(hash);
                guid = result.ToString();
            }
            return guid;
        }
    }
}
