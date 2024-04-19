namespace DanceJournal.Services.BS_ClientManagement.Abstractions;

public interface IClientManagementRepository
{
    Task<User> GetEntityOrDefault(int userId,CancellationToken cancellationToken);
    Task<List<User>> GetAllEntity( CancellationToken cancellationToken);
    Task<List<Role>> GetAllRoles();
    Task<User> CreateEntity(User user,CancellationToken cancellationToken);
    Task<User> UpdateEntity(User user, CancellationToken cancellationToken);
    Task<bool> DeleteEntity(int userId, CancellationToken cancellationToken);
} 
