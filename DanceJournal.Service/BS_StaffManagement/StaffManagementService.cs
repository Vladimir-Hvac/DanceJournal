using DanceJournal.Service.BS_StaffManagement.Abstractions;
using DanceJournal.Infrastructure.Repository;

namespace DanceJournal.Service.BS_StaffManagement
{
    public class StaffManagementService :IStaffManagement
    {
        private DanceJournalRepository _repository;

        public StaffManagementService( DanceJournalRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<List<User>> GetAllStaffAsync()
        {
            List<User> staffUsers = await _repository.GetAllStaffAsync();
            return staffUsers;
        }
        public async Task<User> GetStaffByIdAsync(int userId)
        {
             User staffUser = await _repository.GetStaffByIdAsync(userId);
             return staffUser;

        }
        public async Task<User> ChangeLevelUserAsync(int userId, int levelId)
        {
            User userStaff = await _repository.ChangeLevelUserAsync(userId, levelId);
            return userStaff;


        }
    }
}
