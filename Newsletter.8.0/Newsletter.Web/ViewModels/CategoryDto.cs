namespace GeniusChuck.Newsletter.Web.ViewModels
{
    // DTO : Data Transfer Object
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public DateTime CreatedAt { get; set; }
    }
}
