public interface ILessonPlanning
{
    public Task<IEnumerable<LP_Lesson>> GetAllLessons(); 
    public Task<LP_Lesson> GetLesson(Guid Id);
    public Task AddLesson(LP_Lesson lesson);
    public Task UpdateLesson(LP_Lesson lesson);
    public Task RemoveLesson(Guid id);
    public Task<IEnumerable<LP_Room>> GetAllRooms();
}