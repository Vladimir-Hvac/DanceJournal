using DanceJournal.Services.BS_StaffManagement.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Infrastructure.Repository.Implementation
{
    public class StaffRepository: IStaffManagentRepository
    {
        private DanceJournalDbContext _dbContext;
        public StaffRepository(DanceJournalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<User>> GetAllEntity(CancellationToken cancellationToken)
        {
            var staffUsers = await _dbContext.Users.Where(item=> item.RoleId == 3).ToListAsync(cancellationToken);
            return staffUsers;
        }
        public async Task<User> GetEntityOrDefault(int userId, CancellationToken cancellationToken) 
        {
            var user = await _dbContext.Users.Where(item => item.RoleId == 3 & item.Id == userId).FirstOrDefaultAsync(cancellationToken);
            if (user == null)
            {
                throw new Exception("По данному id сотрудник не найден");
            }
            return user;
        }
        public async Task<User> UpdateLevelEntity(int userId, int levelId, CancellationToken cancellationToken)
        {
            var entity = await GetEntityOrDefault(userId, cancellationToken);
            entity.RoleId = levelId;
            _dbContext.Users.Update(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
