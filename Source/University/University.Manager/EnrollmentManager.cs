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
    public class EnrollmentManager
    {

        public List<Enrollment> GetAll()
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                return db.Enrollments.Include(x => x.Course).Include(x => x.Student).ToList();
            }
        }

        public bool Save(Enrollment enrollment)
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                db.Enrollments.AddOrUpdate(enrollment);
                db.SaveChanges();
                return true;
            }
        }

        public Enrollment GetSingleRow(int id)
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                return db.Enrollments.Find(id);
            }
        }

        public bool Delete(Enrollment enrollment)
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                db.Entry(enrollment).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
        }
    }
}
