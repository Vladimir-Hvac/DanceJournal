using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public int Id { get; set; }
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public DateOnly BirthDate { get; set; }
    public bool IsDeleted { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int LevelId { get; set; }
    public int RoleId { get; set; }
    public int SubscriptionId { get; set; }
    public double Salary { get; set; }

    [ForeignKey("RoleId")]
    public Role Role { get; set; }

    [ForeignKey("SubscriptionId")]
    public Subscription Subscription { get; set; }

    [ForeignKey("LevelId")]
    public Level Level { get; set; }

    //public ICollection<Lesson> Lessons { get; set; }
    //public ICollection<LessonUser> LessonUsers { get; set; }
}
