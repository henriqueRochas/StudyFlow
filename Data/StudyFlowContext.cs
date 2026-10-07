using Microsoft.EntityFrameworkCore;
using StudyFlow.Api.Models;

namespace StudyFlow.Api.Data;

public class StudyFlowContext : DbContext
{
    public StudyFlowContext(DbContextOptions<StudyFlowContext> options) : base(options)
    {

    }

    public DbSet<Materia> Materias { get; set; }
}

