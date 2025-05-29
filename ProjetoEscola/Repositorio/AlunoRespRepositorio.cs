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
                string query = @"select t1.codResp as 'Codigo do responsavel',
                    t1.nome as 'Nome do responsavel',
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
                                CodResp = reader.GetInt32("Codigo do responsavel"),
                                NomeResponsavel = reader.GetString("Nome do responsavel"),
                                NomeAluno = reader.GetString("Nome do aluno")
                            });
                        }
                    }
                }
                return lista;
            }
        }

        //METODO QUE LISTA TODOS OS ALUNOS
        public List<Aluno> Alunos()
        {
            var lista = new List<Aluno>();
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                string query = "SELECT codAluno, nome, idade FROM aluno";
                using (MySqlCommand comando = new MySqlCommand(query, conexao))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Aluno
                            {
                                CodAluno = reader.GetInt32("codAluno"),
                                Nome = reader.GetString("nome"),
                                Idade = reader.GetInt32("idade")
                            });
                        }
                    }
                }
            }
            return lista;
        }

        //METODO QUE LISTA TODOS OS RESPONSAVEIS POR ALUNO
        public List<Responsavel> ResponsaveisPorAluno(int codAluno)
        {
            var lista = new List<Responsavel>();
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                string query = "SELECT codResp, codAluno, nome FROM responsavel WHERE codAluno = @codAluno";
                using (MySqlCommand comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@codAluno", codAluno);
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Responsavel
                            {
                                CodResp = reader.GetInt32("codResp"),
                                CodAluno = reader.GetInt32("codAluno"),
                                Nome = reader.GetString("nome")
                            });
                        }
                    }
                }
            }
            return lista;
        }


    }
}
