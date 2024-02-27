namespace DanceJournal.Services.BS_LessonsPlanning.Interfaces
{
    public interface ILessonPlanningRepository
    {
        public Task<Lesson> GetLessonAsync(int id);
        public Task<IEnumerable<Lesson>> GetAllLessonsAsync();
        public Task<Lesson> CreateLessonAsync(Lesson lesson);
        public Task<Lesson> UpdateLessonAsync(Lesson lesson);
        public Task DeleteLesson(int id);

        public Task<IEnumerable<Room>> GetAllRoomsAsync();
        public Task<Room> GetRoomAsync(int id);

        public Task<LessonType> GetLessonTypeAsync(int id);
        public Task<IEnumerable<LessonType>> GetAllLessonTypesAsync();
        public Task<LessonType> CreateLessonTypeAsync(LessonType lessonType);
        public Task<LessonType> UpdateLessonTypeAsync(LessonType lessonType);
        public Task DeleteLessonType(int id);


        public Task<LessonUser> GetLessonUserAsync(int id);
        public Task<IEnumerable<LessonUser>> GetAllLessonUsersAsync();
        public Task<LessonUser> CreateLessonUserAsync(LessonUser lessonUser);
        public Task<LessonUser> UpdateLessonUserAsync(LessonUser lessonUser);
        public Task DeleteLessonUser(int id);

        public Task<LessonUser> GetLessonUserAsync(int userId,int lessonId);
        public Task<IEnumerable<LessonUser>> GetAllLessonUsersByUserAsync(int userId);
        public Task<IEnumerable<LessonUser>> GetAllLessonUsersByLessonAsync(int lessonId);

    }
}