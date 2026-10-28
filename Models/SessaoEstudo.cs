namespace StudyFlow.Api.Models
{
    public class SessaoEstudo
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public int DuracaoMinutos { get; set; }
        public int MateriaId { get; set; }
        public Materia? Materia { get; set; }   
    }
}
