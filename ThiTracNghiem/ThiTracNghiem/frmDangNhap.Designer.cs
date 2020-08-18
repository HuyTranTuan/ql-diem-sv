namespace ThiTracNghiem
{
    partial class frmDangNhap
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbKhoa = new System.Windows.Forms.ComboBox();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDangNhap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Login_Button = new System.Windows.Forms.Button();
            this.Login_Exit_Button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbbKhoa);
            this.groupBox1.Controls.Add(this.txtPw);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDangNhap);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đăng Nhập Hệ Thống Quản Lý Điểm";
            // 
            // cbbKhoa
            // 
            this.cbbKhoa.AutoCompleteCustomSource.AddRange(new string[] {
            "Cơ sở 1",
            "Cơ sở 2"});
            this.cbbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbKhoa.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbKhoa.FormattingEnabled = true;
            this.cbbKhoa.Items.AddRange(new object[] {
            "Khoa Công Nghệ Thông Tin",
            "Khoa Viễn Thông"});
            this.cbbKhoa.Location = new System.Drawing.Point(15, 41);
            this.cbbKhoa.Name = "cbbKhoa";
            this.cbbKhoa.Size = new System.Drawing.Size(328, 30);
            this.cbbKhoa.TabIndex = 2;
            this.cbbKhoa.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // txtPw
            // 
            this.txtPw.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPw.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtPw.Location = new System.Drawing.Point(99, 112);
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '*';
            this.txtPw.Size = new System.Drawing.Size(244, 29);
            this.txtPw.TabIndex = 1;
            this.txtPw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPw_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu";
            // 
            // txtDangNhap
            // 
            this.txtDangNhap.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDangNhap.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtDangNhap.Location = new System.Drawing.Point(99, 77);
            this.txtDangNhap.Name = "txtDangNhap";
            this.txtDangNhap.Size = new System.Drawing.Size(244, 29);
            this.txtDangNhap.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tài khoản";
            // 
            // Login_Button
            // 
            this.Login_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Login_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Login_Button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Login_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Login_Button.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Button.ForeColor = System.Drawing.Color.Maroon;
            this.Login_Button.Location = new System.Drawing.Point(12, 168);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(358, 46);
            this.Login_Button.TabIndex = 1;
            this.Login_Button.Text = "Đăng nhập";
            this.Login_Button.UseVisualStyleBackColor = false;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // Login_Exit_Button
            // 
            this.Login_Exit_Button.BackColor = System.Drawing.Color.Transparent;
            this.Login_Exit_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Login_Exit_Button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Login_Exit_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Login_Exit_Button.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Exit_Button.ForeColor = System.Drawing.Color.Maroon;
            this.Login_Exit_Button.Location = new System.Drawing.Point(12, 221);
            this.Login_Exit_Button.Name = "Login_Exit_Button";
            this.Login_Exit_Button.Size = new System.Drawing.Size(358, 46);
            this.Login_Exit_Button.TabIndex = 2;
            this.Login_Exit_Button.Text = "Thoát";
            this.Login_Exit_Button.UseVisualStyleBackColor = false;
            this.Login_Exit_Button.Click += new System.EventHandler(this.Login_Exit_Button_Click);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 276);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.Login_Exit_Button);
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.FrmDangNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDangNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.Button Login_Exit_Button;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbKhoa;
    }
}