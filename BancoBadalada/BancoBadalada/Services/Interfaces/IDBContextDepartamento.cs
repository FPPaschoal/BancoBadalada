using BancoBadalada.Models;

namespace BancoBadalada.Services.Interfaces
{
    public interface IDBContextDepartamento : IServices<TbDepartamento>
    {
        public ICollection<TbDepartamento> FindAll();
    }
}
