using Microsoft.AspNetCore.Mvc;
using StudyFlow.Api.Models;
using StudyFlow.Api.Data;

namespace StudyFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MateriasController : ControllerBase
{
    private readonly StudyFlowContext _context;

    public MateriasController(StudyFlowContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Materia> PegarMaterias()
    {
        return _context.Materias.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Materia> PegarMateriasPeloId(int id)
    {
        var materia = _context.Materias.Find(id);

        if(materia is null)
        {
            return NotFound();
        }

        return materia;

    }

    //[HttpPost]
    //public Materia AdicionarMaterias(Materia materia)
    //{
    //    _context.
    //    _context.Materias.Add(materia);
    //    _context.SaveChanges();

    //    return materia;
    //}

    [HttpPut("{id}")]
    public ActionResult<Materia> AtualizarDados(int id, Materia materia)
    {
        var materiaExistente = _context.Materias.Find(id);

        if(materiaExistente is null)
        {
            return NotFound();
        }

        materiaExistente.Nome = materia.Nome;
        _context.SaveChanges();

        return materiaExistente;
    }

    [HttpDelete("{id}")]
    public ActionResult<Materia> DeletarDatos(int id)
    {
        var materia = _context.Materias.Find(id);

        if(materia is null)
        {
            return NotFound();
        }

        _context.Materias.Remove(materia);
        _context.SaveChanges();

        return materia;
    }
}
