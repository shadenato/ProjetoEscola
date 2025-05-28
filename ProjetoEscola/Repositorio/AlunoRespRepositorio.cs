using ProjetoEscola.Models;
using MySql.Data.MySqlClient;

namespace ProjetoEscola.Repositorio
{
    public class AlunoRespRepositorio
    {
        //Declarando a string de conexão como somente leitura
        private readonly string _connectionString;

        //Construtor que recebe a string de conexão
        public AlunoRespRepositorio(string connectionString)
        {
            _connectionString = connectionString;
        }

        //Método ResponsavelComAlunos
        public List<RespAluno> ResponsavelComAlunos()
        {
            var lista = new List<RespAluno>();

            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                string query = @"select t1.codResp as 'Código do responsável',
                    t1.nome as 'Nome do responsável',
                    t2.nome as 'Nome do aluno'
                    from responsavel t1
                    inner join aluno t2 on t1.codAluno = t2.codAluno;";

                using (MySqlCommand comando = new MySqlCommand(query, conexao))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new RespAluno
                            {
                                CodResp = reader.GetInt32("CodResp"),
                                NomeResponsavel = reader.GetString("NomeResponsavel"),
                                NomeAluno = reader.GetString("NomeAluno")
                            });
                        }
                    }
                }
                return lista;
            }
        }
    }
}
