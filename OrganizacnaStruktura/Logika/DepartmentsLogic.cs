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
        public List<DepartmentModel> GetDepartments()
        {
            return _departmentRepository.SelectDepartments();
        }

        public List<DepartmentModel> GetParentsDepartments(EHierarchy eHierarchy)
        {
            List<DepartmentModel> departments = _departmentRepository.SelectDepartments();
            return departments.Where(dep => (int)dep.Hierarchy == (int)eHierarchy - 1).ToList();
        }

        

        public bool InsertDepartment(DepartmentModel department)
        {
            return _departmentRepository.InsertDepartment(department);
        }

        public bool UpdateDepartment(DepartmentModel department)
        {
            return _departmentRepository.UpdateDepartment(department);
        }
    }
}
