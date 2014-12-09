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
    public class StudentManager
    {
        public List<Student> GetAll()
        {
            using (var db = new UniversityDBEntities())
            {
                return db.Students.
                    Include(dept => dept.Department).
                    Include(div =>div.Devision).
                    Include(dist => dist.District).
                    Include(thana => thana.Thana).
                    ToList();
            }
        }


        public bool Save(Student student)
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                db.Students.AddOrUpdate(student);
                db.SaveChanges();
                return true;
            }
        }


        public Student GetSingleRow(int id)
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                return db.Students.Single(std => std.Id == id);
            }
        }

        public bool Delete(Student student)
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                db.Entry(student).State = EntityState.Deleted;
                db.SaveChanges();

                return true;
            }
        }
    }
}
