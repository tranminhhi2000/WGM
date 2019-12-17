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
    public partial class UpdateListForm : Form
    {
        LogicLayer business;
        public UpdateListForm()
        {
            InitializeComponent();
            business = new LogicLayer();
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            business.Change(txtbienSo.Text, txtTenxe.Text, int.Parse(cboHang.SelectedValue.ToString()), dtpGui.Value);
        }
    }
}
