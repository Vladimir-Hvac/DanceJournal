public interface ILessonPlanning
{
    public Task<IEnumerable<LP_Lesson>> GetAllLessons();
    public Task<LP_Lesson> GetLesson(int Id);
    public Task AddLesson(LP_Lesson lesson);
    public Task UpdateLesson(LP_Lesson lesson);
    public Task RemoveLesson(int id);
    public Task<IEnumerable<LP_Room>> GetAllRooms();
}
