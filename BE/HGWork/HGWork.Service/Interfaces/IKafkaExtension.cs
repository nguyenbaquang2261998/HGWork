using HGWork.DTO.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGWork.Service.Interfaces
{
    public interface IKafkaExtension
    {
        Task<ProduceResponse<TData>> ProduceEventKafka<TData>(string topic, MessageEvent<TData> message);
        string GenStreamId(string input);
    }
}
