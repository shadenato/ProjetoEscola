using Microsoft.AspNetCore.Http.HttpResults;

namespace ProjetoEscola.Models
{
    public class Aluno
    {
        public int CodAluno { get; set; }
        public string? Nome{ get; set; }
        public int Idade { get; set; }

    }
}