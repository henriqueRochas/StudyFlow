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

        public SessaoEstudo? PegarPorId(int id)
        {
            return _context.SessaoEstudos.Include(x => x.Materia).FirstOrDefault(x => x.Id == id);
        }

        public SessaoEstudo? Adicionar(CriarSessaoEstudoDto dto)
        {
            var materia = _context.Materias.Find(dto.MateriaId);

            if (materia is null)
            {
                return null;
            }

            var sessaoEstudos = new SessaoEstudo
            {
                DataInicio = dto.DataInicio,
                DuracaoMinutos = dto.DuracaoMinutos,
                MateriaId = dto.MateriaId,
            };

            _context.SessaoEstudos.Add(sessaoEstudos);
            _context.SaveChanges();

            return sessaoEstudos;
        }

        public SessaoEstudo? Atualizar(int id, CriarSessaoEstudoDto dto)
        {
            var sessaoEstudos = _context.SessaoEstudos.Include(x => x.Materia).FirstOrDefault(x => x.Id == id);
            var materia = _context.Materias.Find(dto.MateriaId);

            if(sessaoEstudos is null)
            {
                return null;
            }

            if(materia is null)
            {
                return null;
            }

            sessaoEstudos.Materia = materia;
            sessaoEstudos.MateriaId = dto.MateriaId;
            sessaoEstudos.DataInicio = dto.DataInicio;
            sessaoEstudos.DuracaoMinutos = dto.DuracaoMinutos;

            _context.SaveChanges();

            return sessaoEstudos;
        }

        public SessaoEstudo? Deletar(int id)
        {
            var sessaoTarefa = _context.SessaoEstudos.Find(id);

            if(sessaoTarefa is null)
            {
                return null;
            }

            _context.SessaoEstudos.Remove(sessaoTarefa);
            _context.SaveChanges();

            return sessaoTarefa;
        }

        public int? PegarTotalMinutosPorMateria(int materiaId)
        {
            var materia = _context.Materias.Find(materiaId);

            if(materia is null)
            {
                return null;
            }

            return _context.SessaoEstudos
                .Where(x => x.MateriaId == materiaId)
                .Sum(x => x.DuracaoMinutos);
        }
    }
}
