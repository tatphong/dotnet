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
    public partial class DoanGUI : Form
    {
        public DoanGUI()
        {
            InitializeComponent();
            load_data();
            //dataGridView1.ReadOnly = false;
            //dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
        }
        public void load_data()
        {
            dataGridView1.DataSource = new BUS.DoanBUS().load_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new add_doan().ShowDialog();
            load_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new ChitietDoanGUI(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BUS.DoanBUS a = new BUS.DoanBUS();
            var DialogResult = MessageBox.Show("Bạn thực sự muốn xóa chứ?", "Cảnh báo!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
                    a.delete_doan(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            load_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int iddoan = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            String tendoan = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String tentour = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DateTime ngaykhoihanh = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value);
            DateTime ngayketthuc = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);
            int tongchiphi = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);

            edit_doan ed = new edit_doan(iddoan, tendoan ,tentour, ngaykhoihanh, ngayketthuc, tongchiphi);
            ed.ShowDialog();
            load_data();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new BUS.DoanBUS().search(textBox1.Text);
        }
    }
}
