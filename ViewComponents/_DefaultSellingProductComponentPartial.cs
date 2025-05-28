using FoodMartMongo.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _DefaultSellingProductComponentPartial : ViewComponent
    {
        private readonly IProductsService _productsService;

        public _DefaultSellingProductComponentPartial(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productsService.GetLowestPriceProductsAsync(6);
            return View(values);
        }
    }
}
