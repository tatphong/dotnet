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
    public partial class ChiPhiGUI : Form
    {
        private int idtour;

        public ChiPhiGUI(int idtour)
        {
            this.idtour = idtour;
            InitializeComponent();
            load_data();
        }

        public void load_data()
        {
            dataGridView1.DataSource = new BUS.ChiPhiBUS(idtour).load_chiphi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var DialogResult = MessageBox.Show("Bạn thực sự muốn xóa chứ?", "Cảnh báo!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                int idchiphi = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                new BUS.ChiPhiBUS(idtour).delete_chiphi(idchiphi);
                load_data();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_chiphi ac = new add_chiphi(idtour);
            ac.ShowDialog();
            load_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idchiphi = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string tenloaicp = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            int tongtien = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
            string ghichu;
            ghichu = dataGridView1.CurrentRow.Cells[3].Value == null ? "" : dataGridView1.CurrentRow.Cells[3].Value.ToString();

            edit_chiphi ac = new edit_chiphi(idtour, idchiphi, tenloaicp, tongtien, ghichu);
            ac.ShowDialog();
            load_data();
        }
    }
}
