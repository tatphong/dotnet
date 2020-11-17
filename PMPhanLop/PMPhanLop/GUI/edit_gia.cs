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
    public partial class edit_gia : Form
    {
        private int idgia;
        
        public edit_gia(int idgia, int giatour, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            InitializeComponent();
            this.idgia = idgia;
            textBoxGia.Text = giatour.ToString();
            dateTimeFrom.Value = ngaybatdau;
            dateTimeTo.Value = ngayketthuc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int giatour = Convert.ToInt32(textBoxGia.Text);
            DateTime ngaybatdau = dateTimeFrom.Value;
            DateTime ngayketthuc = dateTimeTo.Value;
            var res = new BUS.GiaTourBUS().edit_gia(idgia, giatour, ngaybatdau, ngayketthuc);
            if (res > 0)
                this.Dispose();
            else if (res == 0)
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
