using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess;

namespace University.Manager
{
    public class ThanaManager
    {
        //public List<Thana> GetAll()
        //{
        //    using (var db = new UniversityDBEntities())
        //    {
        //        return db.Thanas.ToList();
        //    }
        //}

        public List<Thana> GetAllByDistrict(int district)
        {
            using (UniversityDBEntities db = new UniversityDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;
                return db.Thanas.Where(x => x.DistrictId == district).ToList();
            }
        }
    }
}
