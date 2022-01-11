using Cau1.BEL;
using Cau1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BAL
{
    public class EmployeeBAL
    {
        EmployeeDAL employee = new EmployeeDAL();
        public List<EmployeeBEL> ReadEmployee()
        {
            List<EmployeeBEL> lstCus = employee.ReadEmployee();
            return lstCus;
        }
        public void NewEmployee(EmployeeBEL emp)
        {
            employee.NewEmployee(emp);
        }
        public void DeleteEmployee(EmployeeBEL emp)
        {
            employee.DeleteEmployee(emp);
        }
        public void EditEmployee(EmployeeBEL emp)
        {
            employee.EditEmployee(emp);
        }
    }
}
