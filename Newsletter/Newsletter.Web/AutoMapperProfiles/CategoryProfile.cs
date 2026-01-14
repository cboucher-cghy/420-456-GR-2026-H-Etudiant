using AutoMapper;
using GeniusChuck.Newsletter.Web.Models;
using GeniusChuck.Newsletter.Web.ViewModels;

namespace GeniusChuck.Newsletter.Web.AutoMapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // Exemple de mapping spécial entre deux propriétés de noms différents.
            CreateMap<Category, CategoryCreateVM>().ReverseMap()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => int.Parse(src.IdSuggere)));

            // Sans ReverseMap
            CreateMap<Category, CategoryDetailsVM>();
            CreateMap<CategoryDetailsVM, Category>();

            // Exemple avec ReverseMap
            CreateMap<Category, CategoryEditVM>().ReverseMap();

            // TODO: Ajouter un exemple de SelectList
        }
    }
}
