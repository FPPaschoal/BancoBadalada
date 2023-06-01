using Microsoft.AspNetCore.Mvc;

namespace BancoBadalada.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
