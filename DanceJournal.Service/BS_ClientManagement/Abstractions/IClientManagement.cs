namespace DanceJournal.Services.BS_ClientManagement.Abstractions
{
    public interface IClientManagement
    {
        Task<User> GetClientByIdAsync(int userId,CancellationToken cancellationToken);
        Task<List<User>> GetAllClientsAsync(CancellationToken cancellationToken);
        Task<User> CreateClientAsync(User user,CancellationToken cancellationToken);
        Task<User> UpdateClientAsync(User user,CancellationToken cancellationToken);
        Task<bool> DeleteClientAsync(int userId, CancellationToken cancellationToken);
    }
}
