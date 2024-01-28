using DanceJournal.Services.BS_LessonsPlanning.Interfaces;

namespace DanceJournal.Services.BS_LessonsPlanning
{
    public class BS_LessonsPlanning : ILessonPlanning
    {
        private readonly ILessonPlanningRepository _repository;

        public BS_LessonsPlanning(ILessonPlanningRepository repository)
        {
            _repository = repository;
        }

        public async Task BookRoom(int idLesson, int idRoom,CancellationToken ct)
        {
            var lesson = await GetLessonAsync(idLesson, ct);
            var room = await GetRoomAsync(idRoom, ct);

            if (lesson != null && room != null)
            {
                lesson.Room = room;
                await _repository.UpdateLessonAsync(lesson, ct);
            }
            else
            {
                throw new Exception("Не удалось забронировать зал для урока.");
            }
        }

        public async Task CreateLessonAsync(Lesson lesson, CancellationToken ct)
        {
            await _repository.CreateLessonAsync(lesson, ct);
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync(CancellationToken ct)
        {
            var lessons = await _repository.GetAllLessonsAsync(ct);
            if(lessons == null)
                return Enumerable.Empty<Lesson>();
            else
                return lessons;
        }

        public async Task<Lesson> GetLessonAsync(int id, CancellationToken ct)
        {
            return await _repository.GetLessonAsync(id, ct);
        }

        public async Task DeleteLesson(int id)
        {
            await _repository.DeleteLesson(id);
        }

        public async Task UpdateLessonAsync(Lesson lesson, CancellationToken ct)
        {
            await _repository.UpdateLessonAsync(lesson, ct);
        }

        public async Task<IEnumerable<Room>> GetAllRooms(CancellationToken ct)
        {
            var rooms = await _repository.GetAllRoomsAsync(ct);
            if (rooms == null)
                return Enumerable.Empty<Room>();
            else
                return rooms;
        }
        public async Task<Room> GetRoomAsync(int id, CancellationToken ct)
        {
            return await _repository.GetRoomAsync(id, ct);
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync(CancellationToken ct)
        {
            return await _repository.GetAllRoomsAsync(ct);
        }
    }
}
