namespace DanceJournal.Services.BS_LessonsPlanning
{
    public interface ILessonPlanningRepository
    {
        public Task AddEntityAsync(Lesson lesson);
        public Task RemoveEntityAsync(Lesson lesson);
        public List<T> GetAllEntitiesByType<T>();
        public T GetEntityOrDefault<T>(T lesson);
        public Task UpdateEntityAsync(Lesson lesson);
    }
}
