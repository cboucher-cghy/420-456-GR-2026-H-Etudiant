using GeniusChuck.Newsletter.Web.Models;
using GeniusChuck.Newsletter.Web.ViewModels;
using Mapster;

namespace GeniusChuck.Newsletter.Web.MapperProfiles
{
    public class CategoryProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Impossible, car la conversion n'est pas équivalente d'un sens vers l'autre.
            //config.NewConfig<CategoryCreateVM, Category>()
            //    .TwoWays()
            //    .Map(dest => dest.Id, src => int.Parse(src.IdSuggere));

            // Mapping explicite de CategoryCreateVM -> Category avec conversion sécurisée de Id.
            config.NewConfig<CategoryCreateVM, Category>()
                .AfterMapping((src, dest) =>
                {
                    if (!string.IsNullOrWhiteSpace(src.IdSuggere) && int.TryParse(src.IdSuggere, out var id))
                    {
                        dest.Id = id;
                    }
                });

            // Mapping explicite inverse Category -> CategoryCreateVM pour peupler IdSuggere.
            config.NewConfig<Category, CategoryCreateVM>()
                .AfterMapping((src, dest) =>
                {
                    dest.IdSuggere = src.Id.ToString();
                });

            // Exemple de SelectList
            //TypeAdapterConfig.NewConfig<SourceItem, SelectListItem>()
            //.Map(dest => dest.Value, src => src.Id)
            //.Map(dest => dest.Text, src => src.Name);
        }
    }
}
