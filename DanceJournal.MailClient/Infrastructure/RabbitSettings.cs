namespace DanceJournal.MailClient.Infrastructure
{
    public class RabbitSettings
    {
        public string Host { get; set; }
        public ushort Port { get; set; }
        public int HeartbeatSeconds { get; set; }
        public string VirtualHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
