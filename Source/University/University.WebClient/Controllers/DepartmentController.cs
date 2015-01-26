using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.DataAccess;
using University.Manager;

namespace University.WebClient.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            var departmentManager = new DepartmentManager();

            List<Department> departments = departmentManager.GetAll();

            return View(departments);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            var departmentManager = new DepartmentManager();
            departmentManager.Save(department);            

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {
            var departmentManager = new DepartmentManager();
            ViewBag.Row = departmentManager.GetSingleRow(id);

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            var departmentManager = new DepartmentManager();
            departmentManager.Update(department);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var departmentManager = new DepartmentManager();
            ViewBag.DeleteRow = departmentManager.GetSingleRow(id);            

            return View();
        }


        [HttpPost]
        public ActionResult Delete(Department department)
        {    
            var departmentManager = new DepartmentManager();
            departmentManager.Delete(department);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var departmentManager = new DepartmentManager();
            ViewBag.Details = departmentManager.GetSingleRow(id);

            return View();
        }
    }
}