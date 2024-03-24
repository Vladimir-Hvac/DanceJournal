using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Services.BS_AbonementManagement.Abstractions
{
    public interface IAbonementRepository
    {
        Task<List<Subscription>> GetAllAbonementsAsync(CancellationToken cancellationToken);
        Task<List<SubscriptionType>> GetAllTypeAbonementsAsync(CancellationToken cancellationToken);
        Task<Subscription> CreateAbonementsAsync(Subscription sub, int user_id, CancellationToken cancellationToken);
        Task<bool> DeleteAbonementsAsync(int id, CancellationToken cancellationToken);
        Task<SubscriptionType> CreateTypeAbonementsAsync(SubscriptionType type, CancellationToken cancellationToken);
        Task<bool> DeleteTypeAbonementsAsync(int id, CancellationToken cancellationToken);
    }
}
