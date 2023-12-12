using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace DanceJournal.Service.BS_LessonsPlanning
{
    public class BS_LessonsPlanning : ILessonPlanning
    {
        private readonly IRepository _repo;

        public BS_LessonsPlanning(IRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<LP_Lesson>> GetAllLessons()
        {
            var lessons = new List<LP_Lesson>();
            var repo_lessons = await _repo.GetAllLessons();

            foreach (var l in repo_lessons)
            {
                var type = await _repo.GetLessonType(l.LessonTypeId);
                var room = await _repo.GetRoom(l.RoomId);
                var level = await _repo.GetLevel(l.LevelId);
                
                lessons.Add(new LP_Lesson(l.Id,type.Id,room.Id,l.Date,l.Start,l.Finish,level.Title)); 
            }

            return lessons;
        }

        public async Task<LP_Lesson> GetLesson(int Id)
        {
            var l = await _repo.GetLesson(Id);
            
            var type = await _repo.GetLessonType(l.LessonTypeId);
            var room = await _repo.GetRoom(l.RoomId);
            var level = await _repo.GetLevel(l.LevelId);
                
            return new LP_Lesson(l.Id,type.Id,room.Id,l.Date,l.Start,l.Finish,level.Title); 
        }

        public async Task AddLesson(LP_Lesson lesson)
        {
            if(await _repo.GetLesson(lesson.Id) == null)
            {
                var e = new RepositoryLesson
                {
                    Id = Guid.NewGuid(),
                    LessonTypeId = lesson.TypeId,
                    RoomId = lesson.RoomId,
                    Date = lesson.Date,
                    Start = lesson.Start,
                    Finish = lesson.Finish,
                    LevelId = lesson.Level
                };
                
                await _repo.AddLesson(e);
            }
        }

        public async Task UpdateLesson(LP_Lesson lesson)
        {
            if(await _repo.GetLesson(lesson.Id) != null)
            {
                var e = new RepositoryLesson
                {
                    Id = lesson.Id,
                    LessonTypeId = lesson.TypeId,
                    RoomId = lesson.RoomId,
                    Date = lesson.Date,
                    Start = lesson.Start,
                    Finish = lesson.Finish,
                    LevelId = lesson.Level
                };
                
                await _repo.UpdateLesson(e);
            }
        }
        public async Task RemoveLesson(int id)
        {
            await _repo.RemoveLesson(id);
        }
    
        public async Task<IEnumerable<LP_Room>> GetAllRooms()
        {
            var repo_rooms = await _repo.GetAllRooms();
            var rooms = new List<LP_Room>();

            foreach(var room in repo_rooms)
            {
                rooms.Add(new(room.Id,room.Name));
            }

            return rooms;
        } 
    }
}
