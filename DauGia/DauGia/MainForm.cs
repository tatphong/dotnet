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
            Task update = new Task(() => getUpdateProduct());
            update.Start();
        }

        private async Task getUpdateProduct()
        {
            while (true)
            {
                string res = server.Send("check;" + user.username);
                string[] data = res.Split(";");
                if (data.Length == 1)
                    txtConsole.Text += "New bid for " + prod.name + " is set.\n";
                else if (!string.IsNullOrEmpty(data[0]))
                {
                    txtConsole.Text += "Winner for " + prod.name + " is: " + data[0] + ". Final bid: " + data[1] + "\n";
                    if (data[0] == user.username)
                    {
                        txtConsole.Text += "Congratulation. You are winner for: " + prod.name + ".\n";
                        this.user.balance -= Int32.Parse(data[1]);
                    }
                    prod = new Product(data[2], Int32.Parse(data[3]));
                    txtConsole.Text += "New product has been put.\n";
                    lblProdName.Text = prod.name;
                    lblProdPrice.Text = prod.org_price.ToString();
                }
                else 
                {
                    txtConsole.Text += "Last product have not been sold.\n";
                    prod = new Product(data[2], Int32.Parse(data[3]));
                    txtConsole.Text += "New product has been put.\n";
                    lblProdName.Text = prod.name;
                    lblProdPrice.Text = prod.org_price.ToString();
                }
                await Task.Delay(500);
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
                txtConsole.Text += "Your bid not valid.\n";
                return;
            }
            string request = $"bet;{user.username};{txtBetPrice}";
            string resCode = server.Send(request);
            string resConsole = "";
            if (resCode == "00")
                resConsole = "Successful put highest bid.";
            else if (resCode == "01")
                resConsole = "Your bid still lower.";
            else if (resCode == "51")
                resConsole = "Invalid balance.";
            else if (resCode == "98")
                resConsole = "Database error";
            else
                resConsole = "Unidentify error.";
            txtConsole.Text += resConsole+"\n";
        }

        private void txtBetPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
