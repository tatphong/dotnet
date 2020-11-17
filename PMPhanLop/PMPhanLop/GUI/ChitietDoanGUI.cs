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
    public partial class ChitietDoanGUI : Form
    {
        private int v;

        public ChitietDoanGUI(int v)
        {
            this.v = v;
            InitializeComponent();
            load_data();
        }

        public void load_data()
        {
            dataGridView1.DataSource = new BUS.ChitietDoanBUS(this.v).load_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var DialogResult = MessageBox.Show("Bạn thực sự muốn xóa chứ?", "Cảnh báo!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                int idkhach = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                new BUS.ChitietDoanBUS(v).delete_ctdoan(idkhach);
                load_data();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_ctdoan a = new add_ctdoan(this.v);
            a.ShowDialog();
            load_data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
