using System.ComponentModel.DataAnnotations.Schema;

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

    [ForeignKey("LessonTypeId")]
    public LessonType LessonType { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("RoomId")]
    public Room Room { get; set; }

    [ForeignKey("LevelId")]
    public Level Level { get; set; }
    public ICollection<LessonUser> LessonUsers { get; set; }
}
