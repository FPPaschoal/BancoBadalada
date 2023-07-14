using BancoBadalada.Models;
using BancoBadalada.Services.Dapper.DATA;
using BancoBadalada.Services.Interfaces;
using Dapper;
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
            var connection = _connection.CreateConnection();

            string query = @"INSERT INTO tb_cursos_oferecidos(id_curso,dt_inicio,id_instrutor,localizacao)
                             VALUES 
                             (@IdCurso, @DtInicio, @IdInstrutor, @Localizacao)";

            connection.Execute(query, services);

        }

        public void Delete(TbCursosOferecidos cursosOferecidos)
        {
            var connection = _connection.CreateConnection();

            string query = @"DELETE FROM tb_cursos_oferecidos WHERE id_curso = @IdCurso AND dt_inicio = @DtInicio";

            connection.Execute(query, cursosOferecidos);
        }

        public TbCursosOferecidos Find(TbCursosOferecidos cursoOferecido)
        {
            var connection = _connection.CreateConnection();

            string query = @"SELECT id_curso AS IdCurso,
                                    dt_inicio AS DtInicio,
                                    id_instrutor AS IdInstrutor,
                                    localizacao AS Localizacao,
                                    fg_ativo AS FgAtivo
                             FROM tb_cursos_oferecidos
                             WHERE id_curso = @IdCurso AND dt_inicio = @DtIncio";

            var resultado = connection.Query<TbCursosOferecidos>(query, new {IdCurso = cursoOferecido.IdCurso, DtIncio = cursoOferecido.DtInicio}).FirstOrDefault();

            var result = connection.QueryFirstOrDefault<TbCursosOferecidos>(query, new { IdCurso = cursoOferecido.IdCurso, DtIncio = cursoOferecido.DtInicio });

            return result;
        }

        public ICollection<TbCursosOferecidos> FindAll()
        {
            var connection = _connection.CreateConnection();

            string query = @"SELECT id_curso AS IdCurso,
                                    dt_inicio AS DtInicio,
                                    id_instrutor AS IdInstrutor,
                                    localizacao AS Localizacao,
                                    fg_ativo AS FgAtivo
                             FROM tb_cursos_oferecidos";

            var resultado = connection.Query<TbCursosOferecidos>(query).ToList();

            return resultado;
        }

        public int GetNextId()
        {
            throw new NotImplementedException();
        }

        public void Update(TbCursosOferecidos cursosOferecidos)
        {
            var connection = _connection.CreateConnection();

            string query = @"UPDATE tb_cursos_oferecidos
                             SET fg_ativo = @FgAtivo,
                                 id_instrutor = @IdInstrutor,
                                 localizacao = @Localizacao
                             WHERE id_curso = @IdCurso AND dt_inicio = @DtInicio";

            connection.Execute(query, cursosOferecidos);
        }
    }
}
