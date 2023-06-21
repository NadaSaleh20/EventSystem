using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EventSystem.ViewModels
{
    public class AddCategoryViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public string CatogryName { get; set; }
    }
}
