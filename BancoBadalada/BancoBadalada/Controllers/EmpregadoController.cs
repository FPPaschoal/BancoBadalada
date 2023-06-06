using BancoBadalada.Models;
using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoBadalada.Controllers
{
    public class EmpregadoController : Controller
    {

        private readonly IDBContextEmpregado _service;
        private readonly IDBContextHistorico _serviceHistorico;
            
        int Aux;

        public EmpregadoController(IDBContextEmpregado service, IDBContextHistorico serviceHistorico)
        {
            _service = service;
            _serviceHistorico = serviceHistorico;
        }
        public IActionResult Index(int id)
        {
            Aux = id;
            return View(_service.FindAll(id));
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Criar([Bind ("Empregado.NmEmpregado", "Empregado.IniciaisEmpregado", "Empregado.DsCargo", "Empregado.DtNascimento", "Empregado.Salario", "Empregado.Comissao", "Historico.DtInicio", "Historico.AnoInicio", "Historico.DtFinal", "Historico.Comentarios")] EmpregadoHistoricoVM EmpHist)
        {
            EmpHist.Empregado.IdEmpregado = _service.GetNextId();
            EmpHist.Historico.IdEmpregado = EmpHist.Empregado.IdEmpregado;
            EmpHist.Empregado.FgAtivo = true;
            EmpHist.Historico.FgAtivo = true;
            EmpHist.Empregado.IdDepartamento = Aux;
            EmpHist.Historico.IdDepartamento = Aux;
            EmpHist.Historico.Salario = EmpHist.Empregado.Salario;
            _service.Create(EmpHist.Empregado);
            _serviceHistorico.Create(EmpHist.Historico);
            return RedirectToAction("Index");
        }

    }
}
