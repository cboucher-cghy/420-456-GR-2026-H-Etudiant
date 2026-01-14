using AutoMapper;
using GeniusChuck.Newsletter.Web.Models;
using GeniusChuck.Newsletter.Web.ViewModels;

namespace GeniusChuck.Newsletter.Web.Profiles
{
    public class CategoryProfile : Profile
    {

        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryDto, CategoryDetailsVM>().ReverseMap();
            CreateMap<CategoryDto, CategoryEditVM>().ReverseMap();



        }
    }
}
