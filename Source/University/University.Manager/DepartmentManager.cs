using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess;

namespace University.Manager
{
    public class DepartmentManager
    {
        public List<Department> GetAll()
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                return db.Departments.ToList();
            }
        }

        public bool Save(Department department)
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return true;
            }
        }

        public List<Department> GetSingleRow(int id)
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                return new List<Department>(db.Departments.Where(dept => dept.Id == id));
            }
        }

        public bool Update(Department department)
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                db.Departments.AddOrUpdate(department);
                db.SaveChanges();
                return true;
            }
        }

        public bool Delete(Department department)
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                //db.Departments.Remove(department);

                db.Entry(department).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
        }
    }
}
