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
        public List<DepartmentModel> GetDepartments()
        {
            return _departmentRepository.SelectDepartments();
        }

        /// <summary>
        /// Return only departments, that can be parents of this hierarchy
        /// </summary>
        public List<DepartmentModel> GetParentsDepartments(EHierarchy eHierarchy)
        {
            List<DepartmentModel> departmentsList = _departmentRepository.SelectDepartments();
            return departmentsList.Where(dep => (int)dep.Hierarchy == (int)eHierarchy - 1).ToList();
        }

        /// <summary>
        /// return list, where is only deparments, that are in this eHierarchy
        /// </summary>
        public List<DepartmentModel> GetNamesOfHierarchy(List<DepartmentModel> list, EHierarchy eHierarchy)
        {
            return list.Where(filter => filter.Hierarchy == eHierarchy).ToList();
        }

        public bool InsertDepartment(DepartmentModel department)
        {
            return _departmentRepository.InsertDepartment(department);
        }

        public bool UpdateDepartment(DepartmentModel department)
        {
            return _departmentRepository.UpdateDepartment(department);
        }

        public int DeleteDepartment(DepartmentModel department)
        {
            return _departmentRepository.DeleteDepartment(department);
        }

        public List<string> UserExistInDepartment(int idUser)
        {
            return _departmentRepository.UserExistInDepartment(idUser);
        }

        /// <summary>
        /// Return message, where is why is not possible delete user
        /// </summary>
        public string GetDepartmentsOfHeadEmployee(List<string> departments)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Zamestnanca nie je možné vymazať, pretože sa nachádza \nako nadriadenýpracovník v nasledovných oddeleniach:\n");

            foreach (var dep in departments)
            {
                sb.Append($"\n - {dep}");
            }
            sb.Append("\n\nVyberte si v týchto oddeleniach iného vedúceho zamestnanca.");
            return sb.ToString();
        }
    }
}
