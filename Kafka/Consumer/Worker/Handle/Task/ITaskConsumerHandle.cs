using System.Threading.Tasks;

namespace EventLog.Service.Consumer.Worker.Handle.Base
{
    public interface ITaskConsumerHandle
    {
        Task Handle(string key, string content);
    }
}
