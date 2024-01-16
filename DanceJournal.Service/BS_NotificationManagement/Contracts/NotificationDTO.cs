using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Service.BS_NotificationManagement.Contracts
{
    public class NotificationDTO
    {
        public bool IsRead { get; set; }
        public string Body { get; set; } = string.Empty;
        public bool IsAccepted { get; set; }
        public int ThreadId { get; set; }
    }
}
