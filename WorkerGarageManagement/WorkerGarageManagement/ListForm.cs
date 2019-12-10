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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                string bienSo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                
            }
        }
    }
}
