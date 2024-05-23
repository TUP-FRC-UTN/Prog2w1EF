using TodoItems.ModelsDatabase;

namespace TodoItems.Repository
{
    public interface ITodoItemRepository
    {
        List<Item> GetAll();
        int Add(Item item);
        Item Put(Item item);
        bool delete(Guid id);
    }
}
