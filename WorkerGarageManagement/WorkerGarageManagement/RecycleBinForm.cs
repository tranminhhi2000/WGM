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
    public partial class RecycleBinForm : Form
    {
        LogicLayer business;
        public RecycleBinForm()
        {
            business = new LogicLayer();
            InitializeComponent();
            this.Load += RecycleBinForm_Load;
            this.btnRestore.Click += btnRestore_Click;
            this.dgvRecycle.KeyDown += dgvRecycle_KeyDown;
        }

        void dgvRecycle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (this.dgvRecycle.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show("Are you sure?") == System.Windows.Forms.DialogResult.OK)
                    {
                        XeView selected =
                            (XeView)this.dgvRecycle.SelectedRows[0].DataBoundItem;
                        var db = new WorkerFileEntities();
                        XeDeleted deleted = db.XeDeleteds.Find(selected.License_Plates);
                        db.XeDeleteds.Remove(deleted);
                        db.SaveChanges();
                        MessageBox.Show("Successfully deleted");
                        this.OnLoad(null);
                    }
                }
            }
        }

        void btnRestore_Click(object sender, EventArgs e)
        {
            XeView selected =
                            (XeView)this.dgvRecycle.SelectedRows[0].DataBoundItem;
            var db = new WorkerFileEntities();
            XeDeleted restored = db.XeDeleteds.Find(selected.License_Plates);
            db.XeDeleteds.Remove(restored);
            db.SaveChanges();
            string bienSoXe = selected.License_Plates;
            string tenXe = selected.Name;
            int hangXe = business.ReManufacure(selected.Manufacture);
            DateTime time = DateTime.Parse(selected.Time_Parking);
            business.AddBike(bienSoXe, tenXe, hangXe, time);
            MessageBox.Show("Restore Successfully");
            this.OnLoad(null);
        }

        void RecycleBinForm_Load(object sender, EventArgs e)
        {
            this.dgvRecycle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            XeDeleted[] data = business.GetDeletedBike();
            XeView[] view = new XeView[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                view[i] = new XeView();
                view[i].Name = data[i].Name;
                view[i].License_Plates = data[i].License_Plates;
                view[i].Manufacture = business.GetManufacture(data[i].Manufacture);
                view[i].Time_Parking = data[i].Time_Parking.ToShortDateString();
            }
            this.dgvRecycle.DataSource = view;
        }

        
    }
}
