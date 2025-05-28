using FoodMartMongo.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _DefaultAllProductComponentPartial:ViewComponent
    {
        private readonly IProductsService _productsService;

        public _DefaultAllProductComponentPartial(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productsService.GetAllProductDtos();
            return View(values);
        }
    }
}
