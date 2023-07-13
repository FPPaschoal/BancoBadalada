using BancoBadalada.Models;
using BancoBadalada.Services.Dapper.DATA;
using BancoBadalada.Services.Entity;
using BancoBadalada.Services.Interfaces;
using Dapper;

namespace BancoBadalada.Services.Dapper
{
    public class DbCursoDapper : IDBContextCurso
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DbCursoDapper(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Create(TbCurso curso)
        {
            using var connection = _connectionFactory.CreateConnection();

            string query = @"   INSERT INTO tb_cursos(id_curso,ds_curso,categoria,duracao)
                                VALUES (@IdCurso, @DsCurso, @Categoria, @Duracao)";

            connection.Execute(query, curso);
        }

        public void Delete(TbCurso curso)
        {
            using var connection = _connectionFactory.CreateConnection();

            string query = "DELETE FROM tb_cursos WHERE id_curso = @IdCurso";

            connection.Execute(query, new { IdCurso = curso.IdCurso });
        }

        public TbCurso Find(TbCurso curso)
        {
            using var connection = _connectionFactory.CreateConnection();

            string query = @"
               SELECT
                    id_curso as IdCurso,
                    ds_curso as DsCurso,
                    categoria as Categoria,
                    duracao as Duracao,
                    fg_ativo as FgAtivo
                FROM tb_cursos as TbCurso
                WHERE id_curso = @IdCurso
                ";

            var resultado = connection.Query<TbCurso>(query, new {IdCurso = curso.IdCurso});
            return resultado.FirstOrDefault();
        }

        public ICollection<TbCurso> FindAll()
        {
            using var connection = _connectionFactory.CreateConnection();

            string query = @"
               SELECT
                    id_curso as IdCurso,
                    ds_curso as DsCurso,
                    categoria as Categoria,
                    duracao as Duracao,
                    fg_ativo as FgAtivo
                FROM tb_cursos as TbCurso
                ";

            var resultado = connection.Query<TbCurso>(query).ToList();
            return resultado;
        }

        public int GetNextId()
        {
            throw new NotImplementedException();
        }

        public void Update(TbCurso curso)
        {
            var connection = _connectionFactory.CreateConnection();

            string query = @"   UPDATE tb_cursos
                                SET ds_curso = @DsCurso, categoria = @Categoria, duracao = @Duracao, fg_ativo = @FgAtivo
                                WHERE id_curso = @IdCurso";

            connection.Execute(query, curso);
        }
    }
}
