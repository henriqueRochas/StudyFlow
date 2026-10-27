using StudyFlow.Api.Data;
using StudyFlow.Api.Dtos;
using StudyFlow.Api.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace StudyFlow.Api.Services
{
    public class TarefaService
    {
       private readonly StudyFlowContext _context;

       public TarefaService(StudyFlowContext context)
       {
             _context = context;
       }

        public List<Tarefa> PegarTodas()
        {
            return _context.Tarefas.Include(t => t.Materia).ToList();
        }

        public Tarefa? PegarPorId(int id)
        {
            return _context.Tarefas.Include(t => t.Materia).FirstOrDefault(t => t.Id == id);
        }

        public Tarefa? Adicionar(CriarTarefaDto dto)
        {
            var titulo = dto.Titulo.Trim();
            var materia = _context.Materias.Find(dto.MateriaId);
            DateOnly? dataVencimento = dto.DataVencimentoTarefa;

            if(materia is null)
            {
                return null;
            }

            var tarefa = new Tarefa
            {
                Titulo = titulo,
                MateriaId = dto.MateriaId,
                DataVencimentoTarefa = dataVencimento,
            };


            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            return tarefa;
        }

        public Tarefa? Atualizar(int id, CriarTarefaDto dto)
        {
            var tarefa = _context.Tarefas.Include(t => t.Materia).FirstOrDefault(t => t.Id == id);
            var materia = _context.Materias.Find(dto.MateriaId);

            if (tarefa is null)
            {
                return null;
            }

            if (materia is null)
            {
                return null;
            }

            tarefa.MateriaId = dto.MateriaId;
            tarefa.Materia = materia;
            tarefa.Titulo = dto.Titulo.Trim();
            tarefa.DataVencimentoTarefa = dto.DataVencimentoTarefa;
            _context.SaveChanges();

            return tarefa;
        }

        public Tarefa? Deletar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa is null)
            {
                return null;
            }

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();

            return tarefa;
        }

        public List<Tarefa>? PegarPorMateriaId(int materiaId)
        {
            var materia = _context.Materias.Find(materiaId);

            if(materia is null)
            {
                return null;
            }

           return _context.Tarefas
                .Where(x => x.MateriaId == materiaId)
                .Include(t => t.Materia)
                .ToList();
        }

        public Tarefa? Concluir(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa is null)
            {
                return null;
            }

            tarefa.Concluida = true;

            _context.SaveChanges();

            return tarefa;
        }

        public Tarefa? Reabrir(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa is null)
            {
                return null;
            }

            tarefa.Concluida = false;

            _context.SaveChanges();


            return tarefa;

        }

        public List<Tarefa> PegarPorConclusao(bool status)
        {
            return _context.Tarefas
                .Where(t => t.Concluida == status)
                .Include(t => t.Materia)
                .ToList();
        }

        public List<Tarefa> PegarAtrasadas()
        {
            var hoje = DateOnly.FromDateTime(DateTime.Today);

            return _context.Tarefas
                .Where(x => x.DataVencimentoTarefa.HasValue && x.DataVencimentoTarefa.Value < hoje && x.Concluida == false)
                .Include(x => x.Materia)
                .ToList();
        }
    }
}
