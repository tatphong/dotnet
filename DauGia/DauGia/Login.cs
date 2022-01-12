using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DauGia
{
    public partial class Login : Form
    {
        ServerConnection server;
        public Login(ServerConnection server)
        {
            this.server = server;
            InitializeComponent();
        }

        private string create_md5(string pass)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User(textBox1.Text, create_md5(textBox2.Text), 0);
            string request = $"authenticate;{user.username};{user.hashpass}";
            string res = server.Send(request);
            if (res.Split(";")[0] == "00")
            {
                user.balance = Int32.Parse(res.Split(";")[1]);
                MainForm main = new MainForm(this.server, user);
                main.StartPosition = FormStartPosition.CenterScreen;
                main.Show();
                this.Visible = false;
            }
            else if (res.Substring(0,2) == "01")
                label3.Text = "Login failed. Check your password";
            else
                label3.Text = "Login failed. Your username not exist";
        }
    }
}
