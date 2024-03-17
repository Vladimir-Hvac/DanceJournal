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

        public async Task<bool> AddInvitationStatuses(List<(InvitationStatus, int notificationId)> invitationStatuses)
        {
            bool result = false;
            try
            {
                List<NotificationInvitation> notifInv = new();

                foreach (var invStat in invitationStatuses)
                {
                    NotificationInvitation notificationInvitation = new()
                    {
                        InvitationId = invStat.Item1.InvitationId,
                        NotificationId = invStat.notificationId
                    };
                    notifInv.Add(notificationInvitation);
                }

                await _dbContext.AddRangeAsync(invitationStatuses.Select(x => x.Item1));
                await _dbContext.AddRangeAsync(notifInv);

                await _dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception)
            {
                //TODO: Logging
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

        public async Task<InvitationStatus?> GetInvitationStatus(int invitationId, int receiverId)
        {
            InvitationStatus? result = null;
            try
            {
                result = await _dbContext.InvitationStatuses
                            .Where(i => i.InvitationId.Equals(invitationId) && i.ReceiverId.Equals(receiverId))
                            .Include(x => x.Invitation)
                            .Include(x => x.Receiver)
                            .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                //TODO: Logging
            }
            return result;
        }

        public async Task<List<InvitationStatus>> GetInvitationStatusesByInvitaionId(int invitationId)
        {
            List<InvitationStatus> result = new();
            try
            {
                result = await _dbContext.InvitationStatuses
                           .Where(i => i.InvitationId.Equals(invitationId))
                           .Include(x => x.Invitation)
                           .Include(x => x.Receiver)
                           .ToListAsync();
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

        public async Task<bool> UpdateInvitationStatus(
            InvitationStatus invitationStatus
        )
        {
            bool result = false;
            try
            {
                var foundItem = await _dbContext.InvitationStatuses
                                             .FirstOrDefaultAsync(i => i.InvitationId.Equals(invitationStatus.InvitationId)
                                                                    && i.ReceiverId.Equals(invitationStatus.ReceiverId));
                if (foundItem != null)
                {
                    _dbContext.Entry(foundItem).CurrentValues.SetValues(invitationStatus);
                    await _dbContext.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //TODO: Logging
            }
            return result;
        }

        public async Task<bool> UpdateNotificationStatus(NotificationStatus notificationStatus)
        {
            bool result = false;
            try
            {
                var foundItem = await _dbContext.NotificationStatuses
                                             .FirstOrDefaultAsync(i => i.NotificationId.Equals(notificationStatus.NotificationId)
                                                                    && i.ReceiverId.Equals(notificationStatus.ReceiverId));
                if (foundItem != null)
                {
                    _dbContext.Entry(foundItem).CurrentValues.SetValues(notificationStatus);
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
        public async Task<(NotificationStatus, InvitationStatus?)?> GetNotificationStatus(int notificationId, int receiverId)
        {
            (NotificationStatus, InvitationStatus?)? res = null;
            try
            {
                NotificationStatus? foundNotificationStatus = await _dbContext.NotificationStatuses
                                .Where(i => i.NotificationId.Equals(notificationId)
                                && i.ReceiverId.Equals(receiverId))
                                .Include(x => x.Notification)
                                .Include(x => x.Receiver)
                                .FirstOrDefaultAsync();
                if (foundNotificationStatus != null)
                {
                    NotificationInvitation? notifInv = await _dbContext.NotificationInvitations.FirstOrDefaultAsync(i => i.NotificationId.Equals(notificationId));
                    if (notifInv != null)
                    {
                        InvitationStatus? invitationStatus = await _dbContext.InvitationStatuses
                                                                            .Where(i => i.InvitationId.Equals(notifInv.InvitationId)
                                                                            && i.ReceiverId.Equals(receiverId))
                                                                            .Include(x => x.Invitation)
                                                                            .Include(x => x.Receiver)
                                                                            .FirstOrDefaultAsync();
                        res = (foundNotificationStatus, invitationStatus);
                    }
                }
            }
            catch
            {
                //TODO: Logging
            }

            return res;
        }
        public async Task<List<(NotificationStatus, InvitationStatus?)>> GetNotReadNotificationStatusesByReceiver(int receiverId)
        {
            List<(NotificationStatus, InvitationStatus?)> result = await GetNotificationStatusesByReceiver(receiverId, false);
            return result;
        }
        public async Task<List<(NotificationStatus, InvitationStatus?)>> GetReadNotificationStatusesByReceiver(int receiverId)
        {
            List<(NotificationStatus, InvitationStatus?)> result = await GetNotificationStatusesByReceiver(receiverId, true);
            return result;
        }
        private async Task<List<(NotificationStatus, InvitationStatus?)>> GetNotificationStatusesByReceiver(int receiverId, bool isRead)
        {
            List<(NotificationStatus, InvitationStatus?)> result = new();
            try
            {
                List<NotificationStatus> notificationStatuses = await _dbContext.NotificationStatuses
                                                                                .Where(n => n.ReceiverId.Equals(receiverId) && n.IsRead == isRead)
                                                                                .Include(x => x.Notification)
                                                                                .Include(x => x.Receiver)
                                                                                .ToListAsync();
                List<InvitationStatus> invitationStatuses = await _dbContext.InvitationStatuses
                                                                            .Where(i => i.InvitationId.Equals(receiverId))
                                                                            .Include(x => x.Invitation)
                                                                            .Include(x => x.Receiver)
                                                                            .ToListAsync();
                List<NotificationInvitation> notificationInvitations = await _dbContext.NotificationInvitations.ToListAsync();

                foreach (var notificationStatus in notificationStatuses)
                {
                    int? invId = notificationInvitations.FirstOrDefault(i => i.NotificationId.Equals(notificationStatus.NotificationId))?.InvitationId;
                    if (invId != null)
                    {
                        InvitationStatus? invitationStatus = invitationStatuses.FirstOrDefault(i => i.InvitationId.Equals(invId));
                        result.Add((notificationStatus, invitationStatus));
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

    }
}
