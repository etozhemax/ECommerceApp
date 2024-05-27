using AutoMapper;
using ECommerce.Core.Pagination;
using ECommerce.Models;
using ECommerce.Models.ViewModels;

namespace ECommerce.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryViewModel, Category>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.DisplayOrder, options => options.MapFrom(src => src.DisplayOrder))
                .ReverseMap();

            CreateMap<PagedList<Category>, CategoryPageViewModel>()
                .ForPath(dest => dest.PageInfo.Page, options => options.MapFrom(src => src.TotalPages))
                .ForPath(dest => dest.PageInfo.Size, options => options.MapFrom(src => src.TotalSize))
                .ForMember(dest => dest.Categories, options => options.MapFrom(src => src.PagedItems))
                .ReverseMap();
        }
    }
}
