using System.Text.Json.Nodes;


namespace DanceJournal.Services.BS_AnalyticManagement.Abstractions
{
    public interface IAnalytic
    {
        Task<bool> SaveLog(dynamic json, string typeEvent);
    }
}
