using Microsoft.AspNetCore.Mvc;
using MvcCrudDept.Models;
using MvcCrudDept.Repositories;

namespace MvcCrudDept.Controllers
{
    public class DepartamentosController : Controller
    {
        RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return View(departamentos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Departamento dept)
        {
            this.repo.InsertDepartamento(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int iddepartamento)
        {
            Departamento dept = this.repo.FindDepartamento(iddepartamento);
            return View(dept);
        }
        [HttpPost]
        public IActionResult Edit(Departamento dept)
        {
            this.repo.UpdateDepartamento(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int iddepartamento)
        {
            this.repo.DeleteDepartamento(iddepartamento);
            return RedirectToAction("Index");
        }
    }
}
