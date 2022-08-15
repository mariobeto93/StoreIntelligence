using StoreIntelligence.Infraestructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreIntelligence.WinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new ModalForm();
            form.ShowDialog();
            getItems();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            getItems();
        }

        private void getItems()
        {
            var log = new LogService();
            var items = log.GetLog();
            dataGridView1.DataSource = items;
        }
    }
}
