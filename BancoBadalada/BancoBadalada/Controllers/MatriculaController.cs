using BancoBadalada.Models;
using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoBadalada.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly IDBContextMatricula _service;
        private readonly IDBContextEmpregado _serviceEmpregado;

        public MatriculaController(IDBContextMatricula service, IDBContextEmpregado serviceEmpregado)
        {
            _service = service;
            _serviceEmpregado = serviceEmpregado;
        }
        public IActionResult Index(int id)
        {
            return View(_service.FindAll(id));
        }

        public IActionResult Matricular(string idCurso,DateTime dtInicio)
        {
            ViewBag.idCurso = idCurso;
            ViewBag.dtInicio = dtInicio;
            return View(_serviceEmpregado.FindAll());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Matricular([Bind("idParticipante", "idCurso", "dtInicio")]TbMatricula matricula)
        {
            matricula.FgAtivo = true;
            _service.Create(matricula);
            return RedirectToAction("Index");
        }
    }
}
