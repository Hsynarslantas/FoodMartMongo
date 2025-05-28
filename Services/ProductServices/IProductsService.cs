using FoodMartMongo.Dtos.ProductDtos;

namespace FoodMartMongo.Services.ProductServices
{
    public interface IProductsService
    {
        Task<List<ResultProductDto>> GetAllProductDtos();
        Task CreateProductAsync(CreateProductDto createproductDto);
        Task UpdateProductAsync(UpdateProductDto updateproductDto);
        Task DeleteProductAsync(string id);
        Task<GetProductIdDto> GetProductIdAsync(string id);
        Task<List<ResultProductDto>> GetLowestPriceProductsAsync(int count);

    }
}
