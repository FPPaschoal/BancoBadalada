using Microsoft.AspNetCore.Mvc;

namespace BancoBadalada.Controllers
{
    public class EmpregadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
