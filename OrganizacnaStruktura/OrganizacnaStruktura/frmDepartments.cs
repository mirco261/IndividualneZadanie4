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
    public partial class frmDepartments : Form
    {
        private DepartmentsLogic _departmentsLogic = new DepartmentsLogic();

        public frmDepartments()
        {
            InitializeComponent();

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvDepartments.DataSource = "";
            dgvDepartments.DataSource = _departmentsLogic.GetDepartments();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            using (frmDepartment frmDepartment = new frmDepartment(EFrmType.add, department))
            {
                frmDepartment.ShowDialog();
                RefreshGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Department department = (Department)dgvDepartments.CurrentRow.DataBoundItem;
            using (frmDepartment frmDepartment = new frmDepartment(EFrmType.edit, department))
            {
                frmDepartment.ShowDialog();
                RefreshGrid();
            }
        }
    }
}
