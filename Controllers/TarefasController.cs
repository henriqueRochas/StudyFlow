using Microsoft.AspNetCore.Mvc;
using StudyFlow.Api.Models;
using StudyFlow.Api.Dtos;
using StudyFlow.Api.Services;

namespace StudyFlow.Api.Controllers
{
    [ApiController] // DIZ QUE ESSA CLASSE É UMA API
    [Route("api/[controller]")]

    public class TarefasController : ControllerBase
    {
        private readonly TarefaService _tarefaService;

        public TarefasController(TarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public IEnumerable<Tarefa> PegarTarefas()
        {
            return _tarefaService.PegarTodas();
        }

        [HttpGet("{id}")]
        public ActionResult<Tarefa> PegarTarefasPorId(int id)
        {
            var tarefa = _tarefaService.PegarPorId(id);

            if(tarefa is null)
            {
                return NotFound();
            }

            return tarefa;
        }

        [HttpGet("materia/{materiaId}")] // Esse endpoint faz com que a busca seja feita com base no id da materia
        public IEnumerable<Tarefa> PegarTarefasPorMateria(int materiaId)
        {
            var tarefas = _tarefaService.PegarPorMateriaId(materiaId);

            return tarefas;
        }

        [HttpPost]
        public ActionResult<Tarefa> AdicionarTarefas(CriarTarefaDto dto)
        {

            var tarefa = _tarefaService.Adicionar(dto);

            if(tarefa is null)
            {
                return NotFound();
            }

            return tarefa;
        }

        [HttpPut("{id}")]
        public ActionResult<Tarefa> AtualizarTarefas(int id, CriarTarefaDto dto)
        {
            var tarefa = _tarefaService.Atualizar(id, dto);

            if(tarefa is null)
            {
                return NotFound();
            }

            return tarefa;
        }

        [HttpDelete("{id}")]
        public ActionResult<Tarefa> DeletarTarefa(int id)
        {
            var tarefa = _tarefaService.Deletar(id);

            if(tarefa is null)
            {
                return NotFound();
            }

            return tarefa;
        }
    }
}
