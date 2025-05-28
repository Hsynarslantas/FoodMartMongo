using AutoMapper;
using FoodMartMongo.Dtos.CategoryDtos;
using FoodMartMongo.Dtos.CustomerDtos;
using FoodMartMongo.Dtos.DiscountDtos;
using FoodMartMongo.Dtos.ProductDtos;
using FoodMartMongo.Entities;

namespace FoodMartMongo.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();

            CreateMap<GetCategoryByIdDto, UpdateCategoryDto>();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();

            CreateMap<Product, ResultCategoryDto>().ReverseMap();
            CreateMap<Product, UpdateCategoryDto>().ReverseMap();
            CreateMap<Product, CreateCategoryDto>().ReverseMap();
            CreateMap<Product, GetProductIdDto>().ReverseMap();

            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<UpdateProductDto, Product>();


            CreateMap<Customer, ResultCustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, GetByIdCustomerDto>().ReverseMap();

            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetDiscountByIdDto>().ReverseMap();
        }
    }
}
