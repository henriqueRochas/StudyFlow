using System.ComponentModel.DataAnnotations;
using StudyFlow.Api.Models;

namespace StudyFlow.Api.Dtos
{
    public class AtualizarTarefaDto
    {
        [Required]
        [NomeMateria]
        public string Titulo { get; set; } = string.Empty;
        public int MateriaId { get; set; }
    }
}
