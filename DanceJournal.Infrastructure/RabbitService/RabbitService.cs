using EasyNetQ;

namespace DanceJournal.Infrastructure.RabbitService
{
    public class RabbitService<T>
    {
        private IBus? _bus;

        public void Connect(string connectionString)
        {
            _bus = RabbitHutch.CreateBus(connectionString);
        }
        public void Publish(T message)
        {
            using (_bus)
            {
                _bus?.PubSub.Publish(message);
            }
        }
    }
}
