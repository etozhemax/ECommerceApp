using AutoMapper;
using ECommerce.Core.Pagination;
using ECommerce.Models.ViewModels;

namespace ECommerce.Models.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductViewModel, Product>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, options => options.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, options => options.MapFrom(src => src.Description))
                .ForMember(dest => dest.ISBN, options => options.MapFrom(src => src.ISBN))
                .ForMember(dest => dest.Price, options => options.MapFrom(src => src.Price))
                .ForMember(dest => dest.Author, options => options.MapFrom(src => src.Author))
                .ForMember(dest => dest.ImageUrl, options => options.MapFrom(src => src.ImageUrl));

            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, options => options.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, options => options.MapFrom(src => src.Description))
                .ForMember(dest => dest.ISBN, options => options.MapFrom(src => src.ISBN))
                .ForMember(dest => dest.Price, options => options.MapFrom(src => src.Price))
                .ForMember(dest => dest.Author, options => options.MapFrom(src => src.Author))
                .ForMember(dest => dest.ImageUrl, options => options.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.CategoryName, options => options.MapFrom(src => src.Category.Name));

            CreateMap<PagedList<Product>, ProductPageViewModel>()
                .ForPath(dest => dest.PageInfo.Page, options => options.MapFrom(src => src.TotalPages))
                .ForPath(dest => dest.PageInfo.Size, options => options.MapFrom(src => src.TotalSize))
                .ForMember(dest => dest.Products, options => options.MapFrom(src => src.PagedItems))
                .ReverseMap();
        }
    }
}
