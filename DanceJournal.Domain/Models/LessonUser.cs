using System.ComponentModel.DataAnnotations.Schema;

public class LessonUser
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int LessonId { get; set; }
    public bool IsVisit { get; set; }
    public User User { get; set; }
    public Lesson Lesson { get; set; }
}
