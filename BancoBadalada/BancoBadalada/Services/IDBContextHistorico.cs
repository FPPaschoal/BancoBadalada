using BancoBadalada.Models;


namespace BancoBadalada.Services
{
    public interface IDBContextHistorico : IServices<TbHistorico>
    {
        public ICollection<TbHistorico> FindAllEmp(int idEmpregado);
    }
}
