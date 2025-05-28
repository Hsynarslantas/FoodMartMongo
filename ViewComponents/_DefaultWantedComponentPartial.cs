using System.Threading.Tasks;
using FoodMartMongo.Dtos.ProductDtos;
using FoodMartMongo.Services.CategoryServices;
using FoodMartMongo.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _DefaultWantedComponentPartial:ViewComponent
    {
        private readonly IProductsService _productsService;
        public _DefaultWantedComponentPartial(IProductsService productsService)
        {
            _productsService = productsService;
           
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productsService.GetAllProductDtos() ?? new List<ResultProductDto>();
            return View(values);
        }
    }
}
