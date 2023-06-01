using BancoBadalada.Models;

namespace BancoBadalada.Services
{
    public interface IDBContextCurso : IServices<TbCurso>
    {
        public ICollection<TbCurso> FindAll();

    }
}
