using System;
using System.Collections;
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
    public partial class add_doan : Form
    {
        public add_doan()
        {
            InitializeComponent();
            comboBox1.DataSource = new BUS.TourBUS().load_danh_sach_ten_tour();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void add_chitietdoan()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            BUS.DoanBUS a = new BUS.DoanBUS();
            //idtour, tendoan, ngaykhoihanh, ngayketthuc, tongchiphi
            String tentour = comboBox1.GetItemText(comboBox1.SelectedItem);
            String tendoan = textBoxTenDoan.Text;
            DateTime ngaykhoihanh = dateTimeKhoiHanh.Value;
            int res = a.add_doan(tentour, tendoan, ngaykhoihanh);
            if (res != 0)
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else MessageBox.Show("Thông tin nhập vào không hợp lệ", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
