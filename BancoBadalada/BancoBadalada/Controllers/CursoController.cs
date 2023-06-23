using BancoBadalada.Models;
using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BancoBadalada.Controllers
{
    public class CursoController : Controller
    {
        private readonly IDBContextCurso _service;

        public CursoController(IDBContextCurso service)
        {
            _service = service;
        }
        public IActionResult index()
        {
            return View(_service.FindAll());
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Criar([Bind("IdCurso", "DsCurso", "Categoria", "Duracao")] TbCurso Curso)
        {
            if (Char.IsDigit(Curso.DsCurso[0]))
            {
                ModelState.AddModelError("NmDepartamento", "Nome não pode iniciar com dígito");
                return View(Curso);
            }
            Curso.FgAtivo = true;
            _service.Create(Curso);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remover(string id)
        {
            TbCurso curso = _service.Find(new TbCurso { IdCurso = id });
            return View(curso);
        }


        [HttpPost]
        public IActionResult Remover(TbCurso curso)
        {
            try
            {
                _service.Delete(curso);
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {

                ViewBag.ErrorMessage = "Impossivel excluir o curso enquanto ele esta sendo oferecido. Remova o curso dos cursos oferecidos";
                return View(curso); // Retorna a mesma página com uma mensagem de erro
            }

        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
            TbCurso curso = _service.Find(new TbCurso { IdCurso = id });
            return View(curso);
        }

        [HttpPost]
        public IActionResult Editar(TbCurso curso)
        {
            _service.Update(curso);
            return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult GetCursos()
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
                var cursos = _service.FindAll();
                if (!string.IsNullOrEmpty(searchValue))
                {
                    cursos = cursos.Where(c => c.DsCurso.Contains(searchValue)).ToList();
                }
                recordsTotal = cursos.Count();
                var data = cursos.Skip(skip).Take(pageSize).Select(c => new
                {
                    idCurso = c.IdCurso,
                    dsCurso = c.DsCurso,
                    categoria = c.Categoria,
                    duracao = c.Duracao,
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
