using GeniusChuck.Newsletter.Web.Models;
using GeniusChuck.Newsletter.Web.ViewModels;
using Mapster;

namespace GeniusChuck.Newsletter.Web.MapperProfiles
{
    public class CategoryProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Exemple de mapping spécial entre deux propriétés de noms différents.
            config.NewConfig<CategoryCreateVM, Category>()
                .TwoWays()
                .Map(dest => dest.Id, src => int.Parse(src.IdSuggere));

            // Exemple de SelectList
            //TypeAdapterConfig.NewConfig<SourceItem, SelectListItem>()
            //.Map(dest => dest.Value, src => src.Id)
            //.Map(dest => dest.Text, src => src.Name);
        }
    }
}
