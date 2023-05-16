using Microsoft.Extensions.Configuration;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventLog.Service.Consumer.Worker.Handle.EventLog
{
    public class EvenLogHandle : IEvenLogHandle
    {
        private readonly IConfiguration _configuration;
        private readonly Logger _logger;

        public EvenLogHandle(IConfiguration configuration)
        {
            _logger = LogManager.GetLogger(GetType().Name);
            _configuration = configuration;
        }
        public async Task InsertEventLog(HttpClient httpClient, string content, string type)
        {
            string uri = _configuration["TaskService:Domain"] + "/event-log-internal/insert-eventlog";
            var result = await httpClient.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json"));
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _logger.Error("[TaskEventLog] api /insert-evenlog {0} {1} fail! {2}", type, content, DateTime.Now);
            }
            else
            {
                _logger.Info("[TaskEventLog] api /insert-evenlog {0} success! {1}", type, DateTime.Now);
            }
        }
    }
}
