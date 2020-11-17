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
    public partial class edit_chiphi : Form
    {
        private int idtour;
        private int idchiphi;

        public edit_chiphi(int idtour, int idchiphi, string tenloaicp, int tongtien, string ghichu)
        {
            InitializeComponent();
            comboBox1.DataSource = new BUS.ChiPhiBUS(idtour).load_ds_loaicp();
            this.idtour = idtour;
            this.idchiphi = idchiphi;
            comboBox1.Text = tenloaicp;
            textBoxTongcp.Text = tongtien.ToString();
            textGhiChu.Text = ghichu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            String tenloaicp = comboBox1.GetItemText(comboBox1.SelectedItem);
            int tongtien = Convert.ToInt32(textBoxTongcp.Text);
            string ghichu = textGhiChu.Text;

            var res = new BUS.ChiPhiBUS(idtour).edit_chiphi(idchiphi, tenloaicp, tongtien, ghichu);
            if (res > 0)
                this.Dispose();
            else if (res == 0)
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
