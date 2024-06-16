using Microsoft.EntityFrameworkCore;
using MyPracticeWebApi.Models.Entities;

namespace MyPracticeWebApi.Models.Contexts

{
	public class DataBaseContext : DbContext
	{
        public DataBaseContext(DbContextOptions  options ) : base (options) 
        {
            
        }
        public DbSet<ToDo> ToDos { get; set; }  
        public DbSet <Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ToDo>().HasQueryFilter(p => !p.IsRemoved);
		}




	}



    
}
