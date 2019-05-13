using Data.Models;
using Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizacnaStruktura
{
    public partial class frmDepartment : Form
    {
        DepartmentsLogic _departmentsLogic = new DepartmentsLogic();
        private Department _department;


        public frmDepartment(EFrmType eFrmType, Department department)
        {
            InitializeComponent();
            cmbHierarchy.DataSource = Enum.GetValues(typeof(EHierarchy));
            _department = department;


            switch (eFrmType)
            {
                case EFrmType.add:
                    Text = "Pridanie nového oddelenia";
                    lblNameOfFrm.Text = "Pridanie nového oddelenia";
                    btnSaveExist.Visible = false;
                    break;

                case EFrmType.edit:
                    Text = "Editácia existujúceho oddelenia";
                    lblNameOfFrm.Text = "Editácia existujúceho oddelenia";
                    btnSaveNew.Visible = false;
                    FillFormFromDepartment(department);
                    break;
                default:
                    break;
            }
        }



        private void btnSaveExist_Click(object sender, EventArgs e)
        {
            Department department = LoadDeparmentFromFrm();
            _departmentsLogic.UpdateDepartment(department);
            Close();
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            Department department = LoadDeparmentFromFrm();
            _departmentsLogic.InsertDepartment(department);
            Close();
        }

        /// <summary>
        /// Load users added information about department from frm
        /// </summary>
        /// <returns>department model</returns>
        private Department LoadDeparmentFromFrm()
        {
            Department department = new Department();
            department.Code = txbDepartmentCode.Text;
            department.Name = txbDepartmentName.Text;
            department.Hierarchy = (EHierarchy)cmbHierarchy.SelectedValue;
            Department dep = (Department)(cmbParentDeparment.SelectedItem);
            department.ParentDepartment = dep.ID;
            department.ID = _department.ID;
            //department.HeadEmployeeID = int.Parse(cmbHeadEmployee.SelectedItem);
            return department;
        }

        /// <summary>
        /// Fill boxes with information about department
        /// </summary>
        /// <param name="department">department from previous frm</param>
        private void FillFormFromDepartment(Department department)
        {
            txbDepartmentCode.Text = department.Code;
            txbDepartmentName.Text = department.Name;
            cmbHeadEmployee.Text = department.HeadEmployeeID.ToString();
            cmbParentDeparment.Text = department.ParentDepartment.ToString();
            cmbHierarchy.Text = department.Hierarchy.ToString();
        }


        private void cmbHierarchy_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Department> departments = _departmentsLogic.GetDepartments();
            int hierarchy = (int)cmbHierarchy.SelectedValue;
            //insert only departments, where hierarchy is one level above
            cmbParentDeparment.DataSource = departments.Where(dep => (int)dep.Hierarchy == hierarchy-1).ToList();
            cmbParentDeparment.ValueMember = "Name";
        }
    }
}
