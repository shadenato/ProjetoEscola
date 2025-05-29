using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoEscola.Repositorio;

namespace ProjetoEscola.Controllers
{
    public class EscolaController : Controller
    {
        // Declarando a variável que o construtar vai receber
        private readonly AlunoRespRepositorio _alunoresprepositorio;

        public EscolaController(AlunoRespRepositorio alunoresprepositorio)
        {
            _alunoresprepositorio = alunoresprepositorio;
        }

        public IActionResult ResponsaveisAlunos()
        {
            var data = _alunoresprepositorio.ResponsavelComAlunos();
            return View(data);
        }

        public IActionResult ConsultarResponsaveis()
        {
            var alunos = _alunoresprepositorio.Alunos();
            ViewBag.Alunos = new SelectList(alunos, "CodAluno", "nome");
            ViewBag.HasAlunos = alunos != null && alunos.Any();
            return View();
        }
    }
}
