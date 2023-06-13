using BancoBadalada.Models;

namespace BancoBadalada.Services
{
    public class DBCursosOferecidos : IDBContextCursosOferecidos
    {
        public readonly AcademicoContext _academicoContext;

        public DBCursosOferecidos(AcademicoContext academicoContext)
        {
            _academicoContext = academicoContext;
        }

        public void Create(TbCursosOferecidos Curso)
        {
            _academicoContext.TbCursosOferecidos.Add(Curso);
            _academicoContext.SaveChanges();
        }

        public void Delete(TbCursosOferecidos Curso)
        {
            _academicoContext.TbCursosOferecidos.Remove(Curso);
            _academicoContext.SaveChanges();
        }

        public TbCursosOferecidos Find(TbCursosOferecidos Curso)
        {
            return _academicoContext.TbCursosOferecidos.First(x => x.IdCurso == Curso.IdCurso);
        }

        public ICollection<TbCursosOferecidos> FindAll()
        {
            return _academicoContext.TbCursosOferecidos.ToList();
        }
        public void Update(TbCursosOferecidos services)
        {
            _academicoContext.TbCursosOferecidos.Update(services);
            _academicoContext.SaveChanges();
        }

        public int GetNextId()
        {
            return 1;
        }

    }
}
