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
    public partial class edit_nhanvien : Form
    {
        private int idnhanvien;

        public edit_nhanvien(int idnhanvien, string hoten, string cmnd)
        {
            InitializeComponent();

            this.idnhanvien = idnhanvien;
            textHoTen.Text = hoten;
            textCMND.Text = cmnd;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hoten = textHoTen.Text;
            string cmnd = textCMND.Text;

            var res = new BUS.NhanVienBUS().edit_nhanvien(idnhanvien, hoten, cmnd);
            if (res > 0)
                this.Dispose();
            else if (res == 0)
                MessageBox.Show("Dữ liệu không hợp lệ", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (res == -1)
                MessageBox.Show("Nhân viên với số CMND này đã tồn tại", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
