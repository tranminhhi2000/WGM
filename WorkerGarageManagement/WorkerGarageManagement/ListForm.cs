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
    public partial class ListForm : Form
    {
        LogicLayer business;
        public ListForm()
        {
            business = new LogicLayer();
            InitializeComponent();
            this.Load += ListForm_Load;
            this.btnUpdate.DoubleClick += dataGridView1_DoubleClick;
            this.btnUpdate.KeyDown += dataGridView1_KeyDown;
        }
        void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if(this.btnUpdate.SelectedRows.Count == 1)
                {
                    if(MessageBox.Show("Do you want delete this?") == System.Windows.Forms.DialogResult.OK )
                    {
                        XeView selected =
                            (XeView)this.btnUpdate.SelectedRows[0].DataBoundItem;
                        var db = new WorkerFileEntities();
                        Xe deleted = db.Xes.Find(selected.License_Plates);
                        db.Xes.Remove(deleted);
                        db.SaveChanges();
                        string bienSoXe = selected.License_Plates;
                        string tenXe = selected.Name;
                        int hangXe = business.ReManufacure(selected.Manufacture);
                        DateTime time = DateTime.Parse(selected.Time_Parking);
                        business.AddBikes(bienSoXe, tenXe, hangXe, time);
                        MessageBox.Show("Successfully deleted");
                        this.OnLoad(null);
                    }
                }
            }
        }

        void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            InformationForm frm = new InformationForm();
            frm.ShowDialog();
        }

        void ListForm_Load(object sender, EventArgs e)
        {
            this.btnUpdate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Xe[] data = business.GetBikes();
            XeView[] view = new XeView[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                view[i] = new XeView();
                view[i].Name = data[i].Name;
                view[i].License_Plates = data[i].License_Plates;
                view[i].Manufacture = business.GetManufacture(data[i].Manufacture);
                view[i].Time_Parking = data[i].Time_Parking.ToShortDateString();
            }
            this.btnUpdate.DataSource = view;
        }
    }
}
