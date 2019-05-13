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
    public partial class frmGrids : Form
    {
        private DepartmentsLogic _departmentsLogic = new DepartmentsLogic();
        private EmployeesLogic _employeesLogic = new EmployeesLogic();
        EFrmType _eFrmType;

        public frmGrids(EFrmType eFrmType)
        {
            InitializeComponent();

            _eFrmType = eFrmType;

            switch (_eFrmType)
            {
                case EFrmType.employees:
                    Text = "Zoznam zamestnancov";
                    break;

                case EFrmType.departments:
                    Text = "Zoznam oddelení";
                    break;
            }
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            switch (_eFrmType)
            {
                case EFrmType.employees:
                    dataGridView.DataSource = "";
                    dataGridView.DataSource = _employeesLogic.GetEmployees();
                    dataGridView.Columns["ID"].Visible = false;
                    dataGridView.Columns["Title"].HeaderText = "Titul";
                    dataGridView.Columns["FirstName"].HeaderText = "Krstné meno";
                    dataGridView.Columns["Lastname"].HeaderText = "Priezvisko";
                    dataGridView.Columns["Telephone"].HeaderText = "Klapka/Telefón";
                    dataGridView.Columns["Email"].HeaderText = "Email";
                    dataGridView.Columns["DepartmentName"].HeaderText = "Oddelenie";
                    dataGridView.Columns["DepartmentID"].Visible = false;
                    dataGridView.Columns["FullName"].Visible = false;
                    break;
                case EFrmType.departments:
                    dataGridView.DataSource = "";
                    dataGridView.DataSource = _departmentsLogic.GetDepartments();
                    dataGridView.Columns["ID"].Visible = false;
                    dataGridView.Columns["Code"].HeaderText = "Kód oddelenia";
                    dataGridView.Columns["Name"].HeaderText = "Názov oddelenia";
                    dataGridView.Columns["Hierarchy"].HeaderText = "Úroveň oddelenia";
                    dataGridView.Columns["ParentDepartmentID"].Visible = false;
                    dataGridView.Columns["HeadEmployeeID"].Visible = false;
                    dataGridView.Columns["ParentDepartmentName"].HeaderText = "Nadriadené oddelenie";
                    dataGridView.Columns["HeadEmployeeID"].Visible = false;
                    dataGridView.Columns["HeadEmployeeName"].HeaderText = "Zodpovedný zamestnanec";
                    break;
            }
            //dataGridView.Rows[0].Selected = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (_eFrmType)
            {
                case EFrmType.employees:
                    using (frmEmployee frmEmployee = new frmEmployee(EFrmAction.add, null))
                    {
                        frmEmployee.ShowDialog();
                        RefreshGrid();
                    }
                    break;

                case EFrmType.departments:
                    using (frmDepartment frmDepartment = new frmDepartment(EFrmAction.add, null))
                    {
                        frmDepartment.ShowDialog();
                        RefreshGrid();
                    }
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if datagridview is empty, I do not allow edit item in grid
            if (dataGridView.CurrentRow != null)
            {
                switch (_eFrmType)
                {
                    case EFrmType.employees:
                        EmployeeModel employee = (EmployeeModel)dataGridView.CurrentRow.DataBoundItem;
                        using (frmEmployee frmEmployee = new frmEmployee(EFrmAction.edit, employee))
                        {
                            frmEmployee.ShowDialog();
                            RefreshGrid();
                        }
                        break;

                    case EFrmType.departments:
                        DepartmentModel department = (DepartmentModel)dataGridView.CurrentRow.DataBoundItem;
                        using (frmDepartment frmDepartment = new frmDepartment(EFrmAction.edit, department))
                        {
                            frmDepartment.ShowDialog();
                            RefreshGrid();
                        }
                        break;
                }
            }
        }
    }
}
