namespace TodoItems.Dtos
{
    public class DtoItemPut
    {
        public Guid Id { get; set; }
        public string NombreTarea { get; set; }
        public bool EstaCompleta { get; set; }
        public int CategoriaId { get; set; }
    }
}
