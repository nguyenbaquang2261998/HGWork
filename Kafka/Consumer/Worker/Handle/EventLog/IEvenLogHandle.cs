using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventLog.Service.Consumer.Worker.Handle.EventLog
{
    public interface IEvenLogHandle
    {
        Task InsertEventLog(HttpClient httpClient, string content, string type);
        //Task InsertEventLogView(HttpClient httpClient, string content, string type);
    }
}
