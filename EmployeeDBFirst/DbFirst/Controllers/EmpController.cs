using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpModels;
using EmpDb.EmployeeRepository;
using EmpDb;

namespace DbFirst.Controllers
{
    public class EmpController : Controller
    {
        EmployeeRepository employeeRepository = null;
        EmployeeDBEntities context = null;
        public EmpController()
        {
            employeeRepository = new EmployeeRepository();
            context = new EmployeeDBEntities();
            
        }
        // GET: Emp

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmployeeIndex()
         {
             var data = employeeRepository.GetEmployees();
             return View(data);
         }
        public ActionResult ProjectIndex()
         {
             var data = employeeRepository.GetProjects();
             return View(data);
         }
        public ActionResult DepartmentIndex()
         {
             var data = employeeRepository.GetDepartments();
             return View(data);
         }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(EmployeeProjectMappingModel employeeProjectMappingModel)
        {
            if (ModelState.IsValid)
            {
                int id = employeeRepository.AddEmployee(employeeProjectMappingModel);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Data added Successfully !";
                }
            }
            return View();
        }

        public ActionResult Query()
        {
            return View();
        }
        public ActionResult EmployeeDOJ()
        {
            var data = employeeRepository.GetEmployeesDOJ();
            return View(data);
        }
        public ActionResult EmployeeHR()
        {
            var data = employeeRepository.GetEmployeesHR();
            return View(data);
        }
        public ActionResult EmployeeAccordingProject()
        {
            var data = employeeRepository.GetEmployeeAccordingProjectName("ABC");
            return View(data);
        }
        public ActionResult DepartmentAccordingProject()
        {
            var data = employeeRepository.GetDepartmentNameAccordingProjectName("ABC");
            return View(data);
        }
    }
}