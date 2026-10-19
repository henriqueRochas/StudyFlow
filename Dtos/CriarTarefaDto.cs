using StudyFlow.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace StudyFlow.Api.Dtos
{
    public class CriarTarefaDto
    {
        [Required]
        [NomeMateria]
        public string Titulo { get; set; } = string.Empty;
        public int MateriaId { get; set; }


    }
}
