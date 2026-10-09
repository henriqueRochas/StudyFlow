using Microsoft.AspNetCore.Mvc;
using StudyFlow.Api.Models;
using StudyFlow.Api.Data;
using StudyFlow.Api.Dtos;

namespace StudyFlow.Api.Controllers;

[ApiController] // DIZ QUE ESSA CLASSE É UMA API
[Route("api/[controller]")]
public class MateriasController : ControllerBase
{
    private readonly StudyFlowContext _context;

    public MateriasController(StudyFlowContext context)
    {
        _context = context;
    }

    [HttpGet] // MÉTODO QUE BUSCA OS DADOS SOLICITADOS
    public IEnumerable<Materia> PegarMaterias()
    {
        return _context.Materias.ToList();
    }

    [HttpGet("{id}")] // FAZ A BUSCA COM BASE NO ID
    public ActionResult<Materia> PegarMateriasPeloId(int id) // O ActionResult<> FAZ COM QUE SEJA POSSIVEL OBTER A MENSAGEM DE RETORNO DO HTTP.
    {
        var materia = _context.Materias.Find(id); // O FIND VAI PROCURAR UM ITEM QUE JÁ EXISTE COM BASE NA CHAVE PRIMARIA

        if(materia is null)
        {
            return NotFound(); // O NOT FOUND É O TIPO DE RETORNO
        }

        return materia;

    }

    [HttpPost] // MÉTODO QUE AJUDAR A CRIA O DADO
    public Materia AdicionarMaterias(CriarMateriaDto dto)
    {
        var nome = dto.Nome.Trim();

        var materia = new Materia // COMO AINDA NÃO HAVIA UMA ENTIDADE, FOI NECESSARIO CRIAR ESSA
        {
            Nome = nome,
        };

        _context.Materias.Add(materia); //PREPARA OS DADOS PARA QUE POSSAM SER SALVO NO BANCO
        _context.SaveChanges(); // SALVA OS DADOS NO BANCO

        return materia;
    }

    [HttpPut("{id}")] // MÉTODO QUE ATUALIZA OS DADOS
    public ActionResult<Materia> AtualizarDados(int id, AtualizarMateriaDto dto)
    {
        // NESSE CASO COMO JÁ HAVIA UMA ENTIDADE EXISTENTE, NÃO FOI NECESSARIO CRIAR UMA

        var materiaExistente = _context.Materias.Find(id);

        if(materiaExistente is null)
        {
            return NotFound();
        }

        materiaExistente.Nome = dto.Nome.Trim(); // PEGA O ITEM QUE JÁ EXISTE E ATUALIZA ELE
        _context.SaveChanges();

        return materiaExistente;
    }

    [HttpDelete("{id}")] // METODO QUE DELETA ITENS
    public ActionResult<Materia> DeletarDados(int id)
    {
        var materia = _context.Materias.Find(id);

        if(materia is null)
        {
            return NotFound();
        }

        _context.Materias.Remove(materia); // REMOVEM O ITEM
        _context.SaveChanges();

        return materia;
    }
}