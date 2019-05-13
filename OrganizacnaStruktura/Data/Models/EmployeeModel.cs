using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string FullName
        {
            get { return $"{Lastname} {FirstName} {Title}";}
        }
    }
}
