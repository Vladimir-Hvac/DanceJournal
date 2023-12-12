public interface IRepository
{
    public Task<IEnumerable<RepositoryLesson>> GetAllLessons();
    public Task<IEnumerable<RepositoryRoom>> GetAllRooms();

    public Task<RepositoryLesson> GetLesson(int Id);
    public Task<RepositoryLessonType> GetLessonType(int Id);
    public Task<RepositoryRoom> GetRoom(int Id);
    public Task<RepositoryLevel> GetLevel(int Id);

    public Task AddLesson(RepositoryLesson lesson);

    public Task UpdateLesson(RepositoryLesson lesson);

    public Task RemoveLesson(int id);
}
