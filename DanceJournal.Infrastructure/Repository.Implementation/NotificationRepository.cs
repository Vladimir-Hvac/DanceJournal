using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement.Gateways;
using Microsoft.EntityFrameworkCore;

namespace DanceJournal.Infrastructure.Repository.Implementation
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly DanceJournalDbContext _dbContext;
        public NotificationRepository(DanceJournalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddInvitation(Invitation invitation)
        {
            int result = -1;
            try
            {
                await _dbContext.AddAsync(invitation);
                await _dbContext.SaveChangesAsync();
                result = invitation.Id;
            }
            catch (Exception)
            {
                //TODO: Logging
            }
            return result;
        }

        public async Task<bool> AddInvitationNotificationStatuses(List<InvitationNotificationStatus> invitationNotificationStatuses)
        {
            bool result = false;
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _dbContext.AddRangeAsync(invitationNotificationStatuses);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(); // Rollback the transaction if there was an error
                                                   // Log the exception or handle it as needed

            }
            return result;
        }

        public async Task<int> AddNotification(Notification notification)
        {
            int result = -1;
            try
            {
                await _dbContext.AddAsync(notification);
                await _dbContext.SaveChangesAsync();
                result = notification.Id;
            }
            catch (Exception)
            {
                //TODO: Logging
            }
            return result;
        }

        public async Task<List<InvitationNotificationStatus>> GetAllInvitationNotificationStatuses()
        {
            List<InvitationNotificationStatus> result = new();
            try
            {
                result = await _dbContext.InvitationNotificationStatuses.ToListAsync();
            }
            catch (Exception)
            {
                //TODO: Logging
            }
            return result;
        }

        public async Task<List<Lesson>> GetAllLessons()
        {
            List<Lesson> result = new();
            try
            {
                result = await _dbContext.Lessons.ToListAsync();
            }
            catch (Exception)
            {
                //TODO: Logging
            }
            return result;
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> result = new();
            try
            {
                result = await _dbContext.Users.ToListAsync();
            }
            catch (Exception)
            {
                //TODO: Logging
            }
            return result;
        }

        public async Task<Invitation?> GetInvitation(int invitationId)
        {
            Invitation? result = null;
            try
            {
                result = await _dbContext.Invitations
                           .FirstOrDefaultAsync(i => i.Id == invitationId);
            }
            catch (Exception)
            {
                //TODO: Logging
            }
            return result;
        }

        public async Task<Lesson?> GetLesson(int lessonId)
        {
            Lesson? result = null;
            try
            {
                result = await _dbContext.Lessons
                           .FirstOrDefaultAsync(i => i.Id == lessonId);
            }
            catch (Exception)
            {
                //TODO: Logging
            }
            return result;
        }

        public async Task<User?> GetUser(string userEmail)
        {
            User? result = null;
            try
            {
                result = await _dbContext.Users
                           .FirstOrDefaultAsync(i => i.Email.Equals(userEmail));
            }
            catch (Exception)
            {
                //TODO: Logging
            }
            return result;
        }

        public async Task<bool> UpdateInvitation(Invitation invitation)
        {
            bool result = false;
            try
            {
                var foundItem = await _dbContext.Invitations
                                             .FindAsync(invitation.Id);
                if (foundItem != null)
                {
                    _dbContext.Entry(foundItem).CurrentValues.SetValues(invitation);
                    await _dbContext.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception)
            {
                //TODO: Logging
            }
            return result;
        }

        public async Task<bool> UpdateInvitationNotificationStatus(
            InvitationNotificationStatus invitationNotificationStatus
        )
        {
            bool result = false;
            try
            {
                var foundItem = await _dbContext.InvitationNotificationStatuses
                                             .FindAsync(invitationNotificationStatus.Id);
                if (foundItem != null)
                {
                    _dbContext.Entry(foundItem).CurrentValues.SetValues(invitationNotificationStatus);
                    await _dbContext.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception)
            {
                //TODO: Logging
            }
            return result;
        }
    }
}
