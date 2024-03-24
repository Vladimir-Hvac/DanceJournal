using EasyNetQ;
using EasyNetQ.Topology;
using System.Text;

namespace DanceJournal.Infrastructure.RabbitService
{
    public class RabbitService
    {
        private IAdvancedBus _advancedBus;
        private RabbitSettings _rS;

        public void Initialize()
        {
            ConnectionConfiguration configuration = new ConnectionConfiguration()
            {
                Hosts = new List<HostConfiguration>()
                {
                    new HostConfiguration() { Host = _rS.Host, Port = _rS.Port, }
                },
                VirtualHost = _rS.VirtualHost,
                UserName = _rS.UserName,
                Password = _rS.Password,
            };

            _advancedBus = RabbitHutch
                            .CreateBus(configuration, x => x.RegisterDefaultServices(_ => configuration))
                            .Advanced;
        }
        public void Subscribe(string routingKey, string queueName)
        {
            Queue queue = CreateQueue();
            IDisposable consumer = _advancedBus.Consume(
                queue,
                (body, properties, info) =>
                    Task.Factory.StartNew(() => HandleMessage(body, properties, info)),
                x => x.WithAutoAck()
            );
        }

        public async Task Publish(object message, string queueName)
        {
            await Task.Delay(100);
        }

        private Queue CreateQueue()
        {
            Queue result = default;
            return result;
        }
        private void HandleMessage(
            ReadOnlyMemory<byte> msgBody,
            MessageProperties msgProps,
            MessageReceivedInfo info
        )
        {
            string msgStrOrig = Encoding.UTF8.GetString(msgBody.ToArray());
        }
    }
}
