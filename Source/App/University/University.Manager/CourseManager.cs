using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess;

namespace University.Manager
{
    public class CourseManager
    {
        public List<Course> GetAll()
        {
            using (var db = new UniversityDBEntities())
            {
                return db.Courses.ToList();
            }
        }


        public bool Save(Course course)
        {
            using (var db = new UniversityDBEntities())
            {
                db.Courses.AddOrUpdate(course);
                db.SaveChanges();
                return true;
            }
        }


        public Course GetSingleRow(int id)
        {
            using (var db = new UniversityDBEntities())
            {
                Course course = db.Courses.Find(id);

                return course;
            }
        }

        public bool Delete(Course course)
        {
            using (var db = new UniversityDBEntities())
            {
                db.Entry(course).State = EntityState.Deleted;
                db.SaveChanges();

                return true;
            }
        }
    }
}
