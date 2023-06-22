using BancoBadalada.Models;
using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoBadalada.Controllers
{
    public class CursosOferecidosController : Controller
    {
        private readonly IDBContextCursosOferecidos _service;
        private readonly IDBContextEmpregado _serviceEmpregados;

        public CursosOferecidosController(IDBContextCursosOferecidos service, IDBContextEmpregado serviceEmpregados)
        {
            _service = service;
            _serviceEmpregados = serviceEmpregados;
        }
        public IActionResult Index()
        {
            return View(_service.FindAll());
        }
        public IActionResult Oferecer(string id) 
        {
            var Aux = new TbCursosOferecidos();
            Aux.IdCurso = id;
            ViewBag.Empregados = _serviceEmpregados.FindAll();
            return View(Aux);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Oferecer([Bind("IdCurso", "DtInicio", "IdInstrutor", "Localizacao")] TbCursosOferecidos cursosOferecidos)
        {

            cursosOferecidos.FgAtivo = true;
            cursosOferecidos.Localizacao = cursosOferecidos.Localizacao.ToUpper();
            _service.Create(cursosOferecidos);
            return RedirectToAction("Index");
        }
    }
}
