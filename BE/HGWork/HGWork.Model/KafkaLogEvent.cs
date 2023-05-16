using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGWork.Model
{
    public class KafkaLogEvent
    {
        public string StreamId { get; set; }
        public string Data { get; set; }
        public DateTime LogDate { get; set; }
    }
}
