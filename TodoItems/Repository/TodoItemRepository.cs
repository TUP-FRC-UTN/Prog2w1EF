using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using TodoItems.ModelsDatabase;

namespace TodoItems.Repository
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoItemsContext _context;
        public TodoItemRepository()
        {
            _context = new TodoItemsContext();
        }
        public int Add(Item item)
        {
            _context.Add(item);
            return _context.SaveChanges();
        }

        public bool delete(Guid id)
        {
            var entity = _context.Items.FirstOrDefault(x => x.Id == id);
            _context.Remove(entity);
            var response = _context.SaveChanges();
            if (response != 0)
            {
                return true;
            }
            return false;

        }

        public List<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public Item Put(Item item)
        {
            var entity = _context.Items.FirstOrDefault(x => x.Id == item.Id);
            entity.NombreTarea = item.NombreTarea;
            entity.EstaCompleta = item.EstaCompleta;
            entity.CategoriaId = item.CategoriaId;
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
