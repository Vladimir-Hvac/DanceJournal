namespace DanceJournal.Domain.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int LessonId { get; set; }
        public int SatisfactionLimit { get; set; }
        public bool IsSatisfied { get; set; }
        public DateTime CreationTime { get; set; } = new();

        public User? Creator { get; set; }
        public Lesson? Lesson { get; set; }

        public bool IsOutdated()
        {
            TimeSpan threshold = TimeSpan.FromHours(1);

            DateTime start = Lesson != null ? Lesson.Start : DateTime.UtcNow;

            TimeSpan difference = DateTime.UtcNow - start;

            bool isOutdated = difference > threshold;

            return isOutdated;
        }

    }
}
