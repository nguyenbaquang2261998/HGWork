using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLog.Service.Consumer.Model.Event
{
    public class MessageEvent<TData>
    {
        public MessageEvent() { }
        public MessageEvent(TData data)
        {
            Data = JsonConvert.SerializeObject(data);
        }
        public string Type { get; set; }
        public string StreamId { get; set; }
        public int CurrVersion { get; set; }
        public string Data { get; set; }
        public string Meta { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
