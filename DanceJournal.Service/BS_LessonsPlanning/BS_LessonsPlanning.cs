using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace DanceJournal.Services.BS_LessonsPlanning
{
    public class BS_LessonsPlanning : ILessonPlanning
    {
        private readonly ILessonPlanningRepository _repository;

        public BS_LessonsPlanning(ILessonPlanningRepository repository)
        {
            _repository = repository;
        }

        public async Task BookRoom(Lesson lesson, Room room)
        {
            if (room == null)
            {
                lesson.RoomId = 0;
                await UpdateLesson(lesson);
            }
            else
            {
                lesson.RoomId = room.Id;
                await UpdateLesson(lesson);
            }
        }

        public async Task AddLesson(Lesson lesson)
        {
            await _repository.AddEntityAsync(lesson);
        }

        public async Task RemoveLesson(Lesson lesson)
        {
            await _repository.RemoveEntityAsync(lesson);
        }

        public IEnumerable<Lesson> GetAllLessons()
        {
            var result = _repository.GetAllEntitiesByType<Lesson>();

            if (result != null)
                return result;
            else
                throw new Exception("Lessons not found.");
        }

        public IEnumerable<Room> GetAllRooms()
        {
            var result = _repository.GetAllEntitiesByType<Room>();

            if (result != null)
                return result;
            else
                throw new Exception("Rooms not found.");
        }

        public Lesson GetLesson(Lesson lesson)
        {
            var result = _repository.GetEntityOrDefault(lesson);

            if (result != null)
                return result;
            else
                throw new Exception("Lesson not found.");
        }

        public Task UpdateLesson(Lesson lesson)
        {
            if (_repository.GetEntityOrDefault(lesson) != null)
                return _repository.UpdateEntityAsync(lesson);
            else
                return AddLesson(lesson);
        }
    }
}
