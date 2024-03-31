using System.Threading;
using DanceJournal.Services.BS_ClientManagement.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DanceJournal.Infrastructure.Repository.Implementation
{
    public class ClientRepository : IClientManagementRepository
    {
        private DanceJournalDbContext _dbContext;
        public ClientRepository(DanceJournalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetEntityOrDefault(int userId, CancellationToken cancellationToken)
        {
            var client = await _dbContext.Users.Where(item=>item.Id == userId).FirstAsync(cancellationToken);
            if (client == null)
            {
                throw new Exception("По переданному id не найден пользователь");
            }
            else {
                return client;
            };
        }
        public async Task<List<User>> GetAllEntity( CancellationToken cancellationToken)
        {
            var clients = await _dbContext.Users.ToListAsync(cancellationToken);
            return clients;
        }
        public async Task<User> CreateEntity(User user,CancellationToken cancellationToken)
        {
            try
            {
                await _dbContext.Users.AddAsync(user,cancellationToken);
                _dbContext.SaveChanges();
                return user;

            }catch (Exception ex)
            {
                throw new Exception("Ошибка при создании пользователя",ex);
            }
        }
        public async Task<User> UpdateEntity(User user,CancellationToken cancellationToken)
        {
            try
            {
                _dbContext.Users.Update(user).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return user;
            }
            catch  (Exception ex) {
                throw new Exception("Не удалось обновить пользователя", ex);
            }
            
        }
        public async Task<bool> DeleteEntity(int userId, CancellationToken cancellationToken)
        {
            try
            {   
                var entity = await GetEntityOrDefault(userId,cancellationToken);
                _dbContext.Users.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Не удалось обновить пользователя", ex);
            }

        }

        public async Task<List<Role>> GetAllRoles()
        {
            var roles = await _dbContext.Roles.ToListAsync();
            return roles;
        }
    }
}
