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
    public partial class add_khach : Form
    {
        public add_khach()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboTenLoaiDuLich_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textSoNgayTour_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void textTenTour_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String hoten = textHoTen.Text;
            String cmnd = textCMND.Text;
            bool gioitinh = false;
            if (comboBoxSex.GetItemText(comboBoxSex.SelectedItem) == "Nam") gioitinh = true;
            String sodt = textSoDT.Text;
            String diachi = textDiaChi.Text;
            int res = new BUS.KhachBUS().add_khach(hoten, cmnd, gioitinh, sodt, diachi);
            if (res > 0)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
