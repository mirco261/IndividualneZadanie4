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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            using (frmDepartments departments = new frmDepartments())
            {
                departments.ShowDialog();
            }
        }
    }
}
