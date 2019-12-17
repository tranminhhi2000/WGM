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
    public partial class CreateForm : Form
    {
        LogicLayer business;

        public CreateForm()
        {
            business = new LogicLayer();
            InitializeComponent();
            this.Load += CreateForm_Load;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void CreateForm_Load(object sender, EventArgs e)
        {
            this.cboHangxe.DataSource = business.GetManufactures();
            this.cboHangxe.DisplayMember = "Name";
            this.cboHangxe.ValueMember = "ID";
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string bienSoXe = txtSoxe.Text;
            string tenXe = txtTenxe.Text;
            int hangXe = int.Parse(cboHangxe.SelectedValue.ToString());
            DateTime time = dtpGuixe.Value;
            business.AddBike(bienSoXe, tenXe, hangXe, time);
            MessageBox.Show("Added successfully");
        }
    }
}
