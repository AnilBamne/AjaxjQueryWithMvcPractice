using AjaxjQueryWithMvcPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxjQueryWithMvcPractice.Controllers
{
    public class EmployeeController : Controller
    {
        private EmpRepo empRepo;
        public EmployeeController(EmpRepo empRepo) {
            this.empRepo = empRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public IActionResult Add()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Add(Employee employee)
        //{
        //    var result=empRepo.Add(employee);
        //    return RedirectToAction("GetAll");
        //}
        //public IActionResult GetAll()
        //{
        //    var result=empRepo.GetList();
        //    return View(result);
        //}

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Employee employee)
        {
            var result = empRepo.AddEmp(employee);
            return View(result);
        }
    }
}
