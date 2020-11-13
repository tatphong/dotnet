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
    public partial class TourGUI : Form
    {
        public TourGUI()
        {
            InitializeComponent();
            load_data();
        }

        public void load_data()
        {
            dataGridView1.DataSource = new BUS.TourBUS().load_data();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new add_tour().ShowDialog();
            load_data();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            int idtour = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            String tenloaidulich = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String tentour = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            int songaytour = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);

            edit_tour et = new edit_tour(idtour, tenloaidulich, tentour, songaytour);
            et.ShowDialog();
            load_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BUS.DoanBUS a = new BUS.DoanBUS();
            var DialogResult = MessageBox.Show("Bạn thực sự muốn xóa chứ?", "Cảnh báo!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
                a.delete_doan(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            load_data();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new BUS.TourBUS().search(textBox1.Text);
        }

        private void TourGUI_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            bangGiaTour bgt = new bangGiaTour(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            bgt.ShowDialog();
            load_data();
        }
    }
}
