using DanceJournal.Service.BS_StaffManagement.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DanceJournal.Service.BS_StaffManagement
{
    public class StaffManagementService :IStaffManagement
    {
        private DanceJournalDbContext _dbContext;
        private readonly int _roleForStaff;

        public StaffManagementService(DanceJournalDbContext dbContext)
        {
            _dbContext = dbContext;
            _roleForStaff = 3;
        }
        public async Task<List<User>> GetAllStaffAsync()
        {
            var staffUsers =await _dbContext.Users.Where(item=>item.RoleId == _roleForStaff).ToListAsync();
            return staffUsers;
        }
        public async Task<User> GetStaffByIdAsync(int userId)
        {
            var staffUser = await _dbContext.Users.Where(item => item.RoleId == _roleForStaff & item.Id == userId).FirstAsync();
            if (staffUser == null)
            {
                throw new Exception("По переданному id не найден пользователь");
            }
             return staffUser;

        }
        public async Task<User> ChangeLevelUserAsync(int userId, int levelId)
        {
            var userStaff = await GetStaffByIdAsync(userId);
            userStaff.LevelId = levelId;
            _dbContext.Entry(userStaff).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return userStaff;


        }
    }
}
