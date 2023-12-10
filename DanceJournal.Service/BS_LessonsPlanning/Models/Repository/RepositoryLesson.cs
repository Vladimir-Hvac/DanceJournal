public class RepositoryLesson
{
    public Guid Id {get;set;}
    public Guid LessonTypeId {get;set;}
    public Guid UserId {get;set;}
    public Guid RoomId {get;set;}
    public DateTime Date {get;set;}
    public DateTime Start {get;set;}
    public DateTime Finish {get;set;}
    public Guid LevelId {get;set;}
}