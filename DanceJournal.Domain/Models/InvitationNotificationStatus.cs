using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Domain.Models
{
    public class InvitationNotificationStatus
    {
        public int InvitationId { get; set; }
        public int NotificationId { get; set; }
        public int ReceiverId { get; set; }
        public bool IsRead { get; set; }
        public bool IsAccepted { get; set; }

        public Notification? Notification { get; set; }
        public Invitation? Invitation { get; set; }
    }
}
