using Microsoft.AspNetCore.Mvc;
using StudyFlow.Api.Models;
using StudyFlow.Api.Dtos;
using StudyFlow.Api.Services;

namespace StudyFlow.Api.Controllers;

[ApiController] // DIZ QUE ESSA CLASSE É UMA API
[Route("api/[controller]")]

public class MateriasController : ControllerBase
{
    private readonly MateriaService _materiaService;

    public MateriasController(MateriaService materiaService)
    {
        _materiaService = materiaService;
    }

    [HttpGet] // MÉTODO QUE BUSCA OS DADOS SOLICITADOS
    public IEnumerable<Materia> PegarMaterias()
    {
        return _materiaService.PegarTodas();
    }

    [HttpGet("{id}")] // FAZ A BUSCA COM BASE NO ID
    public ActionResult<Materia> PegarMateriasPeloId(int id) // O ActionResult<> FAZ COM QUE SEJA POSSIVEL OBTER A MENSAGEM DE RETORNO DO HTTP.
    {
        var materia = _materiaService.PegarPorId(id); // O FIND VAI PROCURAR UM ITEM QUE JÁ EXISTE COM BASE NA CHAVE PRIMARIA

        if (materia is null)
        {
            return NotFound(); // O NOT FOUND É O TIPO DE RETORNO
        }

        return materia;

    }

    [HttpPost] // MÉTODO QUE AJUDA A CRIA O DADO
    public Materia AdicionarMaterias(CriarMateriaDto dto)
    {
        return _materiaService.Adicionar(dto);
    }

    [HttpPut("{id}")] // MÉTODO QUE ATUALIZA OS DADOS
    public ActionResult<Materia> AtualizarDados(int id, AtualizarMateriaDto dto)
    {
        var materia = _materiaService.Atualizar(id, dto);

        if (materia is null)
        {
            return NotFound();
        }

        return materia;
    }

    [HttpDelete("{id}")] // METODO QUE DELETA ITENS
    public ActionResult<Materia> DeletarDados(int id)
    {
        var materia = _materiaService.Deletar(id);

        if (materia is null)
        {
            return NotFound();
        } 

        return materia;
    }
}