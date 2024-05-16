using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoItems.Models
{
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string NombreTarea { get; set; }
        public bool EstaCompleta { get; set; }
        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
