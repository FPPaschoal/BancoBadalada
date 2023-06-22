using BancoBadalada.Models;
using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Globalization;

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

        public IActionResult Matricular(string idCurso,string dtInicio)
        {
            DateTime dt = DateTime.Parse(dtInicio);
            ViewBag.Empregados = _serviceEmpregado.FindAll();
            return View(new TbMatricula { DtInicio = dt, IdCurso = idCurso });
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Matricular([Bind("IdParticipante", "IdCurso", "DtInicio")]TbMatricula matricula)
        {
            matricula.FgAtivo = true;
            _service.Create(matricula);
            return RedirectToAction("Index", new { id = matricula.IdParticipante });
        }
    }
}
