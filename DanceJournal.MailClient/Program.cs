// See https://aka.ms/new-console-template for more information
using DanceJournal.Contracts.MessageContracts;
using DanceJournal.MailClient;
using DanceJournal.MailClient.Adapters;

object locker = new();
MailClient mailClient = new();


Console.WriteLine("The MailClient started.");

string brokerConnectionString = $"amqps://sjpgbhvs:V9cPualIQSXQKEcIHVPuNNknz5V0Y3dE@goose.rmq2.cloudamqp.com/sjpgbhvs";

IMailClientBrokerService mailClientBrokerService = new RabbitAccess(HandleMessage, brokerConnectionString);
mailClientBrokerService.Subscribe();
Console.ReadLine();
void HandleMessage(NotificationMessageDTO message)
{
    Thread myThread = new Thread(new ParameterizedThreadStart(Handle));
    myThread.Start(message);
}


void Handle(object? message)
{
    lock (locker)
    {
        mailClient.Execute(message);
    }
}