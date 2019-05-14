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
            //get all departments from db
            List<DepartmentModel> departmentsList = _departmentsLogic.GetDepartments();
            //get new departmentModel from frm
            DepartmentModel departmentNew = LoadDeparmentFromFrm();
            //to secure that ID is not changed
            departmentNew.ID = _department.ID;

            //check if deparment have choosen parent department
            if (CheckIfCanSave(departmentNew))
            {
                //check if department have child departments or if it is changed hierarchy of department
                departmentsList = departmentsList.Where(dep => dep.ParentDepartmentID == departmentNew.ID).ToList();
                if (departmentsList.Count == 0 || departmentNew.Hierarchy == _department.Hierarchy)
                {
                    _departmentsLogic.UpdateDepartment(departmentNew);
                    Close();
                }
                else
                {
                    MessageBox.Show("Nie je možné uložiť zmenu oddelenia, pokiaľ má podriadené oddelenia");
                }

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

        /// <summary>
        /// Check if department have choosen parent deparment (Ehierarchy.Firma can have no parent
        /// </summary>
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
            DepartmentModel dep = (DepartmentModel)cmbParentDeparment.SelectedItem;
            if (dep == null)
            {
                department.ParentDepartmentID = 0;
            }
            else
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
                if (_department == null)
                {
                    cmbParentDeparment.DataSource = departments.ToList();
                }
                else
                {
                    cmbParentDeparment.DataSource = departments.Where(dep => dep.ID != _department.ID).ToList();
                }
                cmbParentDeparment.ValueMember = "Name";

            }
        }
        #endregion
    }
}
