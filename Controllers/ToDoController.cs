using Microsoft.AspNetCore.Mvc;
using MyPracticeWebApi.DTOs;
using MyPracticeWebApi.Models.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPracticeWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ToDoController : ControllerBase
	{
		private readonly ToDoRepository todoRepository;
        public ToDoController(ToDoRepository toDoRepository)
        {
			this.todoRepository = toDoRepository; 
        }

        // GET: api/<ToDoController>
        [HttpGet]
		public IActionResult Get()
		{
		  var ToDoList = todoRepository.GetAll().Select(p=> new DTOItems
		  {
			  InsertTime= p.InsertTime,
			  Text = p.Text	,

		  });
			return Ok(ToDoList); 
		}

		// GET api/<ToDoController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var todo= todoRepository.GetById(id);	
			return Ok(new  DTOItems
			{ 
			  InsertTime = todo.InsertTime,
			  Text = todo.Text,
			
			});
		}

		// POST api/<ToDoController>
		[HttpPost]
		public IActionResult Post([FromBody] PostDTO item)
		{
			var Result = todoRepository.AddToDoItem(new AddToDoDTO() 
			{
				Todo = new TODoDTO
				{
					Text = item.Text ,
					

				}			
			});
			string url= Url.Action(nameof(Get),"ToDo",new {Id=Result.Todo.Id},Request.Scheme);
			return Created(url, true);

		}

		// PUT api/<ToDoController>/5
		[HttpPut]
		public IActionResult Put([FromBody] EditToDoDTO edit)
		{
			var result = todoRepository.Edit(edit); 
		     return Ok(result);	
		}

		// DELETE api/<ToDoController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
		      todoRepository.Delete(id);	
			//var result = todoRepository.Delete(id);
			return Ok();	
		}
	}
}
