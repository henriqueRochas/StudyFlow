using StudyFlow.Api.Data;
using StudyFlow.Api.Dtos;
using StudyFlow.Api.Models;
using System.Linq;

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
            return _context.Tarefas.ToList();
        }

        public Tarefa? PegarPorId(int id)
        {
            return _context.Tarefas.Find(id);
        }

        public Tarefa? Adicionar(CriarTarefaDto dto)
        {
            var titulo = dto.Titulo.Trim();
            var materia = _context.Materias.Find(dto.MateriaId);

            if(materia is null)
            {
                return null;
            }

            var tarefa = new Tarefa
            {
                Titulo = titulo,
                MateriaId = dto.MateriaId,
            };


            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            return tarefa;
        }

        public Tarefa? Atualizar(int id, CriarTarefaDto dto)
        {
            var tarefa = _context.Tarefas.Find(id);
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
            tarefa.Titulo = dto.Titulo.Trim();
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
    }
}
