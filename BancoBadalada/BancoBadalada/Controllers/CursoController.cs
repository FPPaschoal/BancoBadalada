using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoBadalada.Controllers
{
    public class CursoController : Controller
    {
        private readonly IDBContextCurso _service;

        public CursoController(IDBContextCurso service)
        {
            _service = service;
        }
        public IActionResult index()
        {
            return View(_service.FindAll());
        }
    }
}
