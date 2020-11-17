using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMPhanLop.GUI
{
    public partial class ThongKeDoanhThuGUI : Form
    {
        public ThongKeDoanhThuGUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new BUS.ThongKeBUS().TongLuotTourNV();
        }

        private void ThongKeDoanhThuGUI_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new BUS.ThongKeBUS().doanhso_doan();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new BUS.ThongKeBUS().doanhso_tour();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new BUS.ThongKeBUS().chiphitour();
        }
    }
}
