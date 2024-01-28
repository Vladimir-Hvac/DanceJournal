using DanceJournal.Services.BS_LessonsPlanning.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DanceJournal.Infrastructure.Repository.Implementation
{
    public class LessonPlanningRepository : ILessonPlanningRepository
    {
        private DanceJournalDbContext _dbContext;
        public LessonPlanningRepository(DanceJournalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Lessons
        public async Task<Lesson> GetLessonAsync(int id,CancellationToken ct)
        {
            var lesson = await _dbContext.Lessons.Where(i => i.Id == id).FirstOrDefaultAsync(ct);
            if (lesson == null)
                throw new Exception("Ошибка при получении урока.");
            else
                return lesson;
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync(CancellationToken ct)
        {
            var lessons = await _dbContext.Lessons.ToListAsync(ct);
            if (lessons == null)
                throw new Exception("Ошибка при получении всех уроков.");
            else
                return lessons;
        }

        public async Task<Lesson> CreateLessonAsync(Lesson lesson, CancellationToken ct)
        {
            try
            {
                await _dbContext.Lessons.AddAsync(lesson, ct);
                await _dbContext.SaveChangesAsync(ct);
                return lesson;

            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при создании урока.", e);
            }
        }

        public async Task<Lesson> UpdateLessonAsync(Lesson lesson, CancellationToken ct)
        {
            try
            {
                _dbContext.Lessons.Update(lesson).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync(ct);
                return lesson;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении урока", ex);
            }
        }

        public async Task DeleteLesson(int id)
        {
            try
            {
                CancellationToken ct = new CancellationToken();
                var lesson = await GetLessonAsync(id,ct);
                _dbContext.Lessons.Remove(lesson);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при удалении урока", ex);
            }
        }
        #endregion

        #region Rooms

        public async Task<IEnumerable<Room>> GetAllRoomsAsync(CancellationToken ct)
        {
            var rooms = await _dbContext.Rooms.ToListAsync(ct);
            if (rooms == null)
                throw new Exception("Ошибка при получении всех залов.");
            else
                return rooms;
        }
        public async Task<Room> GetRoomAsync(int id, CancellationToken ct)
        {
            var room = await _dbContext.Rooms.Where(i => i.Id == id).FirstOrDefaultAsync(ct);
            if (room == null)
                throw new Exception("Ошибка при получении зала.");
            else
                return room;
        }
        #endregion
    }
}
