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
    public partial class add_tour : Form
    {
        public add_tour()
        {
            InitializeComponent();
            comboTenLoaiDuLich.DataSource = new BUS.TourBUS().load_danh_sach_loai_tour();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String tenloaidl = comboTenLoaiDuLich.GetItemText(comboTenLoaiDuLich.SelectedItem);
            String tentour = textTenTour.Text;
            int gia = textGia.Text == "" ? 0 : Convert.ToInt32(textGia.Text);
            int thoigiantour = textSoNgayTour.Text == "" ? 0 : Convert.ToInt32(textSoNgayTour.Text);
            int res = new BUS.TourBUS().add_tour(tenloaidl, tentour, thoigiantour, gia);
            if (res == 1)
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else MessageBox.Show("Thông tin nhập vào không hợp lệ", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void add_tour_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
