using DanceJournal.Services.BS_AbonementManagement.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Data;


//print("Вот тут у вас упадет с ошибкой - удали эту строку,  но вначале прочитай ниже")

//// Изменения!
//// Изменил модель с Типом абонемента - добавил поле IsActive
//// Изменил модель пользователя, сделал поле подписки необязательным(чтобы при удалении подписки выставить челу null)
//// Если я правильно понял 1 подписка = 1 человек, если всё так - то норм, если нет - кое что подправлю
//// Миграцию не делал
//// P.S. Пару запятых потерял(и пару дефисов), потом найду-верну

namespace DanceJournal.Infrastructure.Repository.Implementation
{
    public class AbonementRepository : IAbonementRepository
    {
        private DanceJournalDbContext _dbContext;
        public AbonementRepository(DanceJournalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Subscription>> GetAllAbonementsAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Subscriptions.ToListAsync(cancellationToken);
        }
        public async Task<List<SubscriptionType>> GetAllTypeAbonementsAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SubscriptionTypes
                .Where(item => item.IsActive == true)
                .ToListAsync(cancellationToken);
        }
        public async Task<SubscriptionType> CreateTypeAbonementsAsync(SubscriptionType type, CancellationToken cancellationToken)
        {
            _dbContext.SubscriptionTypes.Add(type);
            await _dbContext.SaveChangesAsync(cancellationToken);
            var data = await _dbContext.SubscriptionTypes.FindAsync(type, cancellationToken);
            return data != null ? data : type;
        }
        public async Task<bool> DeleteTypeAbonementsAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _dbContext.SubscriptionTypes.FindAsync(id, cancellationToken);

            if (data == null)
            {
                throw new Exception("TODO: ADD NotFindEntityByIdException");
            }

            data.IsActive = false;
            _dbContext.SubscriptionTypes.Update(data).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
        public async Task<bool> DeleteAbonementsAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _dbContext.Subscriptions.FindAsync(id, cancellationToken);
            if (data == null)
            {
                throw new Exception("TODO: ADD NotFindEntityByIdException");
            }
            data.FinishDay = DateTime.Today;
            _dbContext.Subscriptions.Update(data).State = EntityState.Modified;

            var userWithThisSubs = await _dbContext.Users
                .FirstOrDefaultAsync(item => item.SubscriptionId == id);

            if (userWithThisSubs != null)
            {
                userWithThisSubs.SubscriptionId = default;
                _dbContext.Users.Update(userWithThisSubs).State = EntityState.Modified;

            }
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
        public async Task<Subscription> CreateAbonementsAsync(Subscription sub, int user_id, CancellationToken cancellationToken)
        {
            _dbContext.Subscriptions.Add(sub);
            await _dbContext.SaveChangesAsync(cancellationToken);
            var data = await _dbContext.Subscriptions.FindAsync(sub, cancellationToken);


            var user = await _dbContext.Users.FindAsync(user_id, cancellationToken);
            if (user == null)
            {
                throw new Exception("Todo ADD NotFindUserException");
            }
            if (data == null)
            {
                throw new Exception("Todo ADD NotFindEntityByIdException");
            }

            user.SubscriptionId = data.Id;
            _dbContext.Users.Update(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return data != null ? data : sub;
        }
    }
}
