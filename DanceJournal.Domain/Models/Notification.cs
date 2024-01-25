using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Domain.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public bool IsRead { get; set; }
        public string Body { get; set; } = string.Empty;
        public DateTime EntryDateTime { get; set; }
        public bool IsDeleted { get; set; }

        public Invitation? Invitation { get; set; }
    }
}
