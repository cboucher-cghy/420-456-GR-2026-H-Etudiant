using GeniusChuck.Newsletter.Web.Models;
using GeniusChuck.Newsletter.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GeniusChuck.Newsletter.Web.Extensions
{
    public static class MyExtensions
    {
        public static CategoryDetailsVM ToCategoryDetailsVM(this Category category)
        {
            return new CategoryDetailsVM()
            {
                CreatedAt = category.CreatedAt,
                Description = category.Description,
                Name = category.Name,
                Id = category.Id
            };
        }

        public static ICollection<CategoryDetailsVM> ToCategoryDetailsVM(this DbSet<Category> categories)
        {
            return categories.Select(x => x.ToCategoryDetailsVM()).ToList();
            //return categories.Select(ToCategoryDetailsVM).ToList(); // Aussi valide

        }

        public static ICollection<CategoryDetailsVM> ToCategoryDetailsVM(this DbSet<Category> categories, int count)
        {
            return categories.Select(ToCategoryDetailsVM).Take(count).ToList();
            //return categories.Select(ToCategoryDetailsVM).Take(count).ToList(); // Aussi valide

        }
    }
}
