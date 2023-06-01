using BancoBadalada.Models;
using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoBadalada.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDBContextDepartamento _service;

        public DepartamentoController(IDBContextDepartamento service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.FindAll());
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Criar([Bind("NmDepartamento", "IdGerente", "Localizacao")] TbDepartamento departamento)
        {


            if (Char.IsDigit(departamento.NmDepartamento[0]))
            {
                ModelState.AddModelError("NmDepartamento", "Nome não pode iniciar com dígito");
                return View(departamento);
            }

            var auxId = _service.GetNextId();
            departamento.IdDepartamento = auxId;
            departamento.FgAtivo = true;
            _service.Create(departamento);
            return RedirectToAction("Index");
        }
    }
}
