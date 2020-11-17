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
    public partial class bangGiaTour : Form
    {
        private int idtour;

        public bangGiaTour(int idtour)
        {
            this.idtour = idtour;
            InitializeComponent();
            load_data();
        }

        public void load_data()
        {
            dataGridView1.DataSource = new BUS.GiaTourBUS(idtour).load_gia();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dateTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngaybatdau = dateTimeFrom.Value;
            DateTime ngayketthuc = dateTimeTo.Value;
            if (ngaybatdau > ngayketthuc) ngayketthuc = ngaybatdau;
            dataGridView1.DataSource = new BUS.GiaTourBUS(idtour).search(ngaybatdau, ngayketthuc);
        }

        private void dateTimeTo_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngaybatdau = dateTimeFrom.Value;
            DateTime ngayketthuc = dateTimeTo.Value;
            if (ngaybatdau > ngayketthuc) ngaybatdau = ngayketthuc;
            dataGridView1.DataSource = new BUS.GiaTourBUS(idtour).search(ngaybatdau, ngayketthuc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var DialogResult = MessageBox.Show("Bạn thực sự muốn xóa chứ?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                new BUS.GiaTourBUS(idtour).delete_gia(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0]));
                load_data();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_gia ag = new add_gia(idtour);
            ag.ShowDialog();
            load_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idgia = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            int giatour = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
            DateTime ngaybatdau = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value);
            DateTime ngayketthuc = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value);
            edit_gia eg = new edit_gia(idgia, giatour, ngaybatdau, ngayketthuc);
            eg.ShowDialog();
            load_data();
        }
    }
}
