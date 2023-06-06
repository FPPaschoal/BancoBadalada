using BancoBadalada.Models;
using Microsoft.AspNetCore.Mvc;

namespace BancoBadalada.Services
{
    public interface IDBContextEmpregado : IServices<TbEmpregado>
    {
        public ICollection<TbEmpregado> FindAll();
        public ICollection<TbEmpregado> FindAll(int id);
    }
}
