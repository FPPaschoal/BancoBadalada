using BancoBadalada.Models;

namespace BancoBadalada.Services.Interfaces
{
    public interface IDBContextCurso : IServices<TbCurso>
    {
        public ICollection<TbCurso> FindAll();

    }
}
