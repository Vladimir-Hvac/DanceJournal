using System.ComponentModel.DataAnnotations.Schema;

public class Subscription
{
    public int Id { get; set; }
    public int SubscriptionTypeId { get; set; }
    public DateTime StartDay { get; set; }
    public DateTime FinishDay { get; set; }

    [ForeignKey("SubscriptionTypeId")]
    public SubscriptionType SubscriptionType { get; set; }

    public ICollection<User> Users { get; set; }
}
