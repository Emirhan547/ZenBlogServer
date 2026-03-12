using AutoMapper;
using ZenBlog.Application.Features.Abouts.Commands;
using ZenBlog.Application.Features.Abouts.Result;
using ZenBlog.Domain.Entities;


namespace ZenBlog.Application.Features.Abouts.Mappings
{
    public class AboutMappingProfile:Profile
    {
        public AboutMappingProfile()
        {
            CreateMap<About,GetAboutsQueryResult>().ReverseMap();
            CreateMap<About,GetAboutByIdQueryResult>().ReverseMap();
            CreateMap<About,CreateAboutCommand>().ReverseMap();
            CreateMap<About,UpdateAboutCommand>().ReverseMap();
        }
    }
}
