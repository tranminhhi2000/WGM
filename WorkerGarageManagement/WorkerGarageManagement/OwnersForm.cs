using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkerGarageManagement
{
    public partial class OwnersForm : Form
    {

        LogicLayer business;
        public OwnersForm()
        {
            business = new LogicLayer();
            InitializeComponent();
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string cmnd = txtCMND.Text;
            string hovaten = txtHovaten.Text;
            DateTime ngaysinh = dtpNgaySinh.Value;
            string bienso = txtBienso.Text;

            business.AddOwners(cmnd, hovaten, ngaysinh, bienso);
            MessageBox.Show("Create completed");

        }
    }
}
