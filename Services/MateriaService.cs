using StudyFlow.Api.Data;
using StudyFlow.Api.Models;
using StudyFlow.Api.Dtos;

namespace StudyFlow.Api.Services
{
    public class MateriaService
    {
        private readonly StudyFlowContext _context;

        public MateriaService(StudyFlowContext context)
        {
            _context = context;
        }

        public List<Materia> PegarTodas()
        {
            return _context.Materias.ToList();
        }

        public Materia? PegarPorId(int id)
        {
            return _context.Materias.Find(id);
        }

        public Materia Adicionar(CriarMateriaDto dto)
        {
            var nome = dto.Nome.Trim(); 

            var materia = new Materia // COMO AINDA NÃO HAVIA UMA ENTIDADE, FOI NECESSARIO CRIAR ESSA
            {
                Nome = nome
            };

            _context.Materias.Add(materia); //PREPARA OS DADOS PARA QUE POSSAM SER SALVOS NO BANCO
            _context.SaveChanges(); // SALVA OS DADOS NO BANCO

            return materia;
        }

        public Materia? Atualizar(int id, AtualizarMateriaDto dto)
        {
            // NESSE CASO COMO JÁ HAVIA UMA ENTIDADE EXISTENTE, NÃO FOI NECESSARIO CRIAR UMA

            var materia = _context.Materias.Find(id);

            if(materia is null)
            {
                return null;
            }

            materia.Nome = dto.Nome.Trim();

            _context.SaveChanges();

            return materia;
        }

        public Materia? Deletar(int id)
        {
            var materia = _context.Materias.Find(id);

            if(materia is null)
            {
                return null;
            }

            _context.Materias.Remove(materia);
            _context.SaveChanges();

            return materia;
        }
    }
}
