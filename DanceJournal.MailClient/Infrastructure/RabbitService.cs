using EasyNetQ;

namespace DanceJournal.MailClient.Infrastructure
{
    internal class RabbitService<T>
    {
        private IBus? _bus;

        public void Connect(string connectionString)
        {
            _bus = RabbitHutch.CreateBus(connectionString);
        }
        public void Subscribe(string subsriptionId, Action<T> onMessageRecieved)
        {
            using (_bus)
            {
                _bus?.PubSub.Subscribe(subsriptionId, onMessageRecieved);
                Console.WriteLine("Listening for messages.");
                Console.ReadLine();
            }
        }
        public void Disconnect()
        {
            _bus?.Dispose();
        }
    }
}
