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
    public partial class add_ctdoan : Form
    {
        private int v;

        public add_ctdoan(int v)
        {
            InitializeComponent();
            this.v = v;
            load_data();
        }

        public void load_data()
        {
            comboBox1.DataSource = new BUS.KhachBUS().load_khach_for_addctdoan(v);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String hoten = comboBox1.GetItemText(comboBox1.SelectedItem);
            new BUS.ChitietDoanBUS(v).add_ctdoan(new DAO.KhachDAO().getID_via_name(hoten));
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
