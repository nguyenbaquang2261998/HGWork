using System.Threading.Tasks;

namespace EventLog.Service.Consumer.Worker.Handle.Booking
{
    public interface IBookingConsumerHandle
    {
        Task Handle(string key, string content);
    }
}
