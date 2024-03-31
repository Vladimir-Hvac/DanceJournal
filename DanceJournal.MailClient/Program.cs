// See https://aka.ms/new-console-template for more information
using DanceJournal.Contracts.MessageContracts;
using DanceJournal.MailClient;
using DanceJournal.MailClient.Adapters;

Console.WriteLine("The MailClient started.");

string brokerConnectionString = $"amqps://sjpgbhvs:V9cPualIQSXQKEcIHVPuNNknz5V0Y3dE@goose.rmq2.cloudamqp.com/sjpgbhvs";

IMailClientBrokerService mailClientBrokerService = new RabbitAccess(HandleMessage, brokerConnectionString);
mailClientBrokerService.Subscribe();
Console.ReadLine();
void HandleMessage(NotificationMessageDTO message)
{
    Console.WriteLine($"The MailClient recieved the message: {message.Message}");
}
