using BancoBadalada.Models;
using BancoBadalada.Services.Dapper.DATA;
using BancoBadalada.Services.Interfaces;
using System.Data;

namespace BancoBadalada.Services.Dapper
{
    public class DBCursosOferecidosDapper : IDBContextCursosOferecidos
    {
        private readonly IDbConnectionFactory _connection;
        public DBCursosOferecidosDapper(IDbConnectionFactory connection)
        {
            _connection = connection;
        }

        public void Create(TbCursosOferecidos services)
        {
            throw new NotImplementedException();
        }

        public void Delete(TbCursosOferecidos services)
        {
            throw new NotImplementedException();
        }

        public TbCursosOferecidos Find(TbCursosOferecidos services)
        {
            throw new NotImplementedException();
        }

        public ICollection<TbCursosOferecidos> FindAll()
        {
            var connection = _connection.CreateConnection();
        }

        public int GetNextId()
        {
            throw new NotImplementedException();
        }

        public void Update(TbCursosOferecidos services)
        {
            throw new NotImplementedException();
        }
    }
}
