using BancoBadalada.Models;
using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoBadalada.Controllers
{
    public class HistoricoController : Controller
    {

        private readonly IDBContextHistorico _service;
        private readonly IDBContextEmpregado _serviceEmpregado;

        public HistoricoController(IDBContextHistorico service, IDBContextEmpregado serviceEmpregado)
        {
            _service = service;
            _serviceEmpregado = serviceEmpregado;
        }
        public IActionResult Index()
        {
            return View(_serviceEmpregado.FindAll());
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Exibir(int idEmpregado)
        {
            var historicos = _service.FindAllEmp(idEmpregado);
            return PartialView("_HistoricoPartial", historicos);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Criar([Bind ("NmEmpregado","IniciaisEmpregado", "DsCargo", "DtNascimento", "Salario", "Comissao")] TbEmpregado Empregado)
        {
            Empregado.IdEmpregado = _serviceEmpregado.GetNextId();
            Empregado.FgAtivo = true;
            _serviceEmpregado.Create(Empregado);
            return RedirectToAction("Index");
        }

    }
}
