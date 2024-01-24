namespace DanceJournal.Services.BS_ClientManagement.Abstractions;

public interface IClientManagentRepository
{
    Task<User> GetEntityOrDefault(int userId,CancellationToken cancellationToken);
    Task<List<User>> GetAllEntity( CancellationToken cancellationToken);
    Task<User> CreateEntity(User user,CancellationToken cancellationToken);
    Task<User> UpdateEntity(User user, CancellationToken cancellationToken);
    Task<bool> DeleteEntity(int userId, CancellationToken cancellationToken);
} 
