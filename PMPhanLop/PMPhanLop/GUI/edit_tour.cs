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
    public partial class edit_tour : Form
    {
        private int idtour;

        public edit_tour(int idtour, String tenloaidulich, string tentour, int songaytour)
        {
            InitializeComponent();
            comboTenLoaiDuLich.DataSource = new BUS.TourBUS().load_danh_sach_loai_tour();

            this.idtour = idtour;
            textTenTour.Text = tentour;
            comboTenLoaiDuLich.Text = tenloaidulich;
            textSoNgayTour.Text = songaytour.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            String tenloaidl = comboTenLoaiDuLich.GetItemText(comboTenLoaiDuLich.SelectedItem);
            String tentour = textTenTour.Text;
            int thoigiantour = textSoNgayTour.Text == "" ? 0 : Convert.ToInt32(textSoNgayTour.Text);
            var res = new BUS.TourBUS().edit_tour(this.idtour, tenloaidl, tentour, thoigiantour);
            if (res > 0)
                this.Dispose();
            else if (res == 0)
                MessageBox.Show("Dữ liệu không hợp lệ", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void comboTenLoaiDuLich_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
