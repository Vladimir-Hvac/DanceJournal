using DanceJournal.MudWeb.Journal.Pages;
using DanceJournal.Services.BS_StaffManagement.Abstractions;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Services;

public class MyOpenDialog
{
    private IDialogService _dialogService;

    public MyOpenDialog(IDialogService dialogService) 
    {

        _dialogService = dialogService;
    }

    public async Task<DialogResult> OpenDialog(Type dialogType,string title, object entity) 
    {
        var parameters = new DialogParameters()
            {
                {entity.GetType().Name,entity}
            };
        var options = new DialogOptions { CloseOnEscapeKey = true };
        var dialog = _dialogService.Show(dialogType, title, parameters, options);
        return await dialog.Result;
    }
}


