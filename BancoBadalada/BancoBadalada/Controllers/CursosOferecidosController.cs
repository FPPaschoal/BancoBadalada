using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoBadalada.Controllers
{
    public class CursosOferecidosController : Controller
    {
        private readonly IDBContextCursosOferecidos _service;

        public CursosOferecidosController(IDBContextCursosOferecidos service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.FindAll());
        }
    }
}
