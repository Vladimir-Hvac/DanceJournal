public interface ILessonPlanning
{ 
    public Task<IEnumerable<Lesson>> GetAllLessonsAsync();
    public Task<Lesson> GetLessonAsync(int id);
    public Task CreateLessonAsync(Lesson lesson);
    public Task UpdateLessonAsync(Lesson lesson);
    public Task DeleteLesson(int id);

    public Task<IEnumerable<Room>> GetAllRoomsAsync();
    public Task<Room> GetRoomAsync(int id);
    public Task BookRoom(int idLesson, int idRoom);

    public Task<IEnumerable<LessonType>> GetAllLessonsTypesAsync();
    public Task<LessonType> GetLessonTypeAsync(int id);
    public Task CreateLessonTypeAsync(LessonType lessonType);
    public Task UpdateLessonTypeAsync(LessonType lessonType);
    public Task DeleteLessonType(int id);
}
