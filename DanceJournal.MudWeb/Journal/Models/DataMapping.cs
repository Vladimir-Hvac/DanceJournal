using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DanceJournal.MudWeb.Journal.Models
{
    public class DataMapping
    {
        private DanceJournalDbContext _dbContext;

        public DataMapping(DanceJournalDbContext dbContext)
        {
            _dbContext = dbContext;
            MappDbToDto();
            //JsonMapping();
            //SaveToDb();
        }

        public List<Lesson> LessonsDTO { get; set; }
        public List<LessonType> LessonTypesDTO { get; set; }
        public List<Room> RoomsDTO { get; set; }
        public List<User> UsersDTO { get; set; }
        public List<Role> RolesDTO { get; set; }
        public List<Subscription> SubscriptionsDTO { get; set; }
        public List<SubscriptionType> SubscriptionTypesDTO { get; set; }
        public List<LessonUser> LessonUsersDTO { get; set; }
        public List<Level> LevelsDTO { get; set; }

        private void MappDbToDto()
        {
            LessonsDTO = _dbContext.Lessons.ToList();
            LessonTypesDTO = _dbContext.LessonTypes.ToList();
            RoomsDTO = _dbContext.Rooms.ToList();
            UsersDTO = _dbContext.Users.ToList();
            RolesDTO = _dbContext.Roles.ToList();
            SubscriptionsDTO = _dbContext.Subscriptions.ToList();
            SubscriptionTypesDTO = _dbContext.SubscriptionTypes.ToList();
            LevelsDTO = _dbContext.Levels.ToList();
        }

        private void SaveToDb()
        {
            _dbContext.Lessons.AddRange(LessonsDTO);
            _dbContext.LessonTypes.AddRange(LessonTypesDTO);
            _dbContext.Rooms.AddRange(RoomsDTO);
            _dbContext.Users.AddRange(UsersDTO);
            _dbContext.Roles.AddRange(RolesDTO);
            _dbContext.Subscriptions.AddRange(SubscriptionsDTO);
            _dbContext.SubscriptionTypes.AddRange(SubscriptionTypesDTO);
            _dbContext.Levels.AddRange(LevelsDTO);
            _dbContext.SaveChanges();
        }

        private void JsonMapping()
        {
            LessonsDTO = JsonConvert.DeserializeObject<List<Lesson>>(
                File.ReadAllText("Journal/Resources/lessons.json")
            );
            LessonTypesDTO = JsonConvert.DeserializeObject<List<LessonType>>(
                File.ReadAllText("Journal/Resources/lessonTypes.json")
            );
            RoomsDTO = JsonConvert.DeserializeObject<List<Room>>(
                File.ReadAllText("Journal/Resources/rooms.json")
            );
            UsersDTO = JsonConvert.DeserializeObject<List<User>>(
                File.ReadAllText("Journal/Resources/users.json")
            );
            RolesDTO = JsonConvert.DeserializeObject<List<Role>>(
                File.ReadAllText("Journal/Resources/roles.json")
            );
            SubscriptionsDTO = JsonConvert.DeserializeObject<List<Subscription>>(
                File.ReadAllText("Journal/Resources/subscriptions.json")
            );
            SubscriptionTypesDTO = JsonConvert.DeserializeObject<List<SubscriptionType>>(
                File.ReadAllText("Journal/Resources/subscriptionTypes.json")
            );
            LevelsDTO = JsonConvert.DeserializeObject<List<Level>>(
                File.ReadAllText("Journal/Resources/levels.json")
            );
        }
    }
}
