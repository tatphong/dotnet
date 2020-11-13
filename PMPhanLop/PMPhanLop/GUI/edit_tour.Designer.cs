namespace PMPhanLop.GUI
{
    partial class edit_tour
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
            this.btn_them = new System.Windows.Forms.Button();
            this.textSoNgayTour = new System.Windows.Forms.TextBox();
            this.comboTenLoaiDuLich = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textTenTour = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(331, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 35;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(244, 65);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 28);
            this.btn_them.TabIndex = 34;
            this.btn_them.Text = "Thay đổi";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // textSoNgayTour
            // 
            this.textSoNgayTour.Location = new System.Drawing.Point(107, 63);
            this.textSoNgayTour.Name = "textSoNgayTour";
            this.textSoNgayTour.Size = new System.Drawing.Size(68, 22);
            this.textSoNgayTour.TabIndex = 43;
            // 
            // comboTenLoaiDuLich
            // 
            this.comboTenLoaiDuLich.FormattingEnabled = true;
            this.comboTenLoaiDuLich.Location = new System.Drawing.Point(107, 6);
            this.comboTenLoaiDuLich.Name = "comboTenLoaiDuLich";
            this.comboTenLoaiDuLich.Size = new System.Drawing.Size(299, 24);
            this.comboTenLoaiDuLich.TabIndex = 42;
            this.comboTenLoaiDuLich.SelectedIndexChanged += new System.EventHandler(this.comboTenLoaiDuLich_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 41;
            this.label6.Text = "Loại du lịch";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 40;
            this.label3.Text = "Số ngày tour";
            // 
            // textTenTour
            // 
            this.textTenTour.Location = new System.Drawing.Point(107, 35);
            this.textTenTour.Name = "textTenTour";
            this.textTenTour.Size = new System.Drawing.Size(299, 22);
            this.textTenTour.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Tên tour";
            // 
            // edit_tour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 99);
            this.Controls.Add(this.textSoNgayTour);
            this.Controls.Add(this.comboTenLoaiDuLich);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textTenTour);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_them);
            this.Name = "edit_tour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "edit_tour";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox textSoNgayTour;
        private System.Windows.Forms.ComboBox comboTenLoaiDuLich;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textTenTour;
        private System.Windows.Forms.Label label1;
    }
}