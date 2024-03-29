﻿using BancoBadalada.Models;
using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoBadalada.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDBContextDepartamento _service;
        private readonly IDBContextEmpregado _empregado;

        public DepartamentoController(IDBContextDepartamento service, IDBContextEmpregado empregado)
        {
            _service = service;
            _empregado = empregado;
        }

        public IActionResult Index()
        {
            return View(_service.FindAll());
        }
        public IActionResult Criar()
        {
            ViewBag.Empregados = _empregado.FindAll();
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

        [HttpPost]
        public IActionResult GetDepartamentos()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sort = Request.Form["sort"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var departamentos = _service.FindAll();
                if (!string.IsNullOrEmpty(searchValue))
                {
                    departamentos = departamentos.Where(c => c.NmDepartamento.Contains(searchValue)).ToList();
                }
                recordsTotal = departamentos.Count();
                var data = departamentos.Skip(skip).Take(pageSize).Select(c => new
                {
                    idDepartamento = c.IdDepartamento,
                    nmDepartamento = c.NmDepartamento,
                    idGerente = c.IdGerente,
                    localizacao = c.Localizacao,
                    ativo = c.FgAtivo
                }).ToList();

                var jsonData = new
                {
                    draw = draw,
                    recordsFiltered = recordsTotal,
                    recordsTotal = recordsTotal,
                    data = data
                };
                return Json(jsonData);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
