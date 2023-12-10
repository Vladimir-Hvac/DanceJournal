public interface IRepository
{
    public Task<IEnumerable<RepositoryLesson>> GetAllLessons();
    public Task<IEnumerable<RepositoryRoom>> GetAllRooms();

    public Task<RepositoryLesson> GetLesson(Guid Id);
    public Task<RepositoryLessonType> GetLessonType(Guid Id);
    public Task<RepositoryRoom> GetRoom(Guid Id);
    public Task<RepositoryLevel> GetLevel(Guid Id);

    public Task AddLesson(RepositoryLesson lesson);

    public Task UpdateLesson(RepositoryLesson lesson);

    public Task RemoveLesson(Guid id);
}
