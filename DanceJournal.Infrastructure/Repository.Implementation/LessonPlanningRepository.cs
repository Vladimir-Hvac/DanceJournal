using DanceJournal.Services.BS_LessonsPlanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Infrastructure.Repository.Implementation
{
    public class LessonPlanningRepository : ILessonPlanningRepository
    {
        public Task AddEntityAsync(Lesson lesson)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllEntitiesByType<T>()
        {
            throw new NotImplementedException();
        }

        public T GetEntityOrDefault<T>(T lesson)
        {
            throw new NotImplementedException();
        }

        public Task RemoveEntityAsync(Lesson lesson)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntityAsync(Lesson lesson)
        {
            throw new NotImplementedException();
        }
    }
}
