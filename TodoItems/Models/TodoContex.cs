using Microsoft.EntityFrameworkCore;

namespace TodoItems.Models
{
    public class TodoContex : DbContext
    {
        public TodoContex()
        {

        }
        public DbSet<TodoItem> Items { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
    ("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TodoItems;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>().HasData(
                       new Categoria { Id = 1, Nombre = "Personal" },
                       new Categoria { Id = 2, Nombre = "Trabajo" },
                       new Categoria { Id = 3, Nombre = "Estudio" });
        }
    }
}
