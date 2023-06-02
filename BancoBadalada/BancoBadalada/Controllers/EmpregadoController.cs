﻿using BancoBadalada.Models;
using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoBadalada.Controllers
{
    public class EmpregadoController : Controller
    {

        private readonly IDBContextEmpregado _service;

        public EmpregadoController(IDBContextEmpregado service)
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
        public IActionResult Criar([Bind ("NmEmpregado","IniciaisEmpregado", "DsCargo", "DtNascimento", "Salario", "Comissao")] TbEmpregado Empregado)
        {
            Empregado.IdEmpregado = _service.GetNextId();
            Empregado.FgAtivo = true;
            _service.Create(Empregado);
            return RedirectToAction("Index");
        }

    }
}
