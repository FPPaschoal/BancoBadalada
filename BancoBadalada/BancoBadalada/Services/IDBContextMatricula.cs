using BancoBadalada.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace BancoBadalada.Services
{
    public interface IDBContextMatricula : IServices<TbMatricula>
    {
        public ICollection<TbMatricula> FindAll(int id);
        public ICollection<TbMatricula> GetAlunos(string id, string dtCurso);
    }
}
