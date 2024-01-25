using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Domain.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public bool IsAccepted { get; set; }
    }
}
