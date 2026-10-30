using System.ComponentModel.DataAnnotations;

namespace StudyFlow.Api.Dtos
{
    public class CriarSessaoEstudoDto
    {
        [Required]
        public DateTime DataInicio { get; set; }
        public int DuracaoMinutos { get; set; }
        public int MateriaId { get; set; }
    }
}
