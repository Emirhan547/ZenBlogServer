using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Application.Features.Categories.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Mappings
{
    public class CategoryMappingProfile:Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, GetCategoryQueryResult>();
            CreateMap<Category,CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, GetCategoryByIdQueryResult>();
            CreateMap<Category,UpdateCategoryCommand>().ReverseMap();
        }
    }
}
