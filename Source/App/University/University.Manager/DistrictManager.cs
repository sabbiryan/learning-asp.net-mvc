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
        //public List<District> GetAll()
        //{
        //    using (var db = new UniversityDBEntities())
        //    {
        //        return db.Districts.ToList();
        //    }
        //}

        public List<District> GetAllByDivision(int divisionId)
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;
                return db.Districts.Where(x => x.DivisionId == divisionId).ToList();
            }
        }
    }
}
