using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoItems.Dtos;
using TodoItems.Models;

namespace TodoItems.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController : Controller
    {
        private TodoContex todoContex;
        public TodoItemController()
        {
            todoContex = new TodoContex();
        }
        [HttpGet]
        public ActionResult Get()
        {
            var listaItems = todoContex.Items.
                Include(x => x.Categoria)
                .ToList();
            List<DtoItem> listaDto = new List<DtoItem>();
            foreach (var item in listaItems)
            {
                listaDto.Add(new DtoItem
                {
                    Id = item.Id,
                    NombreTarea = item.NombreTarea,
                    EstaCompleta = item.EstaCompleta,
                    CategoriaNombre = item.Categoria.Nombre
                });

            }
            if (listaDto == null) return NotFound();
            return Ok(listaDto);
        }
        [HttpPost]
        public ActionResult Create([FromBody] DtoItemPost itemPost)
        {
            TodoItem item = new TodoItem
            {
                Id = Guid.NewGuid(),
                NombreTarea = itemPost.NombreTarea,
                EstaCompleta = itemPost.EstaCompleta,
                CategoriaId = itemPost.CategoriaId
            };
            var entity = todoContex.Items.Add(item).Entity;
            var response = todoContex.SaveChanges();
            if (response == 0)
            {
                return BadRequest("No se pudo guardar en la base.");
            }
            return Ok("Se guardo exitosamente.");
        }
        [HttpPut]
        public ActionResult Put([FromBody] DtoItemPut dtoItemPut)
        {
            var item = todoContex.Items.FirstOrDefault(x => x.Id == dtoItemPut.Id);

            item.NombreTarea = dtoItemPut.NombreTarea;
            item.EstaCompleta = dtoItemPut.EstaCompleta;
            item.CategoriaId = dtoItemPut.CategoriaId;

            todoContex.Items.Update(item);
            var response = todoContex.SaveChanges();
            if (response == 0)
            {
                return BadRequest("No se pudo guardar en la base.");
            }
            return Ok("Se edito exitosamente.");

        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            var item = todoContex.Items.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            todoContex.Items.Remove(item);
            var response = todoContex.SaveChanges();
            if (response == 0)
            {
                return BadRequest("No se pudo guardar en la base.");
            }
            return Ok("El registro se elimino con exito.");
        }

    }
}
