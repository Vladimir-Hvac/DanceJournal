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
        public async Task<Lesson> GetLessonAsync(int id)
        {
            var lesson = await _dbContext.Lessons.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (lesson == null)
                throw new Exception("Ошибка при получении урока.");
            else
                return lesson;
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
        {
            var lessons = await _dbContext.Lessons.ToListAsync();
            if (lessons == null)
                throw new Exception("Ошибка при получении всех уроков.");
            else
                return lessons;
        }

        public async Task<Lesson> CreateLessonAsync(Lesson lesson)
        {
            try
            {
                await _dbContext.Lessons.AddAsync(lesson);
                await _dbContext.SaveChangesAsync();
                return lesson;
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при создании урока.", e);
            }
        }

        public async Task<Lesson> UpdateLessonAsync(Lesson lesson)
        {
            try
            {
                _dbContext.Lessons.Update(lesson).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
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
                var lesson = await GetLessonAsync(id);
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

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            var rooms = await _dbContext.Rooms.ToListAsync();
            if (rooms == null)
                throw new Exception("Ошибка при получении всех залов.");
            else
                return rooms;
        }

        public async Task<Room> GetRoomAsync(int id)
        {
            var room = await _dbContext.Rooms.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (room == null)
                throw new Exception("Ошибка при получении зала.");
            else
                return room;
        }
        #endregion

        #region LessonTypes

        public async Task<LessonType> GetLessonTypeAsync(int id)
        {
            var lessonType = await _dbContext.LessonTypes.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (lessonType == null)
                throw new Exception("Ошибка при получении типа урока.");
            else
                return lessonType;
        }

        public async Task<IEnumerable<LessonType>> GetAllLessonTypesAsync()
        {
            var lessonTypes = await _dbContext.LessonTypes.ToListAsync();
            if (lessonTypes == null)
                throw new Exception("Ошибка при получении всех типов уроков.");
            else
                return lessonTypes;
        }

        public async Task<LessonType> CreateLessonTypeAsync(LessonType lessonType)
        {
            try
            {
                await _dbContext.LessonTypes.AddAsync(lessonType);
                await _dbContext.SaveChangesAsync();
                return lessonType;
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при создании типа урока.", e);
            }
        }

        public async  Task<LessonType> UpdateLessonTypeAsync(LessonType lessonType)
        {
            try
            {
                _dbContext.LessonTypes.Update(lessonType).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return lessonType;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении типа урока", ex);
            }
        }

        public async Task DeleteLessonType(int id)
        {
            try
            {
                var lessonType = await GetLessonTypeAsync(id);
                _dbContext.LessonTypes.Remove(lessonType);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при удалении типа урока", ex);
            }
        }

        #endregion

        #region LessonUsers
        public async Task<LessonUser> GetLessonUserAsync(int id)
        {
            var lessonUser = await _dbContext.LessonUsers.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (lessonUser == null)
                throw new Exception("Ошибка при получении записи посещения урока.");
            else
                return lessonUser;
        }

        public async Task<IEnumerable<LessonUser>> GetAllLessonUsersAsync()
        {
            var lessonUsers = await _dbContext.LessonUsers.ToListAsync();
            if (lessonUsers == null)
                throw new Exception("Ошибка при получении всех записей посещения уроков.");
            else
                return lessonUsers;
        }

        public async Task<LessonUser> CreateLessonUserAsync(LessonUser lessonUser)
        {
            try
            {
                await _dbContext.LessonUsers.AddAsync(lessonUser);
                await _dbContext.SaveChangesAsync();
                return lessonUser;
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при создании типа урока.", e);
            }
        }

        public async Task<LessonUser> UpdateLessonUserAsync(LessonUser lessonUser)
        {
            try
            {
                _dbContext.LessonUsers.Update(lessonUser).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return lessonUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении записи посещения урока", ex);
            }
        }

        public async Task DeleteLessonUser(int id)
        {
            try
            {
                var lessonUser = await GetLessonUserAsync(id);
                _dbContext.LessonUsers.Remove(lessonUser);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при удалении записи посещения урока", ex);
            }
        }

        public async Task<LessonUser> GetLessonUserAsync(int userId, int lessonId)
        {
            var lessonUser = await _dbContext.LessonUsers.Where(i => i.UserId == userId && i.LessonId == lessonId ).FirstOrDefaultAsync();
            if (lessonUser == null)
                throw new Exception("Ошибка при получении записи посещения урока.");
            else
                return lessonUser;
        }

        public async Task<IEnumerable<LessonUser>> GetAllLessonUsersByUserAsync(int userId)
        {
            var lessonUsers = await _dbContext.LessonUsers.Where(i=>i.UserId == userId).ToListAsync();
            if (lessonUsers == null)
                throw new Exception("Ошибка при получении всех записей посещения уроков пользователя.");
            else
                return lessonUsers;
        }

        public async Task<IEnumerable<LessonUser>> GetAllLessonUsersByLessonAsync(int lessonId)
        {
            var lessonUsers = await _dbContext.LessonUsers.Where(i => i.LessonId == lessonId).ToListAsync();
            if (lessonUsers == null)
                throw new Exception("Ошибка при получении всех записей посещения урока.");
            else
                return lessonUsers;
        }

        #endregion
    }
}
