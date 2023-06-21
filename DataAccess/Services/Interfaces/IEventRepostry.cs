
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Services.Interfaces
{
    public interface IEventRepostry
    {
        Task<List<AddCategoryViewModel>> GetAllCateogry();
        Task AddEventDB(EventViewModel model);
        Task<EventViewModel> GetEvent(int id);
        Task<List<EventViewModel>> GetAllEvents(string name = null, int CateogryId = 0);
        Task UpdateRecord(EventViewModel model);
        Task deleteEvent(int Id);
    }
}