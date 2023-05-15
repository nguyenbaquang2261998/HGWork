using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EventLog.Service.Consumer.Model;

namespace EventLog.Service.Consumer.Extensions.PushNotice
{
    class PushNotice : IPushNotice
    {
        private readonly string domainPushNotice;
        private readonly string apiNoticeSlack;
        private readonly string groupSlack;
        private bool IsPushSlack;
        private readonly IConfiguration Configuration;
        public PushNotice(IConfiguration configuration)
        {
            Configuration = configuration;
            //get api using
            domainPushNotice = Configuration.GetSection("APIsUsing:DomainPushNotice").Value;
            apiNoticeSlack = string.Concat(domainPushNotice, Configuration.GetSection("APIsUsing:ApiNoticeToSlack").Value);
            IsPushSlack = bool.Parse(Configuration.GetSection("APIsUsing:IsPushSlack").Value);
            groupSlack = Configuration.GetSection("APIsUsing:GroupSlack").Value;


        }

        /// <summary>
        /// Push lỗi tới ứng dụng slack
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="messageError"></param>
        public void PushErrorToSlack(string className, string methodName, string messageError)
        {
            try
            {
                if (IsPushSlack)
                {
                    string uri = apiNoticeSlack;
                    var content = new
                    {
                        list_group_id = new[] { groupSlack },
                        type = AppConstants.TYPE_ERROR,
                        team = AppConstants.TEAM,
                        message = string.Format("Error: {0} \n __ClassName: {1} \n __MethodName: {2}", messageError, className, methodName),
                        module_name = AppConstants.MODULE_NAME
                    };
                    new HttpClient().PostAsync(uri,
                        new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Push thông tin tới ứng dụng slack
        /// </summary>
        /// <param name="message"></param>
        public void PushInfoToSlack(string message)
        {
            if (IsPushSlack)
            {
                string uri = apiNoticeSlack;
                var content = new
                {
                    list_group_id = new[] { groupSlack },
                    type = AppConstants.TYPE_INFO,
                    team = AppConstants.TEAM,
                    message = string.Format("Info: {0}", message),
                    module_name = AppConstants.MODULE_NAME
                };
                new HttpClient().PostAsync(uri,
                    new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"));
            }
        }

    }
}
