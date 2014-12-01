using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.DataAccess;
using University.Manager;

namespace University.WebClient.Controllers
{
    public class CourseController : Controller
    {
        CourseManager courseManager = new CourseManager();


        // GET: Course
        public ActionResult Index()
        {            
            List<Course> courses = courseManager.GetAll();

            return View(courses);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            courseManager.Save(course);
            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {
            Course course = courseManager.GetSingleRow(id);

            ViewBag.Id = course.Id;
            ViewBag.Name = course.Name;
            ViewBag.Credit = course.Credit;

            return View();
        }


        [HttpPost]
        public ActionResult Edit(Course course)
        {
            courseManager.Save(course);

            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var course = courseManager.GetSingleRow(id);
            
            ViewBag.Id = course.Id;
            ViewBag.Name = course.Name;
            ViewBag.Credit = course.Credit;

            return View();
        }


        public ActionResult Delete(int id)
        {
            var course = courseManager.GetSingleRow(id);

            ViewBag.Id = course.Id;
            ViewBag.Name = course.Name;
            ViewBag.Credit = course.Credit;

            return View();
        }

        [HttpPost]
        public ActionResult Delete(Course course)
        {
            courseManager.Delete(course);

            return RedirectToAction("Index");
        }
    }
}