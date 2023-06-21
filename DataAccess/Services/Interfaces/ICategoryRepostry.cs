using DataAccess.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Services.Interfaces
{
    public interface ICategoryRepostry
    {
        Task<int> AddNewCateogry(AddCategoryViewModel model);
        Task<List<AddCategoryViewModel>> GetAllCateogry();
    }
}