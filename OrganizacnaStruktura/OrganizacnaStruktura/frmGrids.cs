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
                    treeView.Visible = false;
                    break;

                case EFrmType.departments:
                    Text = "Zoznam oddelení";
                    break;
            }
            RefreshGrid();
        }

        #region Methods
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
                    dataGridView.Columns["HeadEmployeeName"].HeaderText = "Zodpovedný zamestnanec";

                    RefreshTreeList();
                    break;
            }
        }

        private void RefreshTreeList()
        {
            treeView.Nodes.Clear();
            List<DepartmentModel> list = _departmentsLogic.GetDepartments();
            List<DepartmentModel> companies = _departmentsLogic.GetNamesOfHierarchy(list, EHierarchy.Firma);
            List<DepartmentModel> divisions = _departmentsLogic.GetNamesOfHierarchy(list, EHierarchy.Divízia);
            List<DepartmentModel> projects = _departmentsLogic.GetNamesOfHierarchy(list, EHierarchy.Projekt);
            List<DepartmentModel> departments = _departmentsLogic.GetNamesOfHierarchy(list, EHierarchy.Oddelenie);

            int firmaInt = 0;
            foreach (var company in companies)
            {
                treeView.Nodes.Add($"{company.Name}");
                int diviziaInt = 0;
                foreach (var division in divisions)
                {
                    if (division.ParentDepartmentID == company.ID)
                    {
                        treeView.Nodes[firmaInt].Nodes.Add($"{division.Name}");
                        int ProjektInt = 0;
                        foreach (var project in projects)
                        {
                            if (project.ParentDepartmentID == division.ID)
                            {
                                treeView.Nodes[firmaInt].Nodes[diviziaInt].Nodes.Add($"{project.Name}");
                                int OddelenieInt = 0;
                                foreach (var department in departments)
                                {
                                    if (department.ParentDepartmentID == project.ID)
                                    {
                                        treeView.Nodes[firmaInt].Nodes[diviziaInt].Nodes[ProjektInt].Nodes.Add($"{department.Name}");
                                    }
                                    OddelenieInt++;
                                }
                            }
                            ProjektInt++;
                        }
                    }
                    diviziaInt++;
                }
                firmaInt++;
            }
            treeView.ExpandAll();
        }
        #endregion


        #region FrmActions
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

        /// <summary>
        /// Button only visible for Employee frm
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                switch (_eFrmType)
                {
                    case EFrmType.employees:
                        EmployeeModel employee = (EmployeeModel)dataGridView.CurrentRow.DataBoundItem;
                        List<string> departments = _departmentsLogic.UserExistInDepartment(employee.ID);
                        string message = _departmentsLogic.GetDepartmentsOfHeadEmployee(departments);

                        if (departments.Count == 0)
                        {
                            _employeesLogic.DeleteEmployee(employee.ID);
                            RefreshGrid();
                        }
                        else
                        {
                            MessageBox.Show(message, "Vymazanie zamestnanca");
                        }
                        break;

                    case EFrmType.departments:
                        DepartmentModel department = (DepartmentModel)dataGridView.CurrentRow.DataBoundItem;

                        //get all departments from db
                        List<DepartmentModel> departmentsList = _departmentsLogic.GetDepartments();

                        //check if department have child departments 
                        departmentsList = departmentsList.Where(dep => dep.ParentDepartmentID == department.ID).ToList();
                        if (departmentsList.Count == 0)
                        {
                            int number = _departmentsLogic.DeleteDepartment(department);
                            if (number == 0)
                            {
                                MessageBox.Show("Nie je možné vymazať oddelenie, pretože má priradených zamestnancov");
                            }
                            RefreshGrid();
                        }
                        else
                        {
                            MessageBox.Show("Nie je možné vymazať oddelenie, pokiaľ má podriadené oddelenia");
                        }
                        break;
                }
            }
        }
        #endregion


    }
}
