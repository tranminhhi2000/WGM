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
        }

        void btnRestore_Click(object sender, EventArgs e)
        {
           
        }

        void RecycleBinForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dataGridView1.DataSource = view;
        }

        
    }
}
