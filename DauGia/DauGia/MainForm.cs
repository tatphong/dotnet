using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DauGia
{
    public partial class MainForm : Form
    {
        ServerConnection server;
        User user { get; set; }
        Product prod { get; set; }
        Task update;

        public MainForm(ServerConnection server, User user)
        {
            this.server = server;
            this.user = user;
            InitializeComponent();
            lblUsername.Text = user.username;
            lblBalance.Text = user.balance.ToString();
            update = new Task(() => getUpdateProduct());
            update.Start();
        }

        public void SetConsoleText(TextBox txtbox, string text)
        {
            this.Invoke(new MethodInvoker(delegate () {
                txtbox.AppendText(text);
                txtbox.AppendText(Environment.NewLine);
            }));
        }
        public void SetLabelText(Label lbl, string text)
        {
            this.Invoke(new MethodInvoker(delegate () {
                lbl.Text = text;
            }));
        }

        private async Task getUpdateProduct()
        {
            while (true)
            {
                string res = server.Send("check;" + user.username);
                string[] data = res.Split(";");
                if (res.Split("\0")[0] == "99")
                    continue;
                else if (data.Length == 1)
                    SetConsoleText(txtConsole, "New bid for " + prod.name + " is set.");
                else if (!string.IsNullOrEmpty(data[0]))
                {
                    SetConsoleText(txtConsole, "Winner for " + prod.name + " is: " + data[0] + ". Final bid: " + data[1]);
                    if (data[0] == user.username)
                    {
                        SetConsoleText(txtConsole, "Congratulation. You are winner for: " + prod.name);
                        this.user.balance -= Int32.Parse(data[1]);
                    }

                    prod = new Product(data[2], Int32.Parse(data[3]));
                    SetConsoleText(txtConsole, "New product has been put.");
                    SetLabelText(lblProdName, prod.name);
                    SetLabelText(lblProdPrice, prod.org_price.ToString());
                }
                else
                {
                    SetConsoleText(txtConsole, "Last product have not been sold.");
                    prod = new Product(data[2], Int32.Parse(data[3]));
                    SetConsoleText(txtConsole, "New product has been put.");
                    SetLabelText(lblProdName, prod.name);
                    SetLabelText(lblProdPrice, prod.org_price.ToString());
                }
                //await Task.Delay(5000);
                Thread.Sleep(2000);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Login(this.server).Show();
            this.Dispose();
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            if (Int64.Parse(txtBetPrice.Text) >= user.balance)
            {
                SetConsoleText(txtConsole, "Your balance not enough.");
                return;
            }
            if (Int32.Parse(txtBetPrice.Text) <= prod.org_price)
            {
                SetConsoleText(txtConsole, "Your bid not valid.");
                return;
            }
            string request = $"bet;{user.username};{txtBetPrice.Text}";
            string resCode = server.Send(request);
            string resConsole;
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

            SetConsoleText(txtConsole, resConsole);
        }

        private void txtBetPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
