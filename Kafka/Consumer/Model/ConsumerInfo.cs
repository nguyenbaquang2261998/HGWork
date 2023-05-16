using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLog.Service.Consumer.Model
{
    public class ConsumerInfo : ConsumerConfig
    {
        public string Topic { get; set; }
    }
}
