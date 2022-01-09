using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DauGia
{
    public partial class MainForm : Form
    {
        ServerConnection server;
        User user { get; set; }
        Product prod { get; set; }

        public MainForm(ServerConnection server, User user)
        {
            this.server = server;
            this.user = user;
            InitializeComponent();
            lblUsername.Text = user.username;
            lblBalance.Text = user.balance.ToString();
            Task.Run(getUpdateProduct);
        }

        private async Task getUpdateProduct()
        {
            while (true)
            {
                string res = server.Send("check");
                string[] data = res.Split(";");
                if (data.Length == 1)
                    txtConsole.Text += "New bid for " + prod.name + " is set.\n";
                else
                {
                    txtConsole.Text += "Winner for " + prod.name + " is: " + data[0] + ". Final bid: " + data[1] + "\n";
                    if (data[0] == user.username)
                    {
                        txtConsole.Text += "Chúc mừng bạn đã chiến thắng sản phẩm: " + prod.name + ".\n";
                        this.user.balance -= Int32.Parse(data[1]);
                    }
                    prod = new Product(data[2], Int32.Parse(data[3]));
                    txtConsole.Text += "New product has been put.\n";
                    lblProdName.Text = prod.name;
                    lblProdPrice.Text = prod.org_price.ToString();
                }
                await Task.Delay(1000);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Login(this.server).Show();
            this.Dispose();
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txtBetPrice.Text) <= prod.org_price)
            {
                txtConsole.Text += "Giá bid không hợp lệ.\n";
                return;
            }
            string request = $"bet;{user.username};{txtBetPrice}";
            string resCode = server.Send(request);
            string resConsole = "";
            if (resCode == "00")
                resConsole = "Bạn đã đặt thành công mức bid cao nhất.";
            else if (resCode == "01")
                resConsole = "Mức bid của bạn chưa phải cao nhất.";
            else if (resCode == "51")
                resConsole = "Không đủ số dư.";
            else if (resCode == "98")
                resConsole = "Lỗi cơ sở dữ liệu";
            else
                resConsole = "Lỗi không xác định.";
            txtConsole.Text += resConsole+"\n";
        }

        private void txtBetPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
