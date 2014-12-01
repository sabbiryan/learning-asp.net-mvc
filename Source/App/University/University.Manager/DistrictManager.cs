using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess;

namespace University.Manager
{
    public class DistrictManager
    {
        public List<District> GetAll()
        {
            using (var db = new UniversityDBEntities())
            {
                return db.Districts.ToList();
            }
        }

        //public List<District> GetDistrictsByDivision(int id)
        //{
        //    using (UniversityDBEntities db = new UniversityDBEntities())
        //    {
        //        return new List<District>(db.Districts.Where(x => x.Id == id)).ToList();
        //    }
        //}
    }
}
