

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
        }
    }
}
