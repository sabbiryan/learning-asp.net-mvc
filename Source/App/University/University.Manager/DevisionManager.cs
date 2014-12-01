using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess;

namespace University.Manager
{
    public class DevisionManager
    {
        public List<Devision> GetAll()
        {
            using (var db = new UniversityDBEntities())
            {
                return db.Devisions.ToList();
            }
        } 
    }
}
