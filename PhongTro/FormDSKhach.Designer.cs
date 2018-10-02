namespace PhongTro
{
    partial class FormDSKhach
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDSKhach));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvKhach = new System.Windows.Forms.DataGridView();
            this.chon = new System.Windows.Forms.DataGridViewLinkColumn();
            this.hinh = new System.Windows.Forms.DataGridViewImageColumn();
            this.makhach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tenkhach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaysinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioitinh = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sodinhdanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sodienthoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinhtranghonnhan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dangkytamtru = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.diachi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hinhanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboTim = new System.Windows.Forms.ComboBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rdbHienTatCa = new System.Windows.Forms.RadioButton();
            this.rdbHienTimKiem = new System.Windows.Forms.RadioButton();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKhach
            // 
            this.dgvKhach.AllowUserToAddRows = false;
            this.dgvKhach.AllowUserToResizeColumns = false;
            this.dgvKhach.AllowUserToResizeRows = false;
            this.dgvKhach.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKhach.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKhach.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhach.ColumnHeadersHeight = 40;
            this.dgvKhach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvKhach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chon,
            this.hinh,
            this.makhach,
            this.status,
            this.tenkhach,
            this.ngaysinh,
            this.gioitinh,
            this.sodinhdanh,
            this.sodienthoai,
            this.tinhtranghonnhan,
            this.dangkytamtru,
            this.diachi,
            this.hinhanh});
            this.dgvKhach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvKhach.EnableHeadersVisualStyles = false;
            this.dgvKhach.Location = new System.Drawing.Point(0, 56);
            this.dgvKhach.MultiSelect = false;
            this.dgvKhach.Name = "dgvKhach";
            this.dgvKhach.RowHeadersVisible = false;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.dgvKhach.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvKhach.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            this.dgvKhach.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.dgvKhach.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvKhach.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvKhach.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvKhach.RowTemplate.Height = 70;
            this.dgvKhach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhach.Size = new System.Drawing.Size(1210, 676);
            this.dgvKhach.TabIndex = 27;
            this.dgvKhach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhach_CellContentClick);
            // 
            // chon
            // 
            this.chon.ActiveLinkColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkBlue;
            this.chon.DefaultCellStyle = dataGridViewCellStyle2;
            this.chon.HeaderText = "Chọn";
            this.chon.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.chon.LinkColor = System.Drawing.Color.Blue;
            this.chon.Name = "chon";
            this.chon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chon.Text = "";
            this.chon.VisitedLinkColor = System.Drawing.Color.Blue;
            this.chon.Width = 70;
            // 
            // hinh
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            this.hinh.DefaultCellStyle = dataGridViewCellStyle3;
            this.hinh.HeaderText = "Hình ảnh";
            this.hinh.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.hinh.Name = "hinh";
            this.hinh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hinh.Width = 60;
            // 
            // makhach
            // 
            this.makhach.DataPropertyName = "makhach";
            this.makhach.HeaderText = "Mã Khách";
            this.makhach.Name = "makhach";
            this.makhach.ReadOnly = true;
            this.makhach.Visible = false;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.NullValue = false;
            this.status.DefaultCellStyle = dataGridViewCellStyle4;
            this.status.HeaderText = "Đang thuê";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            this.status.Width = 50;
            // 
            // tenkhach
            // 
            this.tenkhach.DataPropertyName = "tenkhach";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.tenkhach.DefaultCellStyle = dataGridViewCellStyle5;
            this.tenkhach.HeaderText = "Tên khách";
            this.tenkhach.Name = "tenkhach";
            this.tenkhach.ReadOnly = true;
            this.tenkhach.Width = 200;
            // 
            // ngaysinh
            // 
            this.ngaysinh.DataPropertyName = "ngaysinh";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.ngaysinh.DefaultCellStyle = dataGridViewCellStyle6;
            this.ngaysinh.HeaderText = "Ngày sinh";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.ReadOnly = true;
            // 
            // gioitinh
            // 
            this.gioitinh.DataPropertyName = "gioitinh";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.NullValue = false;
            this.gioitinh.DefaultCellStyle = dataGridViewCellStyle7;
            this.gioitinh.HeaderText = "Nam";
            this.gioitinh.Name = "gioitinh";
            this.gioitinh.ReadOnly = true;
            this.gioitinh.Width = 50;
            // 
            // sodinhdanh
            // 
            this.sodinhdanh.DataPropertyName = "sodinhdanh";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.sodinhdanh.DefaultCellStyle = dataGridViewCellStyle8;
            this.sodinhdanh.HeaderText = "Số định danh";
            this.sodinhdanh.Name = "sodinhdanh";
            this.sodinhdanh.ReadOnly = true;
            this.sodinhdanh.Width = 120;
            // 
            // sodienthoai
            // 
            this.sodienthoai.DataPropertyName = "sodienthoai";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.sodienthoai.DefaultCellStyle = dataGridViewCellStyle9;
            this.sodienthoai.HeaderText = "Số điện thoại";
            this.sodienthoai.Name = "sodienthoai";
            this.sodienthoai.ReadOnly = true;
            this.sodienthoai.Width = 120;
            // 
            // tinhtranghonnhan
            // 
            this.tinhtranghonnhan.DataPropertyName = "tinhtranghonnhan";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle10.NullValue = false;
            this.tinhtranghonnhan.DefaultCellStyle = dataGridViewCellStyle10;
            this.tinhtranghonnhan.HeaderText = "Hôn nhân";
            this.tinhtranghonnhan.Name = "tinhtranghonnhan";
            this.tinhtranghonnhan.ReadOnly = true;
            this.tinhtranghonnhan.Width = 50;
            // 
            // dangkytamtru
            // 
            this.dangkytamtru.DataPropertyName = "dangkytamtru";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle11.NullValue = false;
            this.dangkytamtru.DefaultCellStyle = dataGridViewCellStyle11;
            this.dangkytamtru.HeaderText = "Tạm trú";
            this.dangkytamtru.Name = "dangkytamtru";
            this.dangkytamtru.ReadOnly = true;
            this.dangkytamtru.Width = 50;
            // 
            // diachi
            // 
            this.diachi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.diachi.DataPropertyName = "diachi";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.diachi.DefaultCellStyle = dataGridViewCellStyle12;
            this.diachi.HeaderText = "Địa chỉ";
            this.diachi.Name = "diachi";
            this.diachi.ReadOnly = true;
            // 
            // hinhanh
            // 
            this.hinhanh.DataPropertyName = "hinh";
            this.hinhanh.HeaderText = "Column1";
            this.hinhanh.Name = "hinhanh";
            this.hinhanh.Visible = false;
            // 
            // cboTim
            // 
            this.cboTim.BackColor = System.Drawing.Color.White;
            this.cboTim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTim.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTim.FormattingEnabled = true;
            this.cboTim.Items.AddRange(new object[] {
            "Tên Khách",
            "Ngày Sinh",
            "Số Định Danh",
            "Số Điện Thoại",
            "Địa Chỉ"});
            this.cboTim.Location = new System.Drawing.Point(6, 19);
            this.cboTim.Name = "cboTim";
            this.cboTim.Size = new System.Drawing.Size(158, 25);
            this.cboTim.TabIndex = 42;
            this.cboTim.SelectedIndexChanged += new System.EventHandler(this.cboTim_SelectedIndexChanged);
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.LightBlue;
            this.btnTim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = ((System.Drawing.Image)(resources.GetObject("btnTim.Image")));
            this.btnTim.Location = new System.Drawing.Point(479, 19);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(32, 25);
            this.btnTim.TabIndex = 41;
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtTim
            // 
            this.txtTim.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.Location = new System.Drawing.Point(169, 19);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(311, 25);
            this.txtTim.TabIndex = 40;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gold;
            this.groupBox1.Controls.Add(this.cboTim);
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.txtTim);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(229, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 50);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(-1, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 30);
            this.label6.TabIndex = 44;
            this.label6.Text = "DANH SÁCH KHÁCH";
            // 
            // rdbHienTatCa
            // 
            this.rdbHienTatCa.AutoSize = true;
            this.rdbHienTatCa.Checked = true;
            this.rdbHienTatCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbHienTatCa.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbHienTatCa.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdbHienTatCa.Location = new System.Drawing.Point(751, 6);
            this.rdbHienTatCa.Name = "rdbHienTatCa";
            this.rdbHienTatCa.Size = new System.Drawing.Size(246, 23);
            this.rdbHienTatCa.TabIndex = 60;
            this.rdbHienTatCa.TabStop = true;
            this.rdbHienTatCa.Text = "Hiện tất cả Khách chưa được chọn";
            this.rdbHienTatCa.UseVisualStyleBackColor = true;
            this.rdbHienTatCa.CheckedChanged += new System.EventHandler(this.rdbHienTatCa_CheckedChanged);
            // 
            // rdbHienTimKiem
            // 
            this.rdbHienTimKiem.AutoSize = true;
            this.rdbHienTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbHienTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbHienTimKiem.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdbHienTimKiem.Location = new System.Drawing.Point(751, 27);
            this.rdbHienTimKiem.Name = "rdbHienTimKiem";
            this.rdbHienTimKiem.Size = new System.Drawing.Size(147, 23);
            this.rdbHienTimKiem.TabIndex = 61;
            this.rdbHienTimKiem.Text = "Hiện theo tìm kiếm";
            this.rdbHienTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnDuyet
            // 
            this.btnDuyet.BackColor = System.Drawing.Color.Transparent;
            this.btnDuyet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDuyet.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnDuyet.FlatAppearance.BorderSize = 0;
            this.btnDuyet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuyet.Image = ((System.Drawing.Image)(resources.GetObject("btnDuyet.Image")));
            this.btnDuyet.Location = new System.Drawing.Point(1109, 0);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(50, 42);
            this.btnDuyet.TabIndex = 62;
            this.btnDuyet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDuyet.UseVisualStyleBackColor = false;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Transparent;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(1159, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(50, 42);
            this.btnThoat.TabIndex = 64;
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FormDSKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(1210, 732);
            this.ControlBox = false;
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDuyet);
            this.Controls.Add(this.rdbHienTimKiem);
            this.Controls.Add(this.rdbHienTatCa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvKhach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDSKhach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormDSKhach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhach;
        private System.Windows.Forms.ComboBox cboTim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdbHienTatCa;
        private System.Windows.Forms.RadioButton rdbHienTimKiem;
        private System.Windows.Forms.DataGridViewLinkColumn chon;
        private System.Windows.Forms.DataGridViewImageColumn hinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn makhach;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenkhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaysinh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gioitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn sodinhdanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn sodienthoai;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tinhtranghonnhan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dangkytamtru;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachi;
        private System.Windows.Forms.DataGridViewTextBoxColumn hinhanh;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnThoat;
    }
}