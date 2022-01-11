using Cau1.BEL;
using Cau1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BAL
{
    public class DepartmentBAL
    {
        DepartmentDAL dep = new DepartmentDAL();
        public List<DepartmentBEL> ReadDepartmentList()
        {
            List<DepartmentBEL> lstdep = dep.ReadDepartmentList();
            return lstdep;
        }
    }
}
