using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Models;
using Logika;

namespace OrganizacnaStruktura
{
    public partial class frmEmployee : Form
    {
        EmployeesLogic _employeeLogic = new EmployeesLogic();
        DepartmentsLogic _departmentsLogic = new DepartmentsLogic();
        EmployeeModel _employee = new EmployeeModel();

        public frmEmployee(EFrmAction eFrmAction, EmployeeModel employee)
        {
            InitializeComponent();

            cmbDepartment.DataSource = _departmentsLogic.GetDepartments();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            _employee = employee;

            switch (eFrmAction)
            {
                case EFrmAction.add:
                    Text = "Pridanie nového zamestnanca";
                    lblNameOfFrm.Text = "Pridanie nového zamestnanca";
                    btnSaveExist.Visible = false;
                    break;
                case EFrmAction.edit:
                    Text = "Editácia existujúceho zamestnanca";
                    lblNameOfFrm.Text = "Editácia existujúceho zamestnanca";
                    btnSaveNew.Visible = false;
                    FillFrmFromEmployee(_employee);
                    break;
                default:
                    break;
            }
        }

        private void btnSaveExist_Click(object sender, EventArgs e)
        {
            _employee = LoadEmployeeFromFrm(_employee);
            _employeeLogic.UpdateEmployee(_employee);
            Close();
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            EmployeeModel employee = LoadEmployeeFromFrm(_employee);
            _employeeLogic.InsertEmployee(employee);
            Close();
        }

        private EmployeeModel LoadEmployeeFromFrm(EmployeeModel _employee)
        {
            _employee.Title = txbTitle.Text;
            _employee.FirstName = txbFirstName.Text;
            _employee.Lastname = txbLastName.Text;
            _employee.Telephone = txbTelephone.Text;
            _employee.Email = txbEmail.Text;
            DepartmentModel dep = (DepartmentModel)cmbDepartment.SelectedItem;
            _employee.DepartmentID = dep.ID;
            return _employee;
        }

        private void FillFrmFromEmployee(EmployeeModel employee)
        {
            txbTitle.Text = employee.Title;
            txbFirstName.Text = employee.FirstName;
            txbLastName.Text = employee.Lastname;
            txbTelephone.Text = employee.Telephone;
            txbEmail.Text = employee.Email;
            cmbDepartment.SelectedValue = employee.DepartmentID;
        }
    }
}
