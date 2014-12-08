using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using University.DataAccess;
using University.Manager;

namespace University.WebClient.Controllers
{
    public class StudentController : Controller
    {

        StudentManager studentManager = new StudentManager();

        // GET: Student
        public ActionResult Index()
        {
            List<Student> students = studentManager.GetAll();
            return View(students);
        }


        public ActionResult Create()
        {
            DepartmentManager departmentManager = new DepartmentManager();
            ViewBag.Departments = departmentManager.GetAll();

            DevisionManager devisionManager = new DevisionManager();
            ViewBag.Devisions = devisionManager.GetAll();

            //DistrictManager districtManager = new DistrictManager();
            //ViewBag.Districts = districtManager.GetAll();

            //ThanaManager thanaManager = new ThanaManager();
            //ViewBag.Thanas = thanaManager.GetAll();


            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                studentManager.Save(student);

                return RedirectToAction("Index");
            }

            string errorMessage = "";
            foreach (var error in ModelState.Values)
            {
                foreach (ModelError modelError in error.Errors)
                {
                    errorMessage += modelError.ErrorMessage + "\t";
                }
            }
            ViewBag.ErrorMessage = errorMessage;

            ViewBag.Departments = new DepartmentManager().GetAll();
            return View(student);
        }


        public ActionResult Edit(int id)
        {
            var student = studentManager.GetSingleRow(id);

            ViewBag.Id = student.Id;
            ViewBag.Name = student.Name;
            ViewBag.DepartmentId = student.DepartmentId;

            var departmentManager = new DepartmentManager();
            ViewBag.Departments = departmentManager.GetAll();

            List<Department> department = departmentManager.GetSingleRow(Convert.ToInt32(student.DepartmentId));
            foreach (var dept in department)
            {
                ViewBag.Department = dept.Name;
            }


            return View();
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            studentManager.Save(student);

            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var student = studentManager.GetSingleRow(id);

            ViewBag.Id = student.Id;
            ViewBag.Name = student.Name;
            ViewBag.DepartmentId = student.DepartmentId;

            var departmentManager = new DepartmentManager();
            ViewBag.Department = departmentManager.GetSingleRow(ViewBag.DepartmentId);

            return View();
        }


        public ActionResult Delete(int id)
        {
            Student student = studentManager.GetSingleRow(id);

            ViewBag.Id = student.Id;
            ViewBag.Name = student.Name;
            ViewBag.DepartmentId = student.DepartmentId;

            DepartmentManager departmentManager = new DepartmentManager();
            List<Department> singleDepartment = departmentManager.GetSingleRow(ViewBag.DepartmentId);
            foreach (var department in singleDepartment)
            {
                ViewBag.Department = department.Name;    
            }
            


            return View();
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            studentManager.Delete(student);


            return RedirectToAction("Index");
        }



        [HttpGet]
        public string GetAllDistrictByDivision(string division)
        {
            //return "Parameter: " + p + " Date: " + DateTime.Now.ToString();

            DistrictManager districtManager = new DistrictManager();
            List<District> districts = districtManager.GetAllByDivision(Convert.ToInt16(division));

            string districsJson = JsonConvert.SerializeObject(districts);
            return districsJson;
        }


        [HttpGet]
        public string GetAllThanaByDistrict(string district)
        {
            ThanaManager thanaManager = new ThanaManager();
            List<Thana> thanas = thanaManager.GetAllByDistrict(Convert.ToInt16(district));

            string thanasJson = JsonConvert.SerializeObject(thanas);
            return thanasJson;
        }



    }

}