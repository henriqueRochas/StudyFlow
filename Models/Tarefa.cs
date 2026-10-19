namespace StudyFlow.Api.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int MateriaId { get; set; }

        public Materia? Materia { get; set; }
    }
}
