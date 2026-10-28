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
    }
}
