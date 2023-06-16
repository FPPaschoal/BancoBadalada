using BancoBadalada.Models;
using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoBadalada.Controllers
{
    public class EmpregadoController : Controller
    {

        private readonly IDBContextEmpregado _service;
        private readonly IDBContextHistorico _serviceHistorico;

        public EmpregadoController(IDBContextEmpregado service, IDBContextHistorico serviceHistorico)
        {
            _service = service;
            _serviceHistorico = serviceHistorico;
        }
        public IActionResult Index(int id)
        {
            ViewBag.IdDepartamento = id;
            return View(_service.FindAll(id));
        }

        public IActionResult Criar(int id)
        {
            ViewBag.IdDepartamento = id;
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Criar(EmpregadoHistoricoVM EmpHist)
        {
            EmpHist.Empregado.IdEmpregado = _service.GetNextId();
            EmpHist.Historico.IdEmpregado = EmpHist.Empregado.IdEmpregado;
            EmpHist.Empregado.FgAtivo = true;
            EmpHist.Historico.FgAtivo = true;
            EmpHist.Historico.Salario = EmpHist.Empregado.Salario;
            _service.Create(EmpHist.Empregado);
            _serviceHistorico.Create(EmpHist.Historico);
            return RedirectToAction("Index", new { id = EmpHist.Empregado.IdDepartamento });
        }

    }
}
