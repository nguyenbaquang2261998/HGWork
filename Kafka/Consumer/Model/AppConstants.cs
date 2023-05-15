using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventLog.Service.Consumer.Model
{
    class AppConstants
    {
        public const bool IS_LOG = false;
        public const string GROUP_SLACK = "CG725SAKS";
        public const string API_PUSH_NOTIC_TO_SLACK = "https://api-push-notic.30shine.com/api/pushNotice/slack";
        public const string TEAM = "api";
        public const string MODULE_NAME = "30Shine\\Booking-consumer";
        public const string TYPE_ERROR = "Error";
        public const string TYPE_INFO = "Info";
        public const string TYPE_WARNING = "Warning";
    }
}
