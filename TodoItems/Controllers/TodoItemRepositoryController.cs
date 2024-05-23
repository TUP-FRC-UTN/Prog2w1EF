using Microsoft.AspNetCore.Mvc;
using TodoItems.Dtos;
using TodoItems.ModelsDatabase;
using TodoItems.Repository;

namespace TodoItems.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemRepositoryController : Controller
    {
        private readonly ITodoItemRepository _todoItemRepository;
        public TodoItemRepositoryController()
        {
            _todoItemRepository = new TodoItemRepository();
        }
        [HttpGet]
        public ActionResult Get()
        {
            List<Item> entities = _todoItemRepository.GetAll();
            if (entities == null) return NotFound();
            List<DtoItem> lstItemsDto = new List<DtoItem>();
            foreach (var item in entities)
            {
                DtoItem dtoItem = new DtoItem
                {
                    Id = item.Id,
                    NombreTarea = item.NombreTarea,
                    EstaCompleta = item.EstaCompleta,
                };
                lstItemsDto.Add(dtoItem);
            }
            return Ok(lstItemsDto);
        }
    }
}
