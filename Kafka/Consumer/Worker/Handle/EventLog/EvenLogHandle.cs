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
            string uri = _configuration["BookingService:Domain"] + "/event-log-internal/insert-eventlog?MasterKey=" + _configuration["BookingService:MasterKey"];
            var result = await httpClient.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json"));
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _logger.Error("[BookingEventLog] api /insert-evenlog {0} {1} fail! {2}", type, content, DateTime.Now);
            }
            else
            {
                _logger.Info("[BookingEventLog] api /insert-evenlog {0} success! {1}", type, DateTime.Now);
            }
        }

        //public async Task InsertEventLogView(HttpClient httpClient, string content, string type)
        //{
        //    string uri = _configuration["BookingViewService:Domain"] + "/event-log-timekeeping/insert-eventlog?MasterKey=" + _configuration["BookingService:MasterKey"];

        //    _logger.Info("[EventLogView] : " + uri);
        //    var result = await httpClient.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json"));
        //    if (result.StatusCode != System.Net.HttpStatusCode.OK)
        //    {
        //        _logger.Error("[EventLogView] api /insert-evenlog-view {0} {1} fail! {2}", type, content, DateTime.Now);
        //    }
        //    else
        //    {
        //        _logger.Info("[EventLogView] api /insert-evenlog-view {0} success! {1}", type, DateTime.Now);
        //    }
        //}
    }
}
