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

        public frmDepartment(EFrmType eFrmType)
        {
            InitializeComponent();

            cmbHierarchy.DataSource = Enum.GetValues(typeof(EHierarchy));

            switch (eFrmType)
            {
                case EFrmType.add:
                    Text = "Pridanie nového oddelenia";
                    lblNameOfFrm.Text = "Pridanie nového oddelenia";
                    break;
                case EFrmType.edit:
                    Text = "Editácia existujúceho oddelenia"; 
                    lblNameOfFrm.Text = "Editácia existujúceho oddelenia";

                    break;
                default:
                    break;
            }
        }

        private void btnSaveExist_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department.Code = txbDepartmentCode.Text;
            department.Name = txbDepartmentName.Text;
            department.Hierarchy = (EHierarchy)cmbHierarchy.SelectedValue;
            //department.ParentDepartment = int.Parse(cmbParentDeparment.SelectedItem);
            //department.HeadEmployeeID = int.Parse(cmbHeadEmployee.SelectedItem);
            _departmentsLogic.InsertDepartment(department);
            Close();

        }
    }
}
