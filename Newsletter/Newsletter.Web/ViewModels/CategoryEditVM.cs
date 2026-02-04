using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeniusChuck.Newsletter.Web.ViewModels
{
    public class CategoryEditVM : IValidatableObject
    {
        [Required]
        [DisplayName("Identifiant")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nom de la catégorie")]
        public string Name { get; set; } = default!;

        [MinLength(3, ErrorMessage = "Description trop courte")]
        [MaxLength(50, ErrorMessage = "Description trop longue")]
        public string Description { get; set; } = default!;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ConvertEmptyStringToNull = true, NullDisplayText = "N/A")]
        public DateTime? CurrentDate { get; set; } = DateTime.Now;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return ValidationResult.Success!;

            //var db = (ApplicationDbContext)validationContext.GetRequiredService(typeof(ApplicationDbContext));

            //if (db.Categories.Any(c => c.Name == Name))
            //{
            //    yield return new ValidationResult("Le nom de la catégorie doit être unique.", [nameof(Name)]);
            //}
        }
    }
}
