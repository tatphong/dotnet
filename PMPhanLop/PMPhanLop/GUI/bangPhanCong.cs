﻿using System;
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
    public partial class bangPhanCong : Form
    {
        private int iddoan;

        public bangPhanCong(int iddoan)
        {
            this.iddoan = iddoan;
            InitializeComponent();
            load_data();
        }

        public void load_data()
        {
            dataGridView1.DataSource = new BUS.PhanCongBUS(iddoan).load_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_phancong a = new add_phancong(iddoan);
            a.ShowDialog();
            load_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var DialogResult = MessageBox.Show("Bạn thực sự muốn xóa chứ?", "Cảnh báo!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                int idphancong = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                new BUS.PhanCongBUS(iddoan).delete_phancong(idphancong);
                load_data();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string hotennv = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string chucvu = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string ghichu;
            ghichu = dataGridView1.CurrentRow.Cells[3].Value == null ? "" : dataGridView1.CurrentRow.Cells[3].Value.ToString();

            edit_phancong a = new edit_phancong(iddoan, hotennv, chucvu, ghichu);
            a.ShowDialog();
            load_data();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
