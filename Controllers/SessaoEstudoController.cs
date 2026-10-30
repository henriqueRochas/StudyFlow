using Microsoft.AspNetCore.Mvc;
using StudyFlow.Api.Models;
using StudyFlow.Api.Dtos;
using StudyFlow.Api.Services;

namespace StudyFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SessaoEstudoController : ControllerBase
    {
        private readonly SessaoEstudoService _sessaoEstudoService;

        public SessaoEstudoController(SessaoEstudoService sessaoEstudoService)
        {
            _sessaoEstudoService = sessaoEstudoService;
        }

        [HttpGet]
        public IEnumerable<SessaoEstudo> PegarSessoesEstudo()
        {
            return _sessaoEstudoService.PegarTodas();
        }

        [HttpGet("{id}")]
        public ActionResult<SessaoEstudo> PegarPorId(int id)
        {
            var sessaoEstudo = _sessaoEstudoService.PegarPorId(id);

            if(sessaoEstudo is null)
            {
                return NotFound();
            }

            return sessaoEstudo;
        }

        [HttpGet("materia/{materiaid}/total-minutos")]
        public ActionResult<int?> TotalMinutosPorMateria(int materiaid)
        {
            var sessaoEstudos = _sessaoEstudoService.PegarTotalMinutosPorMateria(materiaid);

            if( sessaoEstudos is null)
            {
                return NotFound();
            }

            return sessaoEstudos;
        }

        [HttpGet("materia/{materiaid}/resumo-progresso")]
        public ActionResult<ResumoProgressoMateriaDto?> PegarResumoProgressoPorMateria(int materiaid)
        {
            var resumoMateria = _sessaoEstudoService.PegarResumoProgressoPorMateria(materiaid);

            if(resumoMateria is null)
            {
                return NotFound();
            }

            return resumoMateria;
        }

        [HttpPost]
        public ActionResult<SessaoEstudo> AdicionarSessaoEstudo(CriarSessaoEstudoDto dto)
        {
            var sessaoEstudos = _sessaoEstudoService.Adicionar(dto);

            if(sessaoEstudos is null)
            {
                return NotFound();
            }

            return sessaoEstudos;
        }

        [HttpPut("{id}")]
        public ActionResult<SessaoEstudo> AtualizarSessaoEstudo(int id, CriarSessaoEstudoDto dto)
        {
            var sessaoEstudo = _sessaoEstudoService.Atualizar(id, dto);

            if( sessaoEstudo is null)
            {
                return NotFound();
            }

            return sessaoEstudo;
        }

        [HttpDelete("{id}")]
        public ActionResult<SessaoEstudo> DeletarSessaoEstudo(int id)
        {
            var sessaoEstudos = _sessaoEstudoService.Deletar(id);

            if( sessaoEstudos is null)
            {
                return NotFound();
            }

            return sessaoEstudos;
        }
    }
}
