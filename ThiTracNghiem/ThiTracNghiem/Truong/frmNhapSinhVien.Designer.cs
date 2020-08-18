namespace ThiTracNghiem.Truong
{
    partial class frmNhapSinhVien
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
            this.dgvSV = new System.Windows.Forms.DataGridView();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phai = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nghihoc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.chkNghiHoc = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNoiSinh = new System.Windows.Forms.TextBox();
            this.chkPhai = new System.Windows.Forms.CheckBox();
            this.cbMaLop = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dtSV = new System.Windows.Forms.DateTimePicker();
            this.txtTKSV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenSV = new System.Windows.Forms.TextBox();
            this.txtHoSV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSV
            // 
            this.dgvSV.AllowUserToAddRows = false;
            this.dgvSV.AllowUserToDeleteRows = false;
            this.dgvSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLop,
            this.MaSV,
            this.Ho,
            this.Ten,
            this.NgaySinh,
            this.NoiSinh,
            this.phai,
            this.DiaChi,
            this.nghihoc});
            this.dgvSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSV.Location = new System.Drawing.Point(3, 25);
            this.dgvSV.Name = "dgvSV";
            this.dgvSV.Size = new System.Drawing.Size(1049, 317);
            this.dgvSV.TabIndex = 0;
            this.dgvSV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSV_CellClick);
            this.dgvSV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSV_CellContentClick);
            // 
            // MaLop
            // 
            this.MaLop.DataPropertyName = "MaLop";
            this.MaLop.HeaderText = "Mã lớp";
            this.MaLop.Name = "MaLop";
            // 
            // MaSV
            // 
            this.MaSV.DataPropertyName = "MaSV";
            this.MaSV.HeaderText = "Mã SV";
            this.MaSV.Name = "MaSV";
            // 
            // Ho
            // 
            this.Ho.DataPropertyName = "Ho";
            this.Ho.HeaderText = "Họ";
            this.Ho.Name = "Ho";
            // 
            // Ten
            // 
            this.Ten.DataPropertyName = "Ten";
            this.Ten.HeaderText = "Tên";
            this.Ten.Name = "Ten";
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            // 
            // NoiSinh
            // 
            this.NoiSinh.DataPropertyName = "noisinh";
            this.NoiSinh.HeaderText = "Nơi sinh";
            this.NoiSinh.Name = "NoiSinh";
            // 
            // phai
            // 
            this.phai.DataPropertyName = "phai";
            this.phai.HeaderText = "Phái";
            this.phai.Name = "phai";
            this.phai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.phai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            // 
            // nghihoc
            // 
            this.nghihoc.DataPropertyName = "nghihoc";
            this.nghihoc.HeaderText = "Đã nghĩ học";
            this.nghihoc.Name = "nghihoc";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(301, 168);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 31);
            this.button5.TabIndex = 14;
            this.button5.Text = "Ghi";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(180, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 31);
            this.button3.TabIndex = 12;
            this.button3.Text = "Hiệu chỉnh";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(99, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 31);
            this.button2.TabIndex = 11;
            this.button2.Text = "Xóa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(99, 127);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(655, 29);
            this.txtDiaChi.TabIndex = 9;
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(325, 23);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(192, 29);
            this.txtMaSV.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã lớp";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSV);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1055, 345);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách Sinh viên";
            this.groupBox2.Enter += new System.EventHandler(this.GroupBox2_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIn);
            this.groupBox1.Controls.Add(this.btnTaiLai);
            this.groupBox1.Controls.Add(this.chkNghiHoc);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtNoiSinh);
            this.groupBox1.Controls.Add(this.chkPhai);
            this.groupBox1.Controls.Add(this.cbMaLop);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.dtSV);
            this.groupBox1.Controls.Add(this.txtTKSV);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTenSV);
            this.groupBox1.Controls.Add(this.txtHoSV);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.txtMaSV);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1055, 243);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập Sinh viên";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(632, 205);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(122, 31);
            this.btnIn.TabIndex = 35;
            this.btnIn.Text = "In phiếu điểm";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(406, 206);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(75, 31);
            this.btnTaiLai.TabIndex = 34;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // chkNghiHoc
            // 
            this.chkNghiHoc.AutoSize = true;
            this.chkNghiHoc.Location = new System.Drawing.Point(548, 27);
            this.chkNghiHoc.Name = "chkNghiHoc";
            this.chkNghiHoc.Size = new System.Drawing.Size(122, 25);
            this.chkNghiHoc.TabIndex = 33;
            this.chkNghiHoc.Text = "Đã nghỉ học";
            this.chkNghiHoc.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(247, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 21);
            this.label9.TabIndex = 32;
            this.label9.Text = "Nơi sinh";
            // 
            // txtNoiSinh
            // 
            this.txtNoiSinh.Location = new System.Drawing.Point(325, 92);
            this.txtNoiSinh.Name = "txtNoiSinh";
            this.txtNoiSinh.Size = new System.Drawing.Size(429, 29);
            this.txtNoiSinh.TabIndex = 31;
            // 
            // chkPhai
            // 
            this.chkPhai.AutoSize = true;
            this.chkPhai.Location = new System.Drawing.Point(548, 65);
            this.chkPhai.Name = "chkPhai";
            this.chkPhai.Size = new System.Drawing.Size(64, 25);
            this.chkPhai.TabIndex = 30;
            this.chkPhai.Text = "Nam";
            this.chkPhai.UseVisualStyleBackColor = true;
            // 
            // cbMaLop
            // 
            this.cbMaLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaLop.FormattingEnabled = true;
            this.cbMaLop.Location = new System.Drawing.Point(81, 23);
            this.cbMaLop.Name = "cbMaLop";
            this.cbMaLop.Size = new System.Drawing.Size(127, 29);
            this.cbMaLop.TabIndex = 29;
            this.cbMaLop.SelectedIndexChanged += new System.EventHandler(this.CbMaLop_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(382, 168);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 31);
            this.button4.TabIndex = 26;
            this.button4.Text = "Thoát";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // dtSV
            // 
            this.dtSV.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtSV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSV.Location = new System.Drawing.Point(99, 92);
            this.dtSV.Name = "dtSV";
            this.dtSV.Size = new System.Drawing.Size(127, 29);
            this.dtSV.TabIndex = 25;
            // 
            // txtTKSV
            // 
            this.txtTKSV.Location = new System.Drawing.Point(99, 207);
            this.txtTKSV.Name = "txtTKSV";
            this.txtTKSV.Size = new System.Drawing.Size(220, 29);
            this.txtTKSV.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 21);
            this.label5.TabIndex = 23;
            this.label5.Text = "Nhập tên";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(325, 206);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 31);
            this.button6.TabIndex = 22;
            this.button6.Text = "Tìm ";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 21);
            this.label3.TabIndex = 21;
            this.label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ngày sinh";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "Tên";
            // 
            // txtTenSV
            // 
            this.txtTenSV.Location = new System.Drawing.Point(325, 58);
            this.txtTenSV.Name = "txtTenSV";
            this.txtTenSV.Size = new System.Drawing.Size(192, 29);
            this.txtTenSV.TabIndex = 18;
            this.txtTenSV.TextChanged += new System.EventHandler(this.TextBox7_TextChanged);
            // 
            // txtHoSV
            // 
            this.txtHoSV.Location = new System.Drawing.Point(81, 57);
            this.txtHoSV.Name = "txtHoSV";
            this.txtHoSV.Size = new System.Drawing.Size(127, 29);
            this.txtHoSV.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 21);
            this.label6.TabIndex = 16;
            this.label6.Text = "Họ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mã sinh viên";
            // 
            // frmNhapSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 588);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmNhapSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập sinh viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmNhapSinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSV;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenSV;
        private System.Windows.Forms.TextBox txtHoSV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTKSV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DateTimePicker dtSV;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cbMaLop;
        private System.Windows.Forms.CheckBox chkPhai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNoiSinh;
        private System.Windows.Forms.CheckBox chkNghiHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiSinh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn phai;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nghihoc;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnIn;
    }
}