using BancoBadalada.Models;
using BancoBadalada.Services;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Criar([Bind("IdCurso","DsCurso", "Categoria", "Duracao")] TbCurso Curso)
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
    }
}
