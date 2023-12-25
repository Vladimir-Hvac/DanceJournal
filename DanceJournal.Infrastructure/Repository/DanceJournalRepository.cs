using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DanceJournal.Infrastructure.Repository
{
    public class DanceJournalRepository : IDanceJournalRepository, IDisposable
    {
        private DanceJournalDbContext _dbContext;
        private bool _disposedValue;

        public DanceJournalRepository(DanceJournalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEntityAsync<T>(T entity)
            where T : class
        {
            switch (entity)
            {
                case Lesson e:
                    await _dbContext.Lessons.AddAsync(e);
                    break;
                case LessonType e:
                    await _dbContext.LessonTypes.AddAsync(e);
                    break;
                case LessonUser e:
                    await _dbContext.LessonUsers.AddAsync(e);
                    break;
                case Level e:
                    await _dbContext.Levels.AddAsync(e);
                    break;
                case Role e:
                    await _dbContext.Roles.AddAsync(e);
                    break;
                case Room e:
                    await _dbContext.Rooms.AddAsync(e);
                    break;
                case Subscription e:
                    await _dbContext.Subscriptions.AddAsync(e);
                    break;
                case SubscriptionType e:
                    await _dbContext.SubscriptionTypes.AddAsync(e);
                    break;
                case User e:
                    await _dbContext.Users.AddAsync(e);
                    break;
                default:
                    break;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEntityAsync<T>(T entity)
            where T : class
        {
            switch (entity)
            {
                case Lesson e:
                    _dbContext.Lessons.Update(e);
                    break;
                case LessonType e:
                    _dbContext.LessonTypes.Update(e);
                    break;
                case LessonUser e:
                    _dbContext.LessonUsers.Update(e);
                    break;
                case Level e:
                    _dbContext.Levels.Update(e);
                    break;
                case Role e:
                    _dbContext.Roles.Update(e);
                    break;
                case Room e:
                    _dbContext.Rooms.Update(e);
                    break;
                case Subscription e:
                    _dbContext.Subscriptions.Update(e);
                    break;
                case SubscriptionType e:
                    _dbContext.SubscriptionTypes.Update(e);
                    break;
                case User e:
                    _dbContext.Users.Update(e);
                    break;
                default:
                    break;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveEntityAsync<T>(T entity)
            where T : class
        {
            switch (entity)
            {
                case Lesson e:
                    _dbContext.Lessons.Remove(e);
                    break;
                case LessonType e:
                    _dbContext.LessonTypes.Remove(e);
                    break;
                case LessonUser e:
                    _dbContext.LessonUsers.Remove(e);
                    break;
                case Level e:
                    _dbContext.Levels.Remove(e);
                    break;
                case Role e:
                    _dbContext.Roles.Remove(e);
                    break;
                case Room e:
                    _dbContext.Rooms.Remove(e);
                    break;
                case Subscription e:
                    _dbContext.Subscriptions.Remove(e);
                    break;
                case SubscriptionType e:
                    _dbContext.SubscriptionTypes.Remove(e);
                    break;
                case User e:
                    _dbContext.Users.Remove(e);
                    break;
                default:
                    break;
            }
            await _dbContext.SaveChangesAsync();
        }

        public T? GetEntityOrDefault<T>(T entity)
            where T : class
        {
            switch (entity)
            {
                case Lesson e:
                    return _dbContext.Lessons.FirstOrDefault(c => c.Id.Equals(e.Id)) as T;

                case LessonType e:
                    return _dbContext.LessonTypes.FirstOrDefault(c => c.Id.Equals(e.Id)) as T;

                case LessonUser e:
                    return _dbContext.LessonUsers.FirstOrDefault(c => c.Id.Equals(e.Id)) as T;

                case Level e:
                    return _dbContext.Levels.FirstOrDefault(c => c.Id.Equals(e.Id)) as T;

                case Role e:
                    return _dbContext.Roles.FirstOrDefault(c => c.Id.Equals(e.Id)) as T;

                case Room e:
                    return _dbContext.Rooms.FirstOrDefault(c => c.Id.Equals(e.Id)) as T;

                case Subscription e:
                    return _dbContext.Subscriptions.FirstOrDefault(c => c.Id.Equals(e.Id)) as T;

                case SubscriptionType e:
                    return _dbContext.SubscriptionTypes.FirstOrDefault(c => c.Id.Equals(e.Id)) as T;

                case User e:
                    return _dbContext.Users.FirstOrDefault(c => c.Id.Equals(e.Id)) as T;

                default:
                    return null;
            }
        }

        public List<T>? GetAllEntitiesByType<T>()
            where T : class
        {
            string typeName = nameof(T);
            switch (typeName)
            {
                case nameof(Lesson):
                    return _dbContext.Lessons.ToList() as List<T>;

                case nameof(LessonType):
                    return _dbContext.LessonTypes.ToList() as List<T>;

                case nameof(LessonUser):
                    return _dbContext.LessonUsers.ToList() as List<T>;

                case nameof(Level):
                    return _dbContext.Levels.ToList() as List<T>;

                case nameof(Role):
                    return _dbContext.Roles.ToList() as List<T>;

                case nameof(Room):
                    return _dbContext.Rooms.ToList() as List<T>;

                case nameof(Subscription):
                    return _dbContext.Subscriptions.ToList() as List<T>;

                case nameof(SubscriptionType):
                    return _dbContext.SubscriptionTypes.ToList() as List<T>;

                case nameof(User):
                    return _dbContext.Users.ToList() as List<T>;

                default:
                    return null;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
