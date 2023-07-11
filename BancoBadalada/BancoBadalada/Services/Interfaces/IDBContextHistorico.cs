using BancoBadalada.Models;


namespace BancoBadalada.Services.Interfaces
{
    public interface IDBContextHistorico : IServices<TbHistorico>
    {
        public ICollection<TbHistorico> FindAllEmp(int idEmpregado);
    }
}
