using Company.Ps1.BIL.Repositeries;
using Company.Ps1.BIL.Repositry;
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
    }
}
