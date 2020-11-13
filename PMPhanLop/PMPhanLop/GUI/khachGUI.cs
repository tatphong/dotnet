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
    public partial class khachGUI : Form
    {
        public khachGUI()
        {
            InitializeComponent();
            load_data();
        }

        public void load_data()
        {
            dataGridView1.DataSource = new BUS.KhachBUS().load_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_khach a = new add_khach();
            a.ShowDialog();
            load_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var DialogResult = MessageBox.Show("Thông tin khách hàng tồn tại ở các danh sách đoàn đều sẽ mất. Xác nhận xóa?", "Cảnh báo!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                int idkhach = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                new BUS.KhachBUS().delete_khach(idkhach);
                load_data();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String s = textBoxSearch.Text;
            dataGridView1.DataSource = new BUS.KhachBUS().search(s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idkhach = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            String hoten = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String cmnd = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            bool gioitinh = dataGridView1.CurrentRow.Cells[3].Value.ToString() == "True";
            String sodt = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            String diachi = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            edit_khach ek = new edit_khach(idkhach, hoten, cmnd, gioitinh, sodt, diachi);
            ek.ShowDialog();
            load_data();
        }
    }
}
