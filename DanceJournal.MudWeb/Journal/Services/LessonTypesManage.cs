using DanceJournal.MudWeb.Journal.Pages;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Services
{
    public interface IDbTypeManage
    {
        List<LessonType> LessonTypes { get; set; }

        Task AddAsync(object entity, DialogResult result);
        Task CopyAsync(object entity);
        Task RemoveAsync(object entity);
        Task UpdateAsync(object entity, DialogResult result);
    }
    public class LessonTypesManage : IDbTypeManage
    {
        private ILessonPlanning _lessonPlanning;
        public List<LessonType> LessonTypes { get; set; }
        public List<Room> Rooms { get; private set; } = new List<Room>();
        public List<User> Users { get; private set; } = new List<User>();


        public LessonTypesManage(ILessonPlanning lessonPlanning)
        {
            _lessonPlanning = lessonPlanning;
        }
        public async Task CopyAsync(object entity)
        {
            LessonType resultEntity = (LessonType)entity;
            LessonTypes.Add(resultEntity);
            await _lessonPlanning.CreateLessonTypeAsync(resultEntity);
        }

        public async Task RemoveAsync(object entity)
        {
            LessonType resultEntity = (LessonType)entity;
            LessonTypes.Remove(resultEntity);
            await _lessonPlanning.DeleteLessonType(resultEntity.Id);
        }

        public async Task UpdateAsync(object entity, DialogResult result)
        {

            if (!result.Canceled)
            {
                LessonType resultEntity = (LessonType)result.Data;
                LessonType? oldData = LessonTypes.FirstOrDefault(x => x.Id.Equals(resultEntity.Id));
                if (oldData != null) { return; }
                resultEntity.Id = oldData.Id;
                LessonTypes.Remove(oldData);
                LessonTypes.Add(resultEntity);
                await _lessonPlanning.UpdateLessonTypeAsync(resultEntity);
            }
        }

        public async Task AddAsync(object entity, DialogResult result)
        {

            if (!result.Canceled)
            {
                LessonType resultEntity = (LessonType)result.Data;
                LessonTypes.Add(resultEntity);
                await _lessonPlanning.CreateLessonTypeAsync(resultEntity);
            }
        }

    }

}
