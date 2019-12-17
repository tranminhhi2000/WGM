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
        private LogicLayer business;
        private string bienSo;
        public UpdateListForm(string bienSo)
        {
            InitializeComponent();
            this.bienSo = bienSo;
            business = new LogicLayer();
            this.Load += UpdateListForm_Load;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        void UpdateListForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("OK");
            this.cboHang.DataSource = business.GetManufactures();
            this.cboHang.DisplayMember = "Name";
            this.cboHang.ValueMember = "ID";
            Xe xe = business.GetBike(this.bienSo);
            this.txtbienSo.Text = xe.License_Plates;
            this.txtTenxe.Text = xe.Name;
            this.cboHang.SelectedValue = xe.Manufacture;
            this.dtpGui.Value = xe.Time_Parking;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var business = new LogicLayer();
            var bienso = this.txtbienSo.Text;
            var tenxe = this.txtTenxe.Text;
            int hangxe = int.Parse(this.cboHang.SelectedValue.ToString());
            var giogui = this.dtpGui.Value;
            business.thayDoi(bienso, tenxe, hangxe,giogui);
            MessageBox.Show("Update class successfully.");
            this.Close();
            
        }
    }
}
