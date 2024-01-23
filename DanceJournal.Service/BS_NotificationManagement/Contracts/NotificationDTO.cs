using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Services.BS_NotificationManagement.Contracts
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public bool IsRead { get; set; }
        public string Body { get; set; } = string.Empty;

        public InvitationDTO? InvitationDTO { get; set; }
    }
}
