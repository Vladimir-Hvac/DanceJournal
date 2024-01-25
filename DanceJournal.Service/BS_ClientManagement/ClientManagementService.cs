using DanceJournal.Services.BS_ClientManagement.Abstractions;

namespace DanceJournal.Services.ClientManagementService
{
    public class ClientManagementService : IClientManagement
    {
        private readonly IClientManagementRepository _repository;

        public ClientManagementService(IClientManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> GetClientByIdAsync(int userId, CancellationToken cancelationToken)
        {
            return await _repository.GetEntityOrDefault(userId, cancelationToken);
        }
        public async Task<List<User>> GetAllClientsAsync(CancellationToken cancelationToken)
        {
            return await _repository.GetAllEntity(cancelationToken);
        }
        public async Task<User> CreateClientAsync(User user,CancellationToken cancellationToken)
        {
            return await _repository.CreateEntity(user, cancellationToken);
        }
        public async Task<User> UpdateClientAsync(User user, CancellationToken cancellationToken)
        {
            return await _repository.UpdateEntity(user, cancellationToken);
        }
        public async Task<bool> DeleteClientAsync(int userId, CancellationToken cancellationToken)
        {
            return await _repository.DeleteEntity(userId, cancellationToken);
        }


    }
}

