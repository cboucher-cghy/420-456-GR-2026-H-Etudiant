using GeniusChuck.Newsletter.Web.Models;
using GeniusChuck.Newsletter.Web.ViewModels;
using Mapster;

namespace GeniusChuck.Newsletter.Web.MapperProfiles
{
    public class CategoryProfile
    {
        public CategoryProfile()
        {
            // Exemple de mapping spécial entre deux propriétés de noms différents.
            TypeAdapterConfig<CategoryCreateVM, Category>.NewConfig()
                .Map(src => src.Id, dest => int.Parse(dest.IdSuggere));

            // Exemple de SelectList
            //TypeAdapterConfig.NewConfig<SourceItem, SelectListItem>()
            //.Map(dest => dest.Value, src => src.Id)
            //.Map(dest => dest.Text, src => src.Name);
        }
    }
}
