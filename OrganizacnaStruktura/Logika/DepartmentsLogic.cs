using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Data.Models;


namespace Logika
{
    public class DepartmentsLogic
    {
        private DepartmentRepository _departmentRepository = new DepartmentRepository();

        /// <summary>
        /// Return list of departments from db
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartments()
        {
            return _departmentRepository.SelectDepartments();
        }

        public bool InsertDepartment(Department department)
        {
            return _departmentRepository.InsertDepartment(department);
        }

        public bool UpdateDepartment(Department department)
        {
            return _departmentRepository.UpdateDepartment(department);
        }
    }
}
