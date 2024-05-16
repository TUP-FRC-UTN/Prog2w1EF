namespace TodoItems.Dtos
{
    public class DtoItem
    {
        public Guid Id { get; set; }
        public string NombreTarea { get; set; }
        public bool EstaCompleta { get; set; }
        public string CategoriaNombre { get; set; }
    }
}
