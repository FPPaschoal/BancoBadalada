using BancoBadalada.Models;

namespace BancoBadalada.Services
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
