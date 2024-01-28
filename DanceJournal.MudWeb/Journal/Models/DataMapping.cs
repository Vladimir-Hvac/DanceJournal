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

       

       
        internal string GetLessonTypeName(int Id)
        {
            return LessonTypesDTO.FirstOrDefault(x => x.Id == Id).Name;
        }

        internal string GetRoomName(int id)
        {
            return RoomsDTO.FirstOrDefault(x => x.Id == id).Name;
        }

        internal string GetLevelTitle(int id)
        {
            return LevelsDTO.FirstOrDefault(x => x.Id == id).Title;
        }

        internal LessonType GetLessonType(int Id)
        {
            return LessonTypesDTO.FirstOrDefault(x => x.Id == Id);
        }

        internal Room GetRoom(int id)
        {
            return RoomsDTO.FirstOrDefault(x => x.Id == id);
        }

        internal Level GetLevel(int id)
        {
            return LevelsDTO.FirstOrDefault(x => x.Id == id);
        }

        internal Subscription GetSubscription(int subscriptionId)
        {
            return SubscriptionsDTO.FirstOrDefault(x => x.Id == subscriptionId);
        }

        internal Role GetRole(int roleId)
        {
            return RolesDTO.FirstOrDefault(x => x.Id == roleId);
        }

        internal SubscriptionType GetSubscriptionType(int subscriptionTypeId)
        {
            return SubscriptionTypesDTO.FirstOrDefault(x => x.Id == subscriptionTypeId);
        }
    }
}
