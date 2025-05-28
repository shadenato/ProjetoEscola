using Microsoft.AspNetCore.Mvc;

namespace ProjetoEscola.Controllers
{
    public class EscolaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
