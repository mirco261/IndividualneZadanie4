using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.Repositories;

namespace Logika
{
    public class EmployeesLogic
    {
        EmployeeRepository _employeesLogic = new EmployeeRepository();

        public List<EmployeeModel> GetEmployees()
        {
            return _employeesLogic.SelectEmployees();
        }

        public bool InsertEmployee(EmployeeModel employee)
        {
            return _employeesLogic.InsertEmployee(employee);
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            return _employeesLogic.UpdateEmployee(employee);
        }

        public bool DeleteEmployee(int employeeId)
        {
            return _employeesLogic.DeleteEmployee(employeeId);
        }
    }
}
