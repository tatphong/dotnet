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
    public partial class DiaDiemGUI : Form
    {
        private int idtour;

        public DiaDiemGUI(int idtour)
        {
            this.idtour = idtour;
            InitializeComponent();
            load_diadiem();
        }

        public void load_diadiem()
        {
            dataGridView1.DataSource = new BUS.DiaDiemBUS(idtour).load_diadiem();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_diadiem ad = new add_diadiem(idtour);
            ad.ShowDialog();
            load_diadiem();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new BUS.DiaDiemBUS(idtour).delete_diadiem(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
        }

        private void DiaDiemGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
