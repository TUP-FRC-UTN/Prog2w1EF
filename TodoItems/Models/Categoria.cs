namespace TodoItems.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<TodoItem> TodoItems { get; set; }
    }
}
