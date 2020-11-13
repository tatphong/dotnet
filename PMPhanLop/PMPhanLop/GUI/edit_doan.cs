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
    public partial class edit_doan : Form
    {
        private int iddoan;
        

        public edit_doan(int iddoan, string tendoan, string tentour, DateTime ngaykhoihanh, DateTime ngayketthuc, int tongchiphi)
        {
            InitializeComponent();
            comboBox1.DataSource = new BUS.TourBUS().load_danh_sach_ten_tour();

            this.iddoan = iddoan;
            textBoxTenDoan.Text = tendoan;
            comboBox1.Text = tentour;
            dateTimeKhoiHanh.Value = ngaykhoihanh;
            dateTimeKetThuc.Value = ngayketthuc;
            textTongChiPhi.Text = tongchiphi.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            String tentour = comboBox1.GetItemText(comboBox1.SelectedItem);
            String tendoan = textBoxTenDoan.Text;
            DateTime ngaykhoihanh = dateTimeKhoiHanh.Value;
            DateTime ngayketthuc = dateTimeKetThuc.Value;
            int tongchiphi = textTongChiPhi.Text == "" ? 0 : Convert.ToInt32(textTongChiPhi.Text);

            var DialogResult = MessageBox.Show("Xác nhận thay đổi?", "Chú ý!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult == DialogResult.Yes)
            {
                int res = new BUS.DoanBUS().edit_doan(iddoan, tentour, tendoan, ngaykhoihanh, ngayketthuc, tongchiphi);
                if (res > 0)
                    this.Dispose();
                else if (res==0)
                    MessageBox.Show("Lỗi!!! Kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Lỗi kết nối cơ sở dữ liệu!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
