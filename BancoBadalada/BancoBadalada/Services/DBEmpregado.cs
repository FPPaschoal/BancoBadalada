using BancoBadalada.Models;

namespace BancoBadalada.Services
{
    public class DBEmpregado : IDBContextEmpregado
    {

        public readonly AcademicoContext _academicoContext;

        public DBEmpregado(AcademicoContext academicoContext)
        {
            _academicoContext = academicoContext;
        }

        public void Create(TbEmpregado Empregado)
        {
            _academicoContext.TbEmpregados.Add(Empregado);
            _academicoContext.SaveChanges();
        }

        public void Delete(TbEmpregado Empregado)
        {
            _academicoContext.TbEmpregados.Remove(Empregado);
            _academicoContext.SaveChanges();
        }

        public TbEmpregado Find(TbEmpregado Empregado)
        {
            return _academicoContext.TbEmpregados.First(x => x.IdEmpregado == Empregado.IdEmpregado);
        }

        public ICollection<TbEmpregado> FindAll()
        {
            return _academicoContext.TbEmpregados.ToList();
        }
        public void Update(TbEmpregado services)
        {
            _academicoContext.TbEmpregados.Update(services);
            _academicoContext.SaveChanges();
        }

        public int GetNextId()
        {
            return _academicoContext.TbEmpregados.OrderBy(m => m.IdEmpregado).Reverse().FirstOrDefault().IdEmpregado + 1;
        }

    }
}
