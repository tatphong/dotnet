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
    public partial class NhanVienGUI : Form
    {
        public NhanVienGUI()
        {
            InitializeComponent();
            load_data();
        }

        public void load_data()
        {
            dataGridView1.DataSource = new BUS.NhanVienBUS().load_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_nhanvien an = new add_nhanvien();
            an.ShowDialog();
            load_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var DialogRes = MessageBox.Show("Nhân viên này sẽ bị loại khỏi cả danh sách phân công của đoàn. Bạn có muốn xóa?", "Lưu ý!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogRes == DialogResult.Yes)
            {
                int idnhanvien = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                new BUS.NhanVienBUS().delete_nhanvien(idnhanvien);
            }
            load_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            new BUS.NhanVienBUS().search(s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idnhanvien = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string hoten = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string cmnd = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            edit_nhanvien en = new edit_nhanvien(idnhanvien, hoten, cmnd);
            en.ShowDialog();
            load_data();
        }
    }
}
