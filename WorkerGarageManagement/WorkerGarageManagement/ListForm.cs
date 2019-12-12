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
            this.dataGridView1.DoubleClick += dataGridView1_DoubleClick;
            this.dataGridView1.KeyDown += dataGridView1_KeyDown;
        }

        void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if(this.dataGridView1.SelectedRows.Count == 1)
                {
                    if(MessageBox.Show("Do you want delete this?") == System.Windows.Forms.DialogResult.OK )
                    {
                        HangXe selected =
                            (HangXe)this.dataGridView1.SelectedRows[0].DataBoundItem;
                        var db = new WorkerFileEntities();
                        XeView deleted = db..Find(selected.ID);
                        db.Xes.Remove(deleted);
                        db.SaveChanges();
                        


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
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dataGridView1.DataSource = view;
        }
    }
}
