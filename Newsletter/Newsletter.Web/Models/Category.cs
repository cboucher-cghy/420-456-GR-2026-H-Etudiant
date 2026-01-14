namespace GeniusChuck.Newsletter.Web.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public ICollection<Subscriber> Subscribers { get; set; } = default!;

        public DateTime CreatedAt { get; init; }
        // init permet l'initialisation de la variable lors de la création de l'instance uniquement.
    }
}
