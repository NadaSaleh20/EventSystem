using EventSystem.Data;
using EventSystem.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSystem.services
{
    public class CategoryRepostry : ICategoryRepostry
    {
        public ApplicationDbContext _context { get; }
        public CategoryRepostry(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewCateogry (AddCategoryViewModel model)
        {
            var Cateogry = await _context.Categories.FirstOrDefaultAsync(x => x.Name == model.CatogryName);
            if (Cateogry is null)
            {
                var cateogry = new Category { Name = model.CatogryName };
                await _context.Categories.AddAsync(cateogry);
                await _context.SaveChangesAsync();
                return cateogry.Id;
            }
            return 0;
        }

        public async Task<List<AddCategoryViewModel>> GetAllCateogry()
        {
           return await _context.Categories.Select(x => new AddCategoryViewModel
            {
                CatogryName = x.Name,
                Id = x.Id
            }).ToListAsync();
        }
    }
}
