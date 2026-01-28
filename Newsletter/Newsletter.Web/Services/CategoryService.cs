using GeniusChuck.Newsletter.Web.Data;
using GeniusChuck.Newsletter.Web.Models;
using GeniusChuck.Newsletter.Web.ViewModels;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GeniusChuck.Newsletter.Web.Services
{
    public class CategoryService(ApplicationDbContext context, IMapper mapper)
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public int Add(CategoryCreateVM vm)
        {
            // Avec mapper
            var category = _mapper.Map<Category>(vm);

            // Sans mapper
            //var category = new Category()
            //{
            //    Id = 0,
            //    Description = vm.Description,
            //    Name = vm.Name,
            //};

            _context.Add(category);
            return _context.SaveChanges();
        }

        public bool Exists(string name)
        {
            return _context.Categories.Any(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task<bool> AddAsync(CategoryCreateVM vm)
        {
            var category = new Category()
            {
                Id = 0,
                Description = vm.Description,
                Name = vm.Name,
            };

            _context.Add(category);
            // Ne pas utiliser les nombres pour savoir si un résultat est en succès ou non, préférer l'utilisation des booléans.
            // Dans le cas où une classe Repository serait utilisée, nous retournerions le nombre pour connaître le nombre de résultats total créée.
            return await _context.SaveChangesAsync() > 0;
        }

        public CategoryDto? GetById(int id)
        {
            var category = _context.Categories.ProjectToType<CategoryDto>().FirstOrDefault(x => x.Id == id);
            return category;
            //return new CategoryDto()
            //{
            //    CreatedAt = category.CreatedAt,
            //    Description = category.Description,
            //    Name = category.Name,
            //    Id = category.Id
            //};
            //
            // Sans ProjectTo
            //var category = _context.Categories.Select(category=> new CategoryDetailsVM()
            //{
            //    CreatedAt = category.CreatedAt,
            //    Description = category.Description,
            //    Name = category.Name,
            //    Id = category.Id
            //}).First(x=>x.Id == id);

            //if (category is not null)
            //{
            //    return new CategoryDetailsVM()
            //    {
            //        CreatedAt = category.CreatedAt,
            //        Description = category.Description,
            //        Name = category.Name,
            //        Id = category.Id
            //    };
            //}
            //return null;

            // Avec une méthode d'extension
            //var category = _context
            //   .Categories
            //   .Include(x => x.Subscribers)
            ////   .ProjectTo<CategoryDetailsVM>(_mapper.ConfigurationProvider)
            //   .FirstOrDefault(x => x.Id == id)
            //   ?.ToCategoryDetailsVM();

            //return category;
        }

        // Utilisation d'un "ValueTask" et non "Task" pour des raisons de performances
        // Voir le lien suivant: https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1
        // Voir aussi: https://devblogs.microsoft.com/dotnet/understanding-the-whys-whats-and-whens-of-valuetask/
        public async ValueTask<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public bool Update(CategoryEditVM vm)
        {
            try
            {
                _context.Update(new Category()
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Description = vm.Description,
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Categories.Any(e => e.Id == vm.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            // Ne pas utiliser les nombres pour savoir si un résultat est en succès ou non, préférer l'utilisation des booléans.
            return _context.SaveChanges() > 0;
        }

        public ICollection<CategoryDto> GetAll()
        {
            return _context.Categories.Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
            }).ToList();
            // Par méthode d'extension.
            //return _context.Categories.ToCategoryDetailsVM(3);

            // Par conversion manuelle.
            //    return _context.Categories.Select(x => new CategoryDetailsVM()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    CreatedAt = x.CreatedAt,

            //}).ToList();
        }

        public async Task<ICollection<CategoryDto>> GetAllAsync()
        {
            return await _context.Categories.Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
            }).ToListAsync();
        }

        public bool Remove(int id)
        {
            var category = _context.Categories.Find(id);
            if (category is null)
            {
                return false;
            }
            _context.Categories.Remove(category);
            return _context.SaveChanges() > 0;
        }

        internal List<SelectListItem> GetCategoriesListItems()
        {
            return
            [
                .. _context.Categories.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                }),
            ];
        }
    }
}
