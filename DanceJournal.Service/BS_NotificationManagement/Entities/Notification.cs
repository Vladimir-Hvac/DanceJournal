using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Service.BS_NotificationManagement.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Body { get; set; } = string.Empty;
        public int CreatorId { get; set; }

        public DateTime EntryDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
