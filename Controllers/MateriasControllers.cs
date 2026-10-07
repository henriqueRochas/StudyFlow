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

    [HttpPost]
    public Materia AdicionarMaterias(Materia materia)
    {
        _context.Materias.Add(materia);
        _context.SaveChanges();

        return materia;
    }
}
