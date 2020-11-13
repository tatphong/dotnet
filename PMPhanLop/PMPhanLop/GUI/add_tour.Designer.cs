namespace PMPhanLop.GUI
{
    partial class add_tour
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textGia = new System.Windows.Forms.TextBox();
            this.textTenTour = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboTenLoaiDuLich = new System.Windows.Forms.ComboBox();
            this.textSoNgayTour = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(331, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 33);
            this.button2.TabIndex = 23;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 22;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Số ngày tour";
            // 
            // textGia
            // 
            this.textGia.Location = new System.Drawing.Point(80, 62);
            this.textGia.Name = "textGia";
            this.textGia.Size = new System.Drawing.Size(128, 22);
            this.textGia.TabIndex = 15;
            // 
            // textTenTour
            // 
            this.textTenTour.Location = new System.Drawing.Point(80, 35);
            this.textTenTour.Name = "textTenTour";
            this.textTenTour.Size = new System.Drawing.Size(326, 22);
            this.textTenTour.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Giá";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tên tour";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Loại du lịch";
            // 
            // comboTenLoaiDuLich
            // 
            this.comboTenLoaiDuLich.FormattingEnabled = true;
            this.comboTenLoaiDuLich.Location = new System.Drawing.Point(98, 6);
            this.comboTenLoaiDuLich.Name = "comboTenLoaiDuLich";
            this.comboTenLoaiDuLich.Size = new System.Drawing.Size(308, 24);
            this.comboTenLoaiDuLich.TabIndex = 25;
            this.comboTenLoaiDuLich.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textSoNgayTour
            // 
            this.textSoNgayTour.Location = new System.Drawing.Point(352, 62);
            this.textSoNgayTour.Name = "textSoNgayTour";
            this.textSoNgayTour.Size = new System.Drawing.Size(54, 22);
            this.textSoNgayTour.TabIndex = 26;
            // 
            // add_tour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 131);
            this.Controls.Add(this.textSoNgayTour);
            this.Controls.Add(this.comboTenLoaiDuLich);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textGia);
            this.Controls.Add(this.textTenTour);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "add_tour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm tour mới";
            this.Load += new System.EventHandler(this.add_tour_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textGia;
        private System.Windows.Forms.TextBox textTenTour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboTenLoaiDuLich;
        private System.Windows.Forms.TextBox textSoNgayTour;
    }
}