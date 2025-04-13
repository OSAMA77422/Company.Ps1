using Company.Ps1.BIL.Repositeries;
using Company.Ps1.BIL.Repositry;
using Company.Ps1.DAL.Model;
using Company.Ps1.PL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Company.Ps1.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment1 _repo;

        public DepartmentController(IDepartment1 repo)
        { 
            _repo = repo;
        }
        public IActionResult Index()
        {
          var result =  _repo.getall();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //from client side to server
        public IActionResult Create(DepartmentDTO departmentDTO)
        {
            if (ModelState.IsValid)
            { 
                var department = new Department() 
                { 
                    Code = departmentDTO.Code,
                    Name = departmentDTO.Name,
                    dateTime = departmentDTO.dateTime,
                };
               var x =  _repo.add(department);
                if (x == 1)
                { 
                    return RedirectToAction("Index");
                }
            }
            return View(departmentDTO);
        }

        public IActionResult Details(int id, string ViewName = "Details")
        {
            var result = _repo.Get(id);
            if (result is null)
            {
                return NotFound(new {StatusCode = 404, Message = $"there is not department with this id: {id}" });
            }
            else
            {
                return View(ViewName ,result);
            }
        }

        public IActionResult Edit(int id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id,Department department)
        {
            if (ModelState.IsValid && id == department.Id)
            {
                var count = _repo.update(department);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
                var d = _repo.Get(id);
                return View(d);
        }

        public IActionResult Delete(int id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id, Department department)
        {
            if (ModelState.IsValid && id == department.Id)
            {
                var count = _repo.delete(department);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            var d = _repo.Get(id);
            return View(d);
        }
    }
}
