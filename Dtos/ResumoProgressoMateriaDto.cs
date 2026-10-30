namespace StudyFlow.Api.Dtos
{
    public class ResumoProgressoMateriaDto
    {
        public int MateriaId { get; set; }

        public string NomeMateria { get; set; } = string.Empty;

        public int TotalSessoes {  get; set; }

        public int TotalMinutos { get; set; }

    }
}
