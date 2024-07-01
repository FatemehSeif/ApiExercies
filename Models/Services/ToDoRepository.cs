using Microsoft.Identity.Client;
using MyPracticeWebApi.Models.Contexts;
using MyPracticeWebApi.Models.Entities;

namespace MyPracticeWebApi.Models.Services
{
	public class ToDoRepository
	{
		private readonly DataBaseContext _context;
		public ToDoRepository(DataBaseContext context)
		{

			_context = context;
		}


		public List<TODoDTO> GetAll()
		{

			return _context.ToDos.Select(p => new TODoDTO
			{
				Categories = p.Categories,
				Id = p.Id,
				InsertTime = p.InsertTime,
				IsRemoved = p.IsRemoved,
				Text = p.Text,

			}).ToList();




		}

		public TODoDTO GetById(int id)
		{
			var todo = _context.ToDos.SingleOrDefault(p => p.Id == id);
			return new TODoDTO
			{
				Id = todo.Id,
				InsertTime = todo.InsertTime,
				IsRemoved = todo.IsRemoved,
				Text = todo.Text,

			};


		}
		public AddToDoDTO AddToDoItem(AddToDoDTO todo)
		{
			ToDo newTodo = new ToDo()
			{
				Id = todo.Todo.Id,
				Text = todo.Todo.Text,
				InsertTime = DateTime.Now,
				IsRemoved = false,
			};

			foreach (var item in todo.Categories)
			{
				var category = _context.Categories.SingleOrDefault(p => p.Id == item);
				newTodo.Categories.Add(category);
			}

			_context.ToDos.Add(newTodo);
			_context.SaveChanges();	
			return new AddToDoDTO
			{
				Todo = new TODoDTO
				{
					Id = newTodo.Id,
					Text = newTodo.Text,
					InsertTime = newTodo.InsertTime,
					IsRemoved = newTodo.IsRemoved,
				},
				Categories = newTodo.Categories.Select(c => c.Id).ToList(),
			};
		}

		public void Delete (int Id)
		{
			//_context.ToDos.Remove(new ToDo { Id= Id });	
		  var todo=	_context.ToDos.Find(Id);
			todo.IsRemoved = true;

			_context.SaveChanges();	


		}
		public bool Edit (EditToDoDTO edit)
		{
			var todo = _context.ToDos.FirstOrDefault(p=> p.Id==edit.Id);
			todo.Text = edit.Text;
			_context.SaveChanges();
			return true;	

		}



	}

	public class TODoDTO
	{
		public int Id { get; set; }
		public string? Text { get; set; }
		public DateTime InsertTime { get; set; }
		public bool IsRemoved { get; set; }
		public ICollection<Category> Categories { get; set; }

	}


	public class AddToDoDTO
	{
		public TODoDTO Todo { get; set; }

		public List<int> Categories { get; set; } = new List<int> (); 


	}
	public class EditToDoDTO
	{
		public int Id {  set; get; }	
		public string? Text { get; set; } 
		public List<int> Categories { get; set; }

	}



}

