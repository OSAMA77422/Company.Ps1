using Company.Ps1.BIL.Repositeries;
using Company.Ps1.BIL.Repositry;
using Company.Ps1.DAL.Model;
using Company.Ps1.PL.DTO;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Details(int id)
        {
            var result = _repo.Get(id);
            return View(result);
        }
    }
}
