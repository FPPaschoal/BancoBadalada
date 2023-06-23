using System.Runtime.InteropServices.JavaScript;
using BancoBadalada.Models;
using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Oferecer(
            [Bind("IdCurso", "DtInicio", "IdInstrutor", "Localizacao")] TbCursosOferecidos cursosOferecidos)
        {
            cursosOferecidos.FgAtivo = true;
            cursosOferecidos.Localizacao = cursosOferecidos.Localizacao.ToUpper();
            _service.Create(cursosOferecidos);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(string id, string dtInicio)
        {
            DateTime data = DateTime.Parse(dtInicio);
            TbCursosOferecidos curso = _service.Find(new TbCursosOferecidos() { IdCurso = id, DtInicio = data });
            ViewBag.Empregados = _serviceEmpregados.FindAll();
            return View(curso);
        }

        [HttpPost]
        public IActionResult Editar(TbCursosOferecidos curso, string id, string dtVelha)
        {
            if (curso.DtInicio == DateTime.Parse("01-01-0001"))
            {
                curso.DtInicio = DateTime.Parse(dtVelha);
            }
            DateTime data = DateTime.Parse(dtVelha);
            TbCursosOferecidos cursoVelho = _service.Find(new TbCursosOferecidos { IdCurso = id, DtInicio = data });
            _service.Delete(cursoVelho);
            _service.Create(curso);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remover(string id, string dtInicio)
        {
            DateTime data = DateTime.Parse(dtInicio);
            TbCursosOferecidos curso = _service.Find(new TbCursosOferecidos() { IdCurso = id, DtInicio = data });
            return View(curso);
        }


        [HttpPost]
        public IActionResult Remover(TbCursosOferecidos curso)
        {
            _service.Delete(curso);
            return RedirectToAction("Index");
        }
    }
}