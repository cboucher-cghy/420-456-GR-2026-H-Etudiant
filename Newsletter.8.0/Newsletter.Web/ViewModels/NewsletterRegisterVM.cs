using GeniusChuck.Newsletter.Web.Validations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeniusChuck.Newsletter.Web.ViewModels
{
    public class NewsletterRegisterVM
    {
        [Required]
        [CourrielDuCegepSeulement]
        [DisplayName("Courriel")]
        public string Email { get; set; } = default!;

        /// <summary>
        /// Id de la catégorie pour laquelle s'inscrire.
        /// </summary>
        [Required]
        [DisplayName("Choix de la catégorie")]
        public int CategoryId { get; set; } = default!;

        /// <summary>
        /// La liste des catégories à afficher. 
        /// </summary>
        /// <remarks>Doit être <nullable> pour éviter des problèmes avec le ModelState.IsValid.</remarks>
        public List<SelectListItem>? Categories { get; set; } = default!;
    }
}
