using BancoBadalada.Models;

namespace BancoBadalada.Services
{
    public class DBMatricula : IDBContextMatricula
    {
        public readonly AcademicoContext _academicoContext;

        public DBMatricula(AcademicoContext academicoContext)
        {
            _academicoContext = academicoContext;
        }

        public void Create(TbMatricula matricula)
        {
            _academicoContext.TbMatriculas.Add(matricula);
            _academicoContext.SaveChanges();
        }

        public void Delete(TbMatricula matricula)
        {
            _academicoContext.TbMatriculas.Remove(matricula);
            _academicoContext.SaveChanges();
        }

        public TbMatricula Find(TbMatricula matricula)
        {
            return _academicoContext.TbMatriculas.First(x => x.IdCurso == matricula.IdCurso && x.IdParticipante == matricula.IdParticipante && x.DtInicio == matricula.DtInicio);
        }

        public ICollection<TbMatricula> FindAll()
        {
            return _academicoContext.TbMatriculas.ToList();
        }
        public ICollection<TbMatricula>FindAll(int id)
        {
            return _academicoContext.TbMatriculas.Where(x => x.IdParticipante == id).ToList();
        }

        public ICollection<TbMatricula>GetAlunos(string idCurso, string dtCurso)
        {
            DateTime data = DateTime.Parse(dtCurso);
            return _academicoContext.TbMatriculas.Where(x => x.IdCurso == idCurso && x.DtInicio == data).ToList();
        }

        public void Update(TbMatricula services)
        {
            _academicoContext.TbMatriculas.Update(services);
            _academicoContext.SaveChanges();
        }

        public int GetNextId()
        {
            return 1;
        }
    }
}
