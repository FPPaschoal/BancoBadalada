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

        public void Create(TbCurso services)
        {
            throw new NotImplementedException();
        }

        public void Delete(TbCurso services)
        {
            throw new NotImplementedException();
        }

        public TbCurso Find(TbCurso services)
        {
            throw new NotImplementedException();
        }

        public ICollection<TbCurso> FindAll()
        {
            using var connection = _connectionFactory.CreateConnection();

            string query = @"
               SELECT 
                    TbCurso.id_curso as IdCurso,
                    ds_curso as DsCurso,
                    categoria as Categoria,
                    duracao as Duracao,
                    TbCurso.fg_ativo as FgAtivo,


                    TbCursosOferecidos.id_curso as IdCurso,
                    dt_inicio as DtInicio,
                    id_instrutor as IdInstrutor,
                    localizacao as Localizacao,
                    TbCursosOferecidos.fg_ativo as FgAtivo
                FROM tb_cursos as TbCurso
                INNER JOIN tb_cursos_oferecidos TbCursosOferecidos ON (TbCurso.id_curso = TbCursosOferecidos.id_curso)
                ";
            var cursos = new List<TbCurso>();

            TbCurso mapeamento(TbCurso curso,TbCursosOferecidos cursoOferecido)
            {
                var cursoExistente = cursos.FirstOrDefault(c => c.IdCurso == curso.IdCurso);

                if (cursoExistente is null)
                {
                    cursoExistente = curso;
                    cursoExistente.TbCursosOferecidos = new List<TbCursosOferecidos>();
                    cursos.Add(cursoExistente);
                }

                cursoExistente.TbCursosOferecidos.Add(cursoOferecido);

                return cursoExistente;
            };
            var resultado = connection.Query<TbCurso, TbCursosOferecidos, TbCurso>(
                sql: query,
                map: mapeamento,
                splitOn: "IdCurso,IdCurso"
                );

            return resultado.ToList();
        }

        public int GetNextId()
        {
            throw new NotImplementedException();
        }

        public void Update(TbCurso services)
        {
            throw new NotImplementedException();
        }
    }
}
