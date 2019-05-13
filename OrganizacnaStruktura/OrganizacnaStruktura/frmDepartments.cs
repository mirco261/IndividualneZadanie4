using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logika;

namespace OrganizacnaStruktura
{
    public partial class frmDepartments : Form
    {
        private DepartmentsLogic _departmentsLogic = new DepartmentsLogic();

        public frmDepartments()
        {
            InitializeComponent();

            dgvDepartments.DataSource = _departmentsLogic.GetDepartments();
        }
    }
}
