using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.DataAccess;
using University.Manager;

namespace University.WebClient.Controllers
{
    public class EnrollmentController : Controller
    {
        EnrollmentManager enrollmentManager = new EnrollmentManager();

        // GET: Enrollment
        public ActionResult Index()
        {            

            List<Enrollment> enrollments = enrollmentManager.GetAll();

            return View(enrollments);
        }


        public ActionResult Create()
        {
            StudentManager studentManager = new StudentManager();
            List<Student> students = studentManager.GetAll();
            ViewBag.Students = students;

            CourseManager courseManager = new CourseManager();
            List<Course> courses = courseManager.GetAll();
            ViewBag.Courses = courses;


            return View();
        }


        [HttpPost]
        public ActionResult Create(Enrollment enrollment)
        {
            enrollmentManager.Save(enrollment);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            Enrollment enrollment = enrollmentManager.GetSingleRow(id);
            ViewBag.Id = enrollment.Id;
            ViewBag.StudentId = enrollment.StudentId;
            ViewBag.CourseId = enrollment.CourseId;
            ViewBag.Date = enrollment.Date;

            StudentManager studentManager = new StudentManager();
            ViewBag.Students = studentManager.GetAll();
            Student student = studentManager.GetSingleRow(enrollment.StudentId);
            ViewBag.Student = student.Name;

            CourseManager courseManager = new CourseManager();
            ViewBag.Courses = courseManager.GetAll();
            Course course = courseManager.GetSingleRow(enrollment.CourseId);
            ViewBag.Course = course.Name;

            return View();
        }


        [HttpPost]
        public ActionResult Edit(Enrollment enrollment)
        {
            enrollmentManager.Save(enrollment);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            Enrollment enrollment = enrollmentManager.GetSingleRow(id);
            ViewBag.Id = enrollment.Id;
            ViewBag.StudentId = enrollment.StudentId;
            ViewBag.CourseId = enrollment.CourseId;
            ViewBag.Date = enrollment.Date;

            StudentManager studentManager = new StudentManager();
            Student student = studentManager.GetSingleRow(enrollment.StudentId);
            ViewBag.Student = student.Name;

            CourseManager courseManager = new CourseManager();
            Course course = courseManager.GetSingleRow(enrollment.CourseId);
            ViewBag.Course = course.Name;

            return View();
        }


        public ActionResult Delete(int id)
        {
            Enrollment enrollment = enrollmentManager.GetSingleRow(id);
            ViewBag.Id = enrollment.Id;
            ViewBag.StudentId = enrollment.StudentId;
            ViewBag.CourseId = enrollment.CourseId;
            ViewBag.Date = enrollment.Date;

            StudentManager studentManager = new StudentManager();
            Student student = studentManager.GetSingleRow(enrollment.StudentId);
            ViewBag.Student = student.Name;

            CourseManager courseManager = new CourseManager();
            Course course = courseManager.GetSingleRow(enrollment.CourseId);
            ViewBag.Course = course.Name;

            return View();
        }

        [HttpPost]
        public ActionResult Delete(Enrollment enrollment)
        {
            enrollmentManager.Delete(enrollment);

            return RedirectToAction("Index");
        }
    }
}