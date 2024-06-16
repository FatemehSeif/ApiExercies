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
			return _context.ToDos.Select(P => new TODoDTO
			{
				Id = P.Id,
				Text = P.Text,
				InsertTime = P.InsertTime,
				IsRemoved = P.IsRemoved,


			}).ToList();
		}

		public TODoDTO Get(int Id)
		{
			var todo = _context.ToDos.SingleOrDefault(p => p.Id == Id);
			return new TODoDTO
			{
				Id = todo.Id,
				Text = todo.Text,
				InsertTime = todo.InsertTime,
				IsRemoved = todo.IsRemoved,


			};



		}

		//public AddToDoDTO (AddToDoDTO todo)
		//{
			
		//	ToDo newToDo = new ToDo()
		//	{
		//		Id = todo.Todo.Id,
		//		Text = todo.Todo.Text,
		//		InsertTime = DateTime.Now,
		//		IsRemoved = false,
		//	};
		//	foreach (var item in todo.Categories)
		//	{
		//		var category = _context.Categories.SingleOrDefault(p => p.Id == item);
		//		newToDo.Categories.Add(category);	
		//	}
		//	_context.ToDos.Add(newToDo);
		//	return new AddToDoDTO
		//	{

		//		Todo = new TODoDTO
		//		{
		//			Id = newToDo.Id,
		//			InsertTime = newToDo.InsertTime,
		//			IsRemoved = newToDo.IsRemoved,
		//			Text = newToDo.Text,

		//		},

		//		//Categories = newToDo.Categories ;
		//	};

		//}





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

		public List < int> Categories { get; set; }


	}
}

