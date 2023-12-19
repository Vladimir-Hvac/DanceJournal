namespace DanceJournal.MudWeb.Journal.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int LessonTypeId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int LevelId { get; set; }

        public LessonType LessonType { get; set; }

        public User User { get; set; }

        public Room Room { get; set; }


        public Level Level { get; set; }
        public ICollection<LessonUser> LessonUsers { get; set; }
    }    
}

