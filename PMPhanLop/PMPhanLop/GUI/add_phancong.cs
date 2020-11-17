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
    public partial class add_phancong : Form
    {
        private int iddoan;

        public add_phancong(int iddoan)
        {
            InitializeComponent();
            this.iddoan = iddoan;
            comboBoxNV.DataSource = new BUS.NhanVienBUS().load_ds_hoten();
        }

        private void add_phancong_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hoten = comboBoxNV.GetItemText(comboBoxNV.SelectedItem);
            int idnhanvien = new BUS.NhanVienBUS().getID_via_name(hoten);
            string chucvu = comboBoxChucVu.GetItemText(comboBoxChucVu.SelectedItem);
            string ghichu = textBox1.Text;

            var res = new BUS.PhanCongBUS(iddoan).add_phancong(idnhanvien, chucvu, ghichu);
            if (res > 0)
                this.Dispose();
            else if (res == 0)
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (res == -1)
                MessageBox.Show("Nhân viên này đã bận đi chuyến khác vào ngày đó!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
