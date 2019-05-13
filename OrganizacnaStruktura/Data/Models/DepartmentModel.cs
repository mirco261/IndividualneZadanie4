﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class DepartmentModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public EHierarchy Hierarchy { get; set; }
        public int ParentDepartmentID {get; set; }
        public string ParentDepartmentName { get; set; }
        public int HeadEmployeeID { get; set; }
        public string HeadEmployeeName { get; set; }
    }
}
