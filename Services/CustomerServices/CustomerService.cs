using AutoMapper;
using FoodMartMongo.Dtos.CategoryDtos;
using FoodMartMongo.Dtos.CustomerDtos;
using FoodMartMongo.Entities;
using FoodMartMongo.Settings;
using MongoDB.Driver;

namespace FoodMartMongo.Services.CustomerServices
{
    public class CustomerService:  ICustomerService
    {
        private readonly IMongoCollection<Customer> _Customercollection;
        private readonly IMapper _mapper;
        public CustomerService(IMapper mapper, IDatabaseSetting _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _Customercollection = database.GetCollection<Customer>(_databaseSetting.CustomerCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            var value =_mapper.Map<Customer>(createCustomerDto);
            await _Customercollection.InsertOneAsync(value);
           
        }

        public async Task DeleteCustomerAsync(string id)
        {
            await _Customercollection.DeleteOneAsync(x=>x.CustomerId==id);
        }

        public async Task<List<ResultCustomerDto>> GetAllCustomerDtos()
        {
           var value= await _Customercollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCustomerDto>>(value);
        }

        public async Task<GetByIdCustomerDto> GetByIdCustomerAsync(string id)
        {
            var values = await _Customercollection.Find(x => x.CustomerId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCustomerDto>(values);
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            var values = _mapper.Map<Customer>(updateCustomerDto);
            await _Customercollection.FindOneAndReplaceAsync(x => x.CustomerId == updateCustomerDto.CustomerId, values);
        }
    }
}
