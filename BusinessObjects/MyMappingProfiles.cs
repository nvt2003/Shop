

using AutoMapper;
using BusinessObjects.DTOs;
using BusinessObjects.Models;

namespace BusinessObjects
{
    public class MyMappingProfiles:Profile
    {
        public MyMappingProfiles()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<RegisterRequest, User>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Inventory, InventoryDTO>();
            CreateMap<InventoryDTO, Inventory>();
            CreateMap<Inventory, InventoryViewModel>()
                .ForMember(dest => dest.ProductView, opt => opt.MapFrom(src => src.Product != null ? new ProductBasicViewModel
                {
                    Id = src.Product.Id,
                    Name = src.Product.Name,
                    Description = src.Product.Description,
                    Price = src.Product.Price,
                    CreatedAt = src.Product.CreatedAt,
                    ModifiedAt = src.Product.ModifiedAt,
                    DeletedAt = src.Product.DeletedAt
                } : null));
            CreateMap<ProductAttributeDTO, ProductAttribute>();
            CreateMap<ProductAttribute, ProductAttributeDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductBasicViewModel>();
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest=>dest.CategoryDTO,opt=>opt.MapFrom(src=>src.Category==null?null:
                new CategoryDTO
                {
                    Id=src.Category.Id,
                    Name=src.Category.Name,
                    Description=src.Category.Description,
                    CreateAt = src.Category.CreateAt,
                    DeleteAt = src.Category.DeleteAt
                }))
                .ForMember(dest=>dest.InventoryDTO,opt=>opt.MapFrom(src=>src.Inventory==null?null:
                new InventoryDTO
                {
                    Id = src.Inventory.Id,
                    Quantity = src.Inventory.Quantity,
                    CreatedAt=src.Inventory.CreatedAt,
                    DeletedAt=src.Inventory.DeletedAt
                }))
                .ForMember(dest => dest.ColorAttributeDTO, opt => opt.MapFrom(src => src.ColorAttribute == null ? null :
                new ProductAttributeDTO
                {
                    Id = src.ColorAttribute.Id,
                    Type = src.ColorAttribute.Type,
                    Value = src.ColorAttribute.Value,
                    CreatedAt = src.ColorAttribute.CreatedAt,
                    DeletedAt = src.ColorAttribute.DeletedAt
                }))
                .ForMember(dest => dest.SizeAttributeDTO, opt => opt.MapFrom(src => src.SizeAttribute == null ? null :
                new ProductAttributeDTO
                {
                    Id = src.SizeAttribute.Id,
                    Type = src.SizeAttribute.Type,
                    Value = src.SizeAttribute.Value,
                    CreatedAt = src.SizeAttribute.CreatedAt,
                    DeletedAt = src.SizeAttribute.DeletedAt
                }))
                .ForMember(dest => dest.TypeAttributeDTO, opt => opt.MapFrom(src => src.TypeAttribute == null ? null :
                new ProductAttributeDTO
                {
                    Id = src.TypeAttribute.Id,
                    Type = src.TypeAttribute.Type,
                    Value = src.TypeAttribute.Value,
                    CreatedAt = src.TypeAttribute.CreatedAt,
                    DeletedAt = src.TypeAttribute.DeletedAt
                }));
        }
    }
}
