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
        EmployeeModel _employee = new EmployeeModel();

        public frmEmployee(EFrmAction eFrmAction, EmployeeModel employee)
        {
            InitializeComponent();

            DepartmentsLogic departmentsLogic = new DepartmentsLogic();
            cmbDepartment.DataSource = departmentsLogic.GetDepartments();
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
            EmployeeModel employee = LoadEmployeeFromFrm();
            employee.ID = _employee.ID;
            _employeeLogic.UpdateEmployee(employee);
            Close();
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            EmployeeModel employee = LoadEmployeeFromFrm();
            _employeeLogic.InsertEmployee(employee);
            Close();
        }

        private EmployeeModel LoadEmployeeFromFrm()
        {
            EmployeeModel employee = new EmployeeModel();
            employee.Title = txbTitle.Text;
            employee.FirstName = txbFirstName.Text;
            employee.Lastname = txbLastName.Text;
            employee.Telephone = txbTelephone.Text;
            employee.Email = txbEmail.Text;
            DepartmentModel dep = (DepartmentModel)cmbDepartment.SelectedItem;
            employee.DepartmentID = dep.ID;
            return employee;
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
