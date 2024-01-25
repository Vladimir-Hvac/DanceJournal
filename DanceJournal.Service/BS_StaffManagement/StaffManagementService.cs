using DanceJournal.Services.BS_ClientManagement.Abstractions;
using DanceJournal.Services.BS_StaffManagement.Abstractions;

namespace DanceJournal.Services.StaffManagement
{
    public class StaffManagementService : IStaffManagement
    {
        private readonly IStaffManagentRepository _repository;

        public StaffManagementService(IStaffManagentRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<User>> GetAllStaffAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllEntity(cancellationToken);
        }
        public async Task<User> GetStaffByIdAsync(int userId, CancellationToken cancellationToken)
        {
            return await _repository.GetEntityOrDefault(userId, cancellationToken);
        }
        public async Task<User> ChangeLevelUserAsync(int userId, int levelId, CancellationToken cancellationToken)
        {
            return await _repository.UpdateLevelEntity(userId,levelId, cancellationToken);
        }
    }
}




//using DanceJournal.Infrastructure.Repository;
//using DanceJournal.Domain.BS_StaffManagement.Abstractions;

//namespace DanceJournal.Domain.BS_StaffManagement
//{
//    public class StaffManagementService : IStaffManagement
//    {
//        private DanceJournalRepository _repository;

//        public StaffManagementService(DanceJournalRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<List<User>> GetAllStaffAsync()
//        {
//            List<User> staffUsers = await _repository.GetAllStaffAsync();
//            return staffUsers;
//        }

//        public async Task<User> GetStaffByIdAsync(int userId)
//        {
//            User staffUser = await _repository.GetStaffByIdAsync(userId);
//            return staffUser;
//        }

//        public async Task<User> ChangeLevelUserAsync(int userId, int levelId)
//        {
//            User userStaff = await _repository.ChangeLevelUserAsync(userId, levelId);
//            return userStaff;
//        }
//    }
//}
