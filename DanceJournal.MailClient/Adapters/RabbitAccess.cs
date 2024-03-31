using DanceJournal.Contracts.MessageContracts;
using DanceJournal.MailClient.Infrastructure;

namespace DanceJournal.MailClient.Adapters
{
    internal class RabbitAccess : IMailClientBrokerService
    {
        public Action<NotificationMessageDTO> OnMessageRecieved { get; set; }
        private readonly RabbitService<NotificationMessageDTO> _rabbitService;
        public RabbitAccess(Action<NotificationMessageDTO> OnMessageRecieved, string connectionString)
        {
            try
            {
                this.OnMessageRecieved = OnMessageRecieved;
                _rabbitService = new RabbitService<NotificationMessageDTO>();
                _rabbitService.Connect(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void Subscribe()
        {
            _rabbitService.Subscribe("dj", OnMessageRecieved);
        }
    }
}
