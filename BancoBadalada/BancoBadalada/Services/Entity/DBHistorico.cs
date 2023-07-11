using BancoBadalada.Models;
using BancoBadalada.Services.Interfaces;

namespace BancoBadalada.Services.Entity
{
    public class DBHistorico : IDBContextHistorico
    {
        private readonly AcademicoContext _academicoContext;

        public DBHistorico(AcademicoContext academicoContext)
        {
            _academicoContext = academicoContext;
        }

        public void Create(TbHistorico services)
        {
            _academicoContext.TbHistoricos.Add(services);
            _academicoContext.SaveChanges();
        }

        public void Delete(TbHistorico services)
        {
            _academicoContext.TbHistoricos.Remove(services);
            _academicoContext.SaveChanges();
        }

        public TbHistorico Find(TbHistorico services)
        {
            throw new NotImplementedException();
        }

        public ICollection<TbHistorico> FindAll()
        {
            throw new NotImplementedException();
        }
        public ICollection<TbHistorico> FindAllEmp(int idEmpregado)
        {
            return _academicoContext.TbHistoricos.Where(c => c.IdEmpregado == idEmpregado).ToList();
        }
        public int GetNextId()
        {
            throw new NotImplementedException();
        }

        public void Update(TbHistorico services)
        {
            throw new NotImplementedException();
        }
    }
}
