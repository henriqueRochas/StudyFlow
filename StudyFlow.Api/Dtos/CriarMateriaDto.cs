using StudyFlow.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace StudyFlow.Api.Dtos;

public class CriarMateriaDto
{
    [Required] // OBRIGA A INSERIR ALGO, NÃO DEIXA SER VAZIO
    //[MinLength(3)] // SOMENTE VERIFICA O COMPRIMENTO
    [NomeMateria] // REGRA QUE NÃO DEIXA O VALOR SER VAZIO OU CONTER MENOS DE 3 CARACTERES
    public string Nome { get; set; } = string.Empty;
}