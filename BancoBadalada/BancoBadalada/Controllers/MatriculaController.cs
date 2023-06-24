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
        public IActionResult Index(int id,string? dtCurso, string? idCurso)
        {
            ViewBag.Nomes = _serviceEmpregado.FindAll();
            if (dtCurso == null)
            {
            return View(_service.FindAll(id));
            }
            return View(_service.GetAlunos(idCurso, dtCurso));
        }
        public IActionResult GetAlunos(string idCurso, string dtCurso)
        {
            return RedirectToAction("Index", new { idCurso = idCurso, dtCurso  = dtCurso, id = 0});
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


        [HttpGet]
        public IActionResult Remover(string idCurso, string dtCurso, int idParticipante)
        {
            DateTime data = DateTime.Parse(dtCurso);
            TbMatricula matricula = _service.Find(new TbMatricula { IdCurso = idCurso, DtInicio = data, IdParticipante = idParticipante });
            return View(matricula);
        }

        [HttpPost]
        public IActionResult Remover(TbMatricula matricula)
        {
            _service.Delete(matricula);
            return RedirectToAction("Index", new TbMatricula { DtInicio = matricula.DtInicio, IdCurso = matricula.IdCurso });
        }

        [HttpGet]
        public IActionResult Editar(string idCurso, string dtCurso, int idParticipante)
        {
            DateTime data = DateTime.Parse(dtCurso);
            TbMatricula matricula = _service.Find(new TbMatricula { IdCurso = idCurso, DtInicio = data, IdParticipante = idParticipante });
            return View(matricula);
        }

        [HttpPost]
        public IActionResult Editar(TbMatricula matricula)
        {
            _service.Update(matricula);
            return RedirectToAction("Index", new TbMatricula { DtInicio = matricula.DtInicio, IdCurso = matricula.IdCurso });
        }

    }
}
