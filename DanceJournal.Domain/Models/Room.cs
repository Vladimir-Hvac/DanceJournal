public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Lesson> Lessons { get; set; }
}
