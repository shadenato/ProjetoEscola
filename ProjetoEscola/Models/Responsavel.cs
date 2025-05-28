using Microsoft.AspNetCore.Http.HttpResults;

namespace ProjetoEscola.Models
{
    public class Responsavel
    {
        public int CodResp { get; set; }
        public int CodAluno { get; set; }
        public string? Nome { get; set; }

        public Aluno Aluno { get; set; }
    }
}