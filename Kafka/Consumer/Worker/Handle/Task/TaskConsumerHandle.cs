using EventLog.Service.Consumer.Worker.Handle.EventLog;
using Microsoft.Extensions.Configuration;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventLog.Service.Consumer.Worker.Handle.Base
{
    public class TaskConsumerHandle : ITaskConsumerHandle
    {
        private readonly IEvenLogHandle _evenLogHandle;
        private readonly Logger _logger;

        public TaskConsumerHandle(IEvenLogHandle evenLogHandle)
        {
            _evenLogHandle = evenLogHandle;
            _logger = LogManager.GetLogger(GetType().Name);
        }
        public async Task Handle(string key, string content)
        {
            var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(180);

            _logger.Info($"[TaskConsumerHandle] event {key} . . .", DateTime.Now);

            await _evenLogHandle.InsertEventLog(httpClient, content, key);
        }
    }
}
