using EventSystem.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventSystem.services
{
    public interface ICategoryRepostry
    {
        Task<int> AddNewCateogry(AddCategoryViewModel model);
        Task<List<AddCategoryViewModel>> GetAllCateogry();
    }
}