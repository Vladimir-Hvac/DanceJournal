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

        public async Task BookRoom(int idLesson, int idRoom)
        {
            var lesson = await GetLessonAsync(idLesson);
            var room = await GetRoomAsync(idRoom);

            if (lesson != null && room != null)
            {
                lesson.Room = room;
                await _repository.UpdateLessonAsync(lesson);
            }
            else
            {
                throw new Exception("Не удалось забронировать зал для урока.");
            }
        }

        public async Task CreateLessonAsync(Lesson lesson)
        {
            await _repository.CreateLessonAsync(lesson);
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
        {
            var lessons = await _repository.GetAllLessonsAsync();
            if(lessons == null)
                return Enumerable.Empty<Lesson>();
            else
                return lessons;
        }

        public async Task<Lesson> GetLessonAsync(int id)
        {
            return await _repository.GetLessonAsync(id);
        }

        public async Task DeleteLesson(int id)
        {
            await _repository.DeleteLesson(id);
        }

        public async Task UpdateLessonAsync(Lesson lesson)
        {
            await _repository.UpdateLessonAsync(lesson);
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var rooms = await _repository.GetAllRoomsAsync();
            if (rooms == null)
                return Enumerable.Empty<Room>();
            else
                return rooms;
        }
        public async Task<Room> GetRoomAsync(int id)
        {
            return await _repository.GetRoomAsync(id);
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _repository.GetAllRoomsAsync();
        }

        public async Task<IEnumerable<LessonType>> GetAllLessonsTypesAsync()
        {
            var lessonTypes = await _repository.GetAllLessonTypesAsync();
            if (lessonTypes == null)
                return Enumerable.Empty<LessonType>();
            else
                return lessonTypes;
        }

        public async Task<LessonType> GetLessonTypeAsync(int id)
        {
            return await _repository.GetLessonTypeAsync(id);
        }

        public async Task CreateLessonTypeAsync(LessonType lessonType)
        {
            await _repository.CreateLessonTypeAsync(lessonType);
        }

        public async Task UpdateLessonTypeAsync(LessonType lessonType)
        {
            await _repository.UpdateLessonTypeAsync(lessonType);
        }

        public async Task DeleteLessonType(int id)
        {
            await _repository.DeleteLessonType(id);
        }

        public async Task<IEnumerable<LessonUser>> GetAllLessonsUsersAsync()
        {
            var lessonUsers = await _repository.GetAllLessonUsersAsync();
            if (lessonUsers == null)
                return Enumerable.Empty<LessonUser>();
            else
                return lessonUsers;
        }

        public async Task<LessonUser> GetLessonUserAsync(int id)
        {
            return await _repository.GetLessonUserAsync(id);
        }

        public async Task CreateLessonUserAsync(LessonUser lessonUser)
        {
            await _repository.CreateLessonUserAsync(lessonUser);
        }

        public async Task UpdateLessonUserAsync(LessonUser lessonUser)
        {
            await _repository.UpdateLessonUserAsync(lessonUser);
        }

        public async Task DeleteLessonUser(int id)
        {
            await _repository.DeleteLessonUser(id);
        }

        public async Task<IEnumerable<LessonUser>> GetAllLessonUsersByUserAsync(int userId)
        {
            var lessonUsers = await _repository.GetAllLessonUsersByUserAsync(userId);
            if (lessonUsers == null)
                return Enumerable.Empty<LessonUser>();
            else
                return lessonUsers;
        }

        public async Task<IEnumerable<LessonUser>> GetAllLessonUsersByLessonAsync(int lessonId)
        {
            var lessonUsers = await _repository.GetAllLessonUsersByLessonAsync(lessonId);
            if (lessonUsers == null)
                return Enumerable.Empty<LessonUser>();
            else
                return lessonUsers;
        }

        public async Task<LessonUser> GetLessonUserAsync(int userId, int lessonId)
        {
            return await _repository.GetLessonUserAsync(userId,lessonId);
        }

        public async Task<IEnumerable<Level>> GetAllLevelsAsync()
        {
            return await _repository.GetAllLevels();
        }
    }
}