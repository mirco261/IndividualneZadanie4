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
        private DepartmentModel _department;

        public frmDepartment(EFrmAction eFrmType, DepartmentModel department)
        {
            InitializeComponent();
            cmbHierarchy.DataSource = Enum.GetValues(typeof(EHierarchy));
            _department = department;

            EmployeesLogic employeesLogic = new EmployeesLogic();
            cmbHeadEmployee.DataSource = employeesLogic.GetEmployees();
            cmbHeadEmployee.DisplayMember = "FullName";
            cmbHeadEmployee.ValueMember = "ID";

            switch (eFrmType)
            {
                case EFrmAction.add:
                    Text = "Pridanie nového oddelenia";
                    lblNameOfFrm.Text = "Pridanie nového oddelenia";
                    btnSaveExist.Visible = false;
                    break;

                case EFrmAction.edit:
                    Text = "Editácia existujúceho oddelenia";
                    lblNameOfFrm.Text = "Editácia existujúceho oddelenia";
                    btnSaveNew.Visible = false;
                    FillFormFromDepartment(_department);
                    break;
            }
        }

        #region FRM Actions
        private void btnSaveExist_Click(object sender, EventArgs e)
        {
            DepartmentModel department = LoadDeparmentFromFrm();
            if (CheckIfCanSave(department))
            {
                department.ID = _department.ID;
                _departmentsLogic.UpdateDepartment(department);
                Close();
            }
            else
            {
                MessageBox.Show("Nie je možné uložiť oddelenie, pokiaľ nemá nadriadené oddelenie");
            };
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            DepartmentModel department = LoadDeparmentFromFrm();
            if (CheckIfCanSave(department))
            {
                _departmentsLogic.InsertDepartment(department);
                Close();
            }
            else
            {
                MessageBox.Show("Nie je možné uložiť oddelenie, pokiaľ nemá nadriadené oddelenie");
            };
        }

        private bool CheckIfCanSave(DepartmentModel department)
        {
            return department.Hierarchy == EHierarchy.Firma || department.ParentDepartmentID != 0;
        }
        #endregion

        #region Methods


        /// <summary>
        /// Load users added information about department from frm
        /// </summary>
        /// <returns>department model</returns>
        private DepartmentModel LoadDeparmentFromFrm()
        {
            DepartmentModel department = new DepartmentModel();
            department.Code = txbDepartmentCode.Text;
            department.Name = txbDepartmentName.Text;
            department.Hierarchy = (EHierarchy)cmbHierarchy.SelectedValue;
            DepartmentModel dep = (DepartmentModel)(cmbParentDeparment.SelectedItem);
            if (dep != null)
            {
                department.ParentDepartmentID = dep.ID;
            }
            EmployeeModel employee = (EmployeeModel)cmbHeadEmployee.SelectedItem;
            if (employee != null)
            {
                department.HeadEmployeeID = employee.ID;
            }

            return department;
        }

        /// <summary>
        /// Fill boxes with information about department
        /// </summary>
        /// <param name="department">department from previous frm</param>
        private void FillFormFromDepartment(DepartmentModel department)
        {
            txbDepartmentCode.Text = department.Code;
            txbDepartmentName.Text = department.Name;
            cmbHeadEmployee.Text = department.HeadEmployeeID.ToString();
            cmbHierarchy.Text = department.Hierarchy.ToString();
            cmbParentDeparment.Text = department.ParentDepartmentName;
            cmbHeadEmployee.SelectedValue = department.HeadEmployeeID;
        }

        private void cmbHierarchy_SelectedIndexChanged(object sender, EventArgs e)
        {
            EHierarchy hierarchy = (EHierarchy)cmbHierarchy.SelectedValue;

            //Company does not have parent
            if (hierarchy == EHierarchy.Firma)
            {
                cmbParentDeparment.Visible = false;
                lblParentDepartment.Visible = false;
            }
            else
            {
                cmbParentDeparment.Visible = true;
                lblParentDepartment.Visible = true;
                RefreshCmbHierarchy(hierarchy);
            }
        }

        private void RefreshCmbHierarchy(EHierarchy hierarchy)
        {
            if (hierarchy == EHierarchy.Firma)
            {
                cmbParentDeparment.DataSource = "";
            }
            else
            {
                //insert only departments, where hierarchy is one level above
                List<DepartmentModel> departments = _departmentsLogic.GetParentsDepartments(hierarchy);
                //in list is only others departments than actual
                cmbParentDeparment.DataSource = departments.Where(dep => dep.ID != _department.ID).ToList();
                cmbParentDeparment.ValueMember = "Name";
            }
        }
        #endregion
    }
}
