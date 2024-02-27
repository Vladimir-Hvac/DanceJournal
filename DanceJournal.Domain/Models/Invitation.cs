namespace DanceJournal.Domain.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int LessonId { get; set; }
        public bool IsSatisfied { get; set; }
        public DateTime CreationTime { get; set; } = new();

        public User? Creator { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
