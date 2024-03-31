using DanceJournal.Contracts.MessageContracts;
using DanceJournal.Services.BS_NotificationManagement.Gateways;
using Microsoft.Extensions.Configuration;

namespace DanceJournal.Infrastructure.RabbitService
{
    public class RabbitAccess : IBrokerService
    {
        public Action<NotificationMessageDTO> OnMessageRecieved { get; set; }
        private readonly RabbitService<NotificationMessageDTO> _rabbitServiceSimple;
        public RabbitAccess()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("ISsettings.json").Build();
            var connectionString = configuration?.GetConnectionString("RabbitConnection");

            if (connectionString is null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            _rabbitServiceSimple = new RabbitService<NotificationMessageDTO>();
            _rabbitServiceSimple.Connect(connectionString);
        }

        public void PublishNotificationMessage(NotificationMessageDTO notificationMessageDTO)
        {
            _rabbitServiceSimple.Publish(notificationMessageDTO);
        }
    }
}
