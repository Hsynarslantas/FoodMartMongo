using AutoMapper;
using FoodMartMongo.Dtos.CategoryDtos;
using FoodMartMongo.Dtos.CustomerDtos;
using FoodMartMongo.Dtos.ProductDtos;
using FoodMartMongo.Entities;
using FoodMartMongo.Settings;
using MongoDB.Driver;

namespace FoodMartMongo.Services.ProductServices
{
    public class ProductService : IProductsService
    {
        private readonly IMongoCollection<Product> _Productcollection;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;
        public ProductService(IMapper mapper, IDatabaseSetting _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _Productcollection = database.GetCollection<Product>(_databaseSetting.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSetting.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductAsync(CreateProductDto createproductDto)
        {
            var value = _mapper.Map<Product>(createproductDto);
            await _Productcollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _Productcollection.DeleteOneAsync(x => x.ProductId == id);

        }

        public async Task<List<ResultProductDto>> GetAllProductDtos()
        {
         
            var products = await _Productcollection.Find(x => true).ToListAsync();
            var categories = await _categoryCollection.Find(x => true).ToListAsync();

            var productDtos = products.Select(p =>
            {
                var category = categories.FirstOrDefault(c => c.CategoryId == p.CategoryId);
                var dto = _mapper.Map<ResultProductDto>(p);
                dto.CategoryName = category?.CategoryName;
                return dto;
            }).ToList();

            return productDtos;
        }

        

        public async Task<GetProductIdDto> GetProductIdAsync(string id)
        {
            var product = await _Productcollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            if (product == null) return null;

            var category = await _categoryCollection.Find(x => x.CategoryId == product.CategoryId).FirstOrDefaultAsync();

            var dto = _mapper.Map<GetProductIdDto>(product);
            dto.CategoryName = category?.CategoryName;

            return dto;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateproductDto)
        {
            var value = _mapper.Map<Product>(updateproductDto);
            await _Productcollection.FindOneAndReplaceAsync(x => x.ProductId == updateproductDto.ProductId, value);
        }
        // ProductsService.cs
        public async Task<List<ResultProductDto>> GetLowestPriceProductsAsync(int count)
        {
            var products = await _Productcollection
                .Find(_ => true)
                .SortBy(p => p.ProductPrice) 
                .Limit(count)
                .ToListAsync();

            return products.Select(p => new ResultProductDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductPrice = p.ProductPrice,
                ImageUrl = p.ImageUrl,          
                StockCount = p.StockCount    
            }).ToList();
        }

    }
}
