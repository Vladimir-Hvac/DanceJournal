using System.ComponentModel.DataAnnotations.Schema;

public class LessonUser
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int LessonId { get; set; }
    public bool IsVisit { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("LessonId")]
    public Lesson Lesson { get; set; }
}
