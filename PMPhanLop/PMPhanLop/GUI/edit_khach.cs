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
    public partial class edit_khach : Form
    {
        private int idkhach;

        public edit_khach(int idkhach, string hoten, string cmnd, bool gioitinh, string sodt, string diachi)
        {
            InitializeComponent();

            this.idkhach = idkhach;
            textHoTen.Text = hoten;
            textCMND.Text = cmnd;
            comboBoxSex.Text = gioitinh?"Nam":"Nữ";
            textSoDT.Text = sodt;
            textDiaChi.Text = diachi;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String hoten = textHoTen.Text;
            String cmnd = textCMND.Text;
            bool gioitinh = comboBoxSex.GetItemText(comboBoxSex.SelectedItem) == "Nam";
            String sodt = textSoDT.Text;
            String diachi = textDiaChi.Text;


            int res = new BUS.KhachBUS().edit_khach(idkhach, hoten, cmnd, gioitinh, sodt, diachi);
            if (res > 0)
                this.Dispose();
            else if (res == 0)
                MessageBox.Show("Lỗi!!! Kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
