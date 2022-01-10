
namespace DauGia
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProdName = new System.Windows.Forms.Label();
            this.lblProdPrice = new System.Windows.Forms.Label();
            this.lblEclapse = new System.Windows.Forms.Label();
            this.btnBet = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBetPrice = new System.Windows.Forms.TextBox();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sản phẩm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Giá khởi điểm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thời gian còn lại:";
            // 
            // lblProdName
            // 
            this.lblProdName.AutoSize = true;
            this.lblProdName.Location = new System.Drawing.Point(125, 52);
            this.lblProdName.Name = "lblProdName";
            this.lblProdName.Size = new System.Drawing.Size(50, 20);
            this.lblProdName.TabIndex = 3;
            this.lblProdName.Text = "label4";
            // 
            // lblProdPrice
            // 
            this.lblProdPrice.AutoSize = true;
            this.lblProdPrice.Location = new System.Drawing.Point(125, 89);
            this.lblProdPrice.Name = "lblProdPrice";
            this.lblProdPrice.Size = new System.Drawing.Size(50, 20);
            this.lblProdPrice.TabIndex = 4;
            this.lblProdPrice.Text = "label5";
            // 
            // lblEclapse
            // 
            this.lblEclapse.AutoSize = true;
            this.lblEclapse.Location = new System.Drawing.Point(125, 128);
            this.lblEclapse.Name = "lblEclapse";
            this.lblEclapse.Size = new System.Drawing.Size(50, 20);
            this.lblEclapse.TabIndex = 5;
            this.lblEclapse.Text = "label6";
            // 
            // btnBet
            // 
            this.btnBet.Location = new System.Drawing.Point(330, 199);
            this.btnBet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(79, 31);
            this.btnBet.TabIndex = 6;
            this.btnBet.Text = "Đặt lệnh";
            this.btnBet.UseVisualStyleBackColor = true;
            this.btnBet.Click += new System.EventHandler(this.btnBet_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(330, 7);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(86, 31);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(226, 12);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(50, 20);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Nhập giá:";
            // 
            // txtBetPrice
            // 
            this.txtBetPrice.Location = new System.Drawing.Point(87, 200);
            this.txtBetPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBetPrice.Name = "txtBetPrice";
            this.txtBetPrice.Size = new System.Drawing.Size(236, 27);
            this.txtBetPrice.TabIndex = 10;
            this.txtBetPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBetPrice_KeyPress);
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(14, 256);
            this.txtConsole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtConsole.Size = new System.Drawing.Size(395, 267);
            this.txtConsole.TabIndex = 11;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(125, 161);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(50, 20);
            this.lblBalance.TabIndex = 12;
            this.lblBalance.Text = "label7";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Số dư hiện tại:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 540);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.txtBetPrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnBet);
            this.Controls.Add(this.lblEclapse);
            this.Controls.Add(this.lblProdPrice);
            this.Controls.Add(this.lblProdName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Sàn đấu giá";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProdName;
        private System.Windows.Forms.Label lblProdPrice;
        private System.Windows.Forms.Label lblEclapse;
        private System.Windows.Forms.Button btnBet;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBetPrice;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label5;
    }
}