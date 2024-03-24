namespace DanceJournal.Services.BS_ClientManagement.Abstractions
{
    public interface IStaffManagentRepository
    {
        Task<List<User>> GetAllEntity(CancellationToken cancellationToken);
        Task<User> GetEntityOrDefault(int userId, CancellationToken cancellationToken);
        Task<User> UpdateLevelEntity(int userId, int levelId, CancellationToken cancellationToken);

    }
}
