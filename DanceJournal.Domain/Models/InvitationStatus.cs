namespace DanceJournal.Domain.Models
{
    public class InvitationStatus
    {
        public int InvitationId { get; set; }
        public int ReceiverId { get; set; }
        public bool IsAccepted { get; set; }

        public Invitation? Invitation { get; set; }
        public User? Receiver { get; set; }
    }
}
