using System.ComponentModel.DataAnnotations;

namespace StudyFlow.Api.Dtos
{
    public class NomeMateriaAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value) // O MÉTODO REMOVE ESPAÇOS EM BRANCO E SE O CAMPO TEM MAIS DE 3 CARACTERES
        {
            if(value is not string nome)
            {
                return false;
            }

            return !string.IsNullOrWhiteSpace(nome) && nome.Trim().Length >= 3;
        }
    }
}
