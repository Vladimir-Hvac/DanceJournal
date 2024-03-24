public class SubscriptionType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ContDay { get; set; }
    public double Price { get; set; }

    public bool IsActive { get; set; }

    //public ICollection<Subscription> Subscriptions { get; set; }
}
