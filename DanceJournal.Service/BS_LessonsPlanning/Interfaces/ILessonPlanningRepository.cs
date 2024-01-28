namespace DanceJournal.Services.BS_LessonsPlanning.Interfaces
{
    public interface ILessonPlanningRepository
    {
        public Task<Lesson> GetLessonAsync(int id, CancellationToken ct);
        public Task<IEnumerable<Lesson>> GetAllLessonsAsync(CancellationToken ct);
        public Task<Lesson> CreateLessonAsync(Lesson lesson, CancellationToken ct);
        public Task<Lesson> UpdateLessonAsync(Lesson lesson, CancellationToken ct);
        public Task DeleteLesson(int id);
        public Task<IEnumerable<Room>> GetAllRoomsAsync(CancellationToken ct);
        public Task<Room> GetRoomAsync(int id, CancellationToken ct);
    }
}