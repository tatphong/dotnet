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
    public partial class add_chiphi : Form
    {
        private int idtour;

        public add_chiphi(int idtour)
        {
            this.idtour = idtour;
            InitializeComponent();
            comboBox1.DataSource = new BUS.ChiPhiBUS(idtour).load_ds_loaicp();
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

            var res = new BUS.ChiPhiBUS(idtour).add_chiphi(tenloaicp, tongtien, ghichu);
            if (res > 0)
                this.Dispose();
            else if (res == 0)
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
