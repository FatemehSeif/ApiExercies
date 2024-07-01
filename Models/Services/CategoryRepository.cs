using Microsoft.EntityFrameworkCore.Storage;
using MyPracticeWebApi.Models.Contexts;
using MyPracticeWebApi.Models.Entities;

namespace MyPracticeWebApi.Models.Services
{
	public class CategoryRepository
	{

		private readonly DataBaseContext _context ;
        public CategoryRepository(DataBaseContext context)
        {
            _context = context  ;   
        }

        public List<CategoryItemDto> GetAll()
        {
          return _context.Categories.Select(p => new CategoryItemDto
            {
                ToDos= p.ToDos,
                Name = p.Name,  
                Id= p.Id,   

            }).ToList();
        }

        public CategoryItemDto GetById(int id)
        {
            var categoryItem = _context.Categories.FirstOrDefault(p => p.Id == id);
            return (new CategoryItemDto
            {
                Id = categoryItem.Id,
                ToDos = categoryItem.ToDos,
                Name = categoryItem.Name,



            });

        
        }
        public void Add(CategoryItemDto categoryItem)
        {
            Category category = new Category()
            {
                Id = categoryItem.Id,
                ToDos = categoryItem.ToDos,
                Name = categoryItem.Name,

            };
            _context.Categories.Add(category);
            _context.SaveChanges();
          
        }






    }

    public class AddCategoryDTO
    {
        public List<int> ToDos { get; set; } 
        public Category Category { get; set; }  
    }





    public class CategoryItemDto
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<ToDo> ToDos { get; set; }

	}


}
