using DataAccess.Services.Interfaces;
using DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventSystem.Controllers
{
    public class CategoryController : Controller
    {
        public ICategoryRepostry _categoryRepostry { get; }

        public CategoryController(ICategoryRepostry categoryRepostry)
        {
            _categoryRepostry = categoryRepostry;
        }
        public async Task <IActionResult> Categories()
        {
  
            return View(await _categoryRepostry.GetAllCateogry());
        }
        [HttpPost]
        public async Task <IActionResult> AddCategory(AddCategoryViewModel addCategoryViewModel)
        {

            if (ModelState.IsValid)
            {
                var Id = await _categoryRepostry.AddNewCateogry(addCategoryViewModel);
                if (Id > 0)
                {
                    return RedirectToAction(nameof(Categories));
                }
                //Cateogry is Already exist
                else
                {
                    ModelState.AddModelError(string.Empty, "The Cateogry is already exist"); 
                
                }

            }
            var categories = await _categoryRepostry.GetAllCateogry();
             return View (nameof(categories) , categories);  
          
        }
    }
}
