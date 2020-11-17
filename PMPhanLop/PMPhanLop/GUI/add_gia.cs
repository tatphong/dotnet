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
    public partial class add_gia : Form
    {
        private int idtour;

        public add_gia(int idtour)
        {
            InitializeComponent();
            this.idtour = idtour;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int giatour = Convert.ToInt32(textBoxGia.Text);
            DateTime ngaybatdau = dateTimePicker1.Value;
            DateTime ngayketthuc = dateTimePicker2.Value;
            var res = new BUS.GiaTourBUS(idtour).add_gia(giatour, ngaybatdau, ngayketthuc);
            if (res > 0)
                this.Dispose();
            else if (res == 0)
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
