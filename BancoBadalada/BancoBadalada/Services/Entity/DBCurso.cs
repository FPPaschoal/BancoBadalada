using BancoBadalada.Models;
using BancoBadalada.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BancoBadalada.Services.Entity
{
    public class DBCurso : IDBContextCurso
    {

        public readonly AcademicoContext _academicoContext;

        public DBCurso(AcademicoContext academicoContext)
        {
            _academicoContext = academicoContext;
        }

        public void Create(TbCurso Curso)
        {
            _academicoContext.TbCursos.Add(Curso);
            _academicoContext.SaveChanges();
        }

        public void Delete(TbCurso Curso)
        {
            try
            {
                _academicoContext.TbCursos.Remove(Curso);
                _academicoContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public TbCurso Find(TbCurso Curso)
        {
            return _academicoContext.TbCursos.First(x => x.IdCurso == Curso.IdCurso);
        }

        public ICollection<TbCurso> FindAll()
        {
            return _academicoContext.TbCursos.ToList();
        }
        public void Update(TbCurso services)
        {
            _academicoContext.TbCursos.Update(services);
            _academicoContext.SaveChanges();
        }

        public int GetNextId()
        {
            return 1;
        }

    }
}
