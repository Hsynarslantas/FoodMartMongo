
using FoodMartMongo.Services.CategoryServices;
using FoodMartMongo.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _DefaultCategoryComponentPartial:ViewComponent
    {
        
        private readonly ICategoryService _categoryService;
        public _DefaultCategoryComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
         public async Task<IViewComponentResult> InvokeAsync()
         {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
         }

    }
}
