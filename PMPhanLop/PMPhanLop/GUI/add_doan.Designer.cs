namespace PMPhanLop.GUI
{
    partial class add_doan
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
            this.button2 = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxTenDoan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimeKhoiHanh = new System.Windows.Forms.DateTimePicker();
            this.dateTimeKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textTongChiPhi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên đoàn";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(416, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(416, 99);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 23);
            this.btn_them.TabIndex = 7;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Loại tour";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(104, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(349, 24);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxTenDoan
            // 
            this.textBoxTenDoan.Location = new System.Drawing.Point(104, 37);
            this.textBoxTenDoan.Name = "textBoxTenDoan";
            this.textBoxTenDoan.Size = new System.Drawing.Size(349, 22);
            this.textBoxTenDoan.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Ngày khởi hành";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dateTimeKhoiHanh
            // 
            this.dateTimeKhoiHanh.Location = new System.Drawing.Point(122, 99);
            this.dateTimeKhoiHanh.Name = "dateTimeKhoiHanh";
            this.dateTimeKhoiHanh.Size = new System.Drawing.Size(247, 22);
            this.dateTimeKhoiHanh.TabIndex = 17;
            // 
            // dateTimeKetThuc
            // 
            this.dateTimeKetThuc.Location = new System.Drawing.Point(122, 124);
            this.dateTimeKetThuc.Name = "dateTimeKetThuc";
            this.dateTimeKetThuc.Size = new System.Drawing.Size(247, 22);
            this.dateTimeKetThuc.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Ngày kết thúc";
            // 
            // textTongChiPhi
            // 
            this.textTongChiPhi.Location = new System.Drawing.Point(104, 62);
            this.textTongChiPhi.Name = "textTongChiPhi";
            this.textTongChiPhi.Size = new System.Drawing.Size(349, 22);
            this.textTongChiPhi.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Tổng chi phí";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // add_doan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 162);
            this.Controls.Add(this.textTongChiPhi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimeKetThuc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimeKhoiHanh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxTenDoan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_them);
            this.Name = "add_doan";
            this.Text = "add_doan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxTenDoan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimeKhoiHanh;
        private System.Windows.Forms.DateTimePicker dateTimeKetThuc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textTongChiPhi;
        private System.Windows.Forms.Label label6;
    }
}