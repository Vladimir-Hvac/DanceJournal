using DanceJournal.Services.BS_AbonementManagement.Abstractions;

namespace DanceJournal.Services.BS_AbonementManagement
{

    public class AbonementService : IAbonementService
    {
        private readonly IAbonementRepository _repository;

        public AbonementService(IAbonementRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Subscription>> GetAllAbonementsAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllAbonementsAsync(cancellationToken);
        }
        public async Task<List<SubscriptionType>> GetAllTypeAbonementsAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllTypeAbonementsAsync(cancellationToken);
        }
        public async Task<Subscription> CreateAbonementsAsync(Subscription sub, int user_id, CancellationToken cancellationToken)
        {
            return await _repository.CreateAbonementsAsync(sub, user_id, cancellationToken);
        }
        public async Task<bool> DeleteAbonementsAsync(int id, CancellationToken cancellationToken)
        {

            return await _repository.DeleteAbonementsAsync(id, cancellationToken);

        }
        public async Task<SubscriptionType> CreateTypeAbonementsAsync(SubscriptionType type, CancellationToken cancellationToken)
        {
            return await _repository.CreateTypeAbonementsAsync(type, cancellationToken);
        }
        public async Task<bool> DeleteTypeAbonementsAsync(int id, CancellationToken cancellationToken)
        {
            return await _repository.DeleteTypeAbonementsAsync(id, cancellationToken);
        }
    }
}
