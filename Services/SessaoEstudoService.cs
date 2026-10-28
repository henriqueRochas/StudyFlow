using Microsoft.EntityFrameworkCore;
using StudyFlow.Api.Data;
using StudyFlow.Api.Dtos;
using StudyFlow.Api.Models;

namespace StudyFlow.Api.Services
{
    public class SessaoEstudoService
    {
        private readonly StudyFlowContext _context;

        public SessaoEstudoService(StudyFlowContext context)
        {
            _context = context;
        }

        public List<SessaoEstudo> PegarTodas()
        {
            return _context.SessaoEstudos.Include(x => x.Materia).ToList();
        }


        public SessaoEstudo? Adicionar (CriarSessaoEstudoDto dto)
        {
            DateTime dataInicio = dto.DataInicio;
            var duracaoMinutos = dto.DuracaoMinutos;
            var materia = _context.Materias.Find(dto.MateriaId);

            if(materia is null)
            {
                return null;
            }

            var sessaoEstudos = new SessaoEstudo
            {
                DataInicio = dataInicio,
                DuracaoMinutos = duracaoMinutos,
                MateriaId = dto.MateriaId,
            };

            _context.SessaoEstudos.Add(sessaoEstudos);
            _context.SaveChanges();

            return sessaoEstudos; 
        }
    }
}
