using BancoBadalada.Models;

namespace BancoBadalada.Services
{
    public interface IDBContextDepartamento : IServices<TbDepartamento>
    {
        public ICollection<TbDepartamento> FindAll();
    }
}
