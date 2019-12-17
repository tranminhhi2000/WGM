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
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
            btnAdd.Click += btnAdd_Click;
            btnList.Click += btnList_Click;
            btnRemoved.Click += btnRemoved_Click;
        }

        void btnRemoved_Click(object sender, EventArgs e)
        {
            RecycleBinForm frm = new RecycleBinForm();
            frm.ShowDialog();
        }

        void btnList_Click(object sender, EventArgs e)
        {
            ListForm frm = new ListForm();
            frm.ShowDialog();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            CreateForm frm = new CreateForm();
            frm.ShowDialog();
        }
    }
}
