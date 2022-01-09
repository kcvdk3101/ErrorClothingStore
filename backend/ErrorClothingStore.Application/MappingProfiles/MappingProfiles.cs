using AutoMapper;
using ErrorClothingStore.Application.Features.Categories.ViewModels;
using ErrorClothingStore.Application.Features.Products.ViewModels;
using ErrorClothingStore.Domain.Entities;

namespace ErrorClothingStore.Application.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductListVm>();
            CreateMap<Product, ProductDetailsVm>();

            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryDetailsVm>();
        }
    }
}