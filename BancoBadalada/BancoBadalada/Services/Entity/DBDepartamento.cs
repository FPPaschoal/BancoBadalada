using BancoBadalada.Models;
using BancoBadalada.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BancoBadalada.Services.Entity
{
    public class DBDepartamento : IDBContextDepartamento
    {
        private readonly AcademicoContext _academicoContext;

        public DBDepartamento(AcademicoContext academicoContext)
        {
            _academicoContext = academicoContext;
        }

        public void Create(TbDepartamento departamento)
        {
            _academicoContext.TbDepartamentos.Add(departamento);
            _academicoContext.SaveChanges();
        }

        public void Delete(TbDepartamento departamento)
        {
            _academicoContext.TbDepartamentos.Remove(departamento);
            _academicoContext.SaveChanges();
        }

        public TbDepartamento Find(TbDepartamento departamento)
        {
            return _academicoContext.TbDepartamentos.First(x => x.IdDepartamento == departamento.IdDepartamento);
        }

        public ICollection<TbDepartamento> FindAll()
        {
            return _academicoContext.TbDepartamentos.ToList();
        }
        public void Update(TbDepartamento services)
        {
            _academicoContext.TbDepartamentos.Update(services);
            _academicoContext.SaveChanges();
        }

        public int GetNextId()
        {
            return _academicoContext.TbDepartamentos.OrderBy(m => m.IdDepartamento).Reverse().FirstOrDefault().IdDepartamento + 10;
        }
    }
}
