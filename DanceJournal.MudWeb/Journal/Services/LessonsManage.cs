using DanceJournal.MudWeb.Journal.Pages;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Services
{
    //public class LessonsManage
    //{
    //    private IManageService _manageService;

    //    public LessonsManage(IManageService manageService)
    //    {
    //        _manageService = manageService;
    //    }
    //    public async Task CopyAsync(object entity)
    //    {
    //        Lesson resultEntity = (Lesson)entity;
    //        _manageService. Lessons.Add(resultEntity);
    //        await _lessonPlanning.CreateLessonAsync(resultEntity);
    //    }

    //    public async Task RemoveAsync(object entity)
    //    {
    //        Lesson resultEntity = (Lesson)entity;
    //        Lessons.Remove(resultEntity);
    //        await _lessonPlanning.DeleteLesson(resultEntity.Id);
    //    }

    //    public async Task UpdateAsync(object entity)
    //    {
    //        var result = await OpenDialog(typeof(LessonsDialog), "Редактировать", entity);

    //        if (!result.Canceled)
    //        {
    //            Lesson resultEntity = (Lesson)result.Data;
    //            Lesson? oldData = Lessons.FirstOrDefault(x => x.Id.Equals(resultEntity.Id));
    //            if (oldData != null) { return; }
    //            resultEntity.Id = oldData.Id;
    //            Lessons.Remove(oldData);
    //            Lessons.Add(resultEntity);
    //            await _lessonPlanning.UpdateLessonAsync(resultEntity);
    //        }
    //    }

    //    public async Task AddAsync(object entity)
    //    {
    //        var result = await OpenDialog(typeof(LessonsDialog), "Добавить", entity);

    //        if (!result.Canceled)
    //        {
    //            Lesson resultEntity = (Lesson)result.Data;
    //            Lessons.Add(resultEntity);
    //            await _lessonPlanning.CreateLessonAsync(resultEntity);
    //        }
    //    }
    //    public async Task<DialogResult> OpenDialog(Type dialogType, string title, object entity)
    //    {
    //        var parameters = new DialogParameters()
    //        {
    //            {entity.GetType().Name,entity}
    //        };
    //        var options = new DialogOptions { CloseOnEscapeKey = true };
    //        var dialog = _dialogService.Show(dialogType, title, parameters, options);
    //        return await dialog.Result;
    //    }

    //}

}
