using AutoMapper;
using ECommerce.Core.Pagination;
using ECommerce.Models.ViewModels;

namespace ECommerce.Models.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyViewModel, Company>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.StreetAddress, options => options.MapFrom(src => src.StreetAddress))
                .ForMember(dest => dest.State, options => options.MapFrom(src => src.State))
                .ForMember(dest => dest.City, options => options.MapFrom(src => src.City))
                .ForMember(dest => dest.PostalCode, options => options.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.PhoneNumber, options => options.MapFrom(src => src.PhoneNumber))
                .ReverseMap();

            CreateMap<PagedList<Company>, CompanyPageViewModel>()
                .ForPath(dest => dest.PageInfo.Page, options => options.MapFrom(src => src.TotalPages))
                .ForPath(dest => dest.PageInfo.Size, options => options.MapFrom(src => src.TotalSize))
                .ForMember(dest => dest.Companies, options => options.MapFrom(src => src.PagedItems))
                .ReverseMap();
        }
    }
}
