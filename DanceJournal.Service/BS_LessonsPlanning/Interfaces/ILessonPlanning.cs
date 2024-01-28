public interface ILessonPlanning
{ 
    public Task<IEnumerable<Lesson>> GetAllLessonsAsync(CancellationToken ct);

    public Task<Lesson> GetLessonAsync(int id,CancellationToken ct);

    public Task CreateLessonAsync(Lesson lesson,CancellationToken ct);
    public Task UpdateLessonAsync(Lesson lesson, CancellationToken ct);
    public Task DeleteLesson(int id);
    public Task<IEnumerable<Room>> GetAllRoomsAsync(CancellationToken ct);
    public Task<Room> GetRoomAsync(int id, CancellationToken ct);
    public Task BookRoom(int idLesson, int idRoom,CancellationToken ct);
}
