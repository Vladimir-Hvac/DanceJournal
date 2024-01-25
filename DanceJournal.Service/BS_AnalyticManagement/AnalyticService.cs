
using DanceJournal.Services.BS_AnalyticManagement.Abstractions;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DanceJournal.Services.BS_AnalyticManagement
{
    public class AnalyticService: IAnalytic 
    {
       

        public Task<bool> SaveLog(dynamic json,string typeEvent)
        {
            dynamic jsson = new JObject(json);
            return Task.FromResult(true);
        }


    }
}
