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
    public partial class InformationForm : Form
    {
        LogicLayer business;
        public InformationForm()
        {
            business = new LogicLayer();
            InitializeComponent();
            this.Load += InformationForm_Load;
            btnCreate.Click += btnCreate_Click;
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            OwnersForm onf = new OwnersForm();
            onf.ShowDialog();
            this.OnLoad(null);
        }

        void InformationForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoGenerateColumns = true;
            ChuXe[] data = business.Owners();
            ChuXeView[] view = new ChuXeView[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                view[i] = new ChuXeView();
                view[i].CMND = data[i].CMND;
                view[i].License_Plates = data[i].License_Plates;
                view[i].Name = data[i].Name;
                view[i].Birthday = data[i].Birthday.Value;
            }
            this.dataGridView1.DataSource = view;
        }
    }
}
