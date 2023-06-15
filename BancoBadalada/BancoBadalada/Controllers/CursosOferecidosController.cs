using BancoBadalada.Models;
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
        public IActionResult Oferecer(string id) 
        {
            var Aux = new TbCursosOferecidos();
            Aux.IdCurso = id;
            return View(Aux);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Oferecer([Bind("IdCurso", "DtInicio", "IdInstrutor", "Localizacao")] TbCursosOferecidos cursosOferecidos)
        {

            cursosOferecidos.FgAtivo = true;
            _service.Create(cursosOferecidos);
            return RedirectToAction("Index");
        }
    }
}
