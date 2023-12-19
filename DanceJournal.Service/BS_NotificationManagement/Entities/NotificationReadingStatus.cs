using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Service.BS_NotificationManagement.Entities
{
    public class NotificationReadingStatus
    {
        public int NitificationId { get; set; }
        public int ReceiverId { get; set; }
        public bool IsRead { get; set; }

        public Notification Notification { get; set; }
    }
}
