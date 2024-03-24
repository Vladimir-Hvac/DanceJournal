using DanceJournal.Services.BS_ClientManagement.Abstractions;

namespace DanceJournal.Services.ClientManagementService
{
    public class ClientManagementService : IClientManagement
    {
        private readonly IClientManagementRepository _repositoryClient;
        private readonly IStaffManagentRepository _repositoryStaff;


        public ClientManagementService(IClientManagementRepository repository, IStaffManagentRepository repositoryStaff)
        {
            _repositoryClient = repository;
            _repositoryStaff = repositoryStaff;
        }
        public async Task<User> GetClientByIdAsync(int userId, CancellationToken cancelationToken)
        {
            return await _repositoryClient.GetEntityOrDefault(userId, cancelationToken);
        }
        public async Task<List<User>> GetAllClientsAsync(CancellationToken cancelationToken)
        {
            return await _repositoryClient.GetAllEntity(cancelationToken);
        }
        public async Task<User> CreateClientAsync(User user,CancellationToken cancellationToken)
        {
            return await _repositoryClient.CreateEntity(user, cancellationToken);
        }
        public async Task<User> UpdateClientAsync(User user, CancellationToken cancellationToken)
        {
            return await _repositoryClient.UpdateEntity(user, cancellationToken);
        }
        public async Task<bool> DeleteClientAsync(int userId, CancellationToken cancellationToken)
        {
            return await _repositoryClient.DeleteEntity(userId, cancellationToken);
        }
        public async Task<List<User>> GetAllStaffAsync(CancellationToken cancellationToken)
        {
            return await _repositoryStaff.GetAllEntity(cancellationToken);
        }
        public async Task<User> ChangeLevelUserAsync(int userId, int levelId, CancellationToken cancellationToken)
        {
            return await _repositoryStaff.UpdateLevelEntity(userId, levelId, cancellationToken);
        }

    }
}

