using FoodMartMongo.Services.CategoryServices;
using FoodMartMongo.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _DefaultUnderDiscountComponentPartial : ViewComponent
    {
        private readonly IDiscountService _discountService;

        public _DefaultUnderDiscountComponentPartial(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allDiscounts = await _discountService.GetAllDiscountAsync();

            var subDiscounts = allDiscounts
                .OrderBy(x => x.DiscountId)
                .Reverse()
                .Take(2)
                .Reverse()
                .ToList();

            return View(subDiscounts);
        }

    }
}
