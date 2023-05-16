using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGWork.DTO.Kafka
{
    public class ProduceResponse<TData>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<MessageEvent<TData>> ListMessageError { get; set; }
    }
}
