using BancoBadalada.Models;

namespace BancoBadalada.Services
{
    public interface IDBContextCursos : IServices<TbCurso>
    {
        public ICollection<TbCurso> FindAll();

    }
}
