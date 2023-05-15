using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventLog.Service.Consumer.Extensions.PushNotice
{
    public interface IPushNotice
    {
        void PushErrorToSlack(string className, string methodName, string messageError);
        void PushInfoToSlack(string message);
    }
}
