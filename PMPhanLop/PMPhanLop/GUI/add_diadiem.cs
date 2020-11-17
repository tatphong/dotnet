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
    public partial class add_diadiem : Form
    {
        private int idtour;

        public add_diadiem(int idtour)
        {
            InitializeComponent();
            this.idtour = idtour;
            comboBox1.DataSource = new BUS.DiaDiemBUS(idtour).load_ds_tendiadiem();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tendiadiem = comboBox1.GetItemText(comboBox1.Text);
            var res = new BUS.DiaDiemBUS(idtour).add_diadiem(tendiadiem);
            if (res > 0)
                this.Dispose();
            else if (res == 0)
            {
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (res == -1)
            {
                MessageBox.Show("Địa điểm này đã có trong tour hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
