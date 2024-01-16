public interface IRepository
{
    public Task<IEnumerable<Lesson>> GetAllLessons();
    public Task<IEnumerable<Room>> GetAllRooms();

    public Task<Lesson> GetLesson(int Id);
    public Task<LessonType> GetLessonType(int Id);
    public Task<Room> GetRoom(int Id);
    public Task<Level> GetLevel(int Id);

    public Task AddLesson(Lesson lesson);

    public Task UpdateLesson(Lesson lesson);

    public Task RemoveLesson(int id);
}
