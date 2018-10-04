namespace PhongTro
{
    partial class FormHopDongCuaPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHopDongCuaPhong));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPhong = new System.Windows.Forms.Label();
            this.dgvHopDong = new System.Windows.Forms.DataGridView();
            this.xem = new System.Windows.Forms.DataGridViewLinkColumn();
            this.sua = new System.Windows.Forms.DataGridViewLinkColumn();
            this.giatri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mahopdong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaylamhopdong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaythue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaytra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chuthuephong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 42);
            this.panel1.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(627, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "DANH SÁCH CÁC HỢP ĐỒNG THUÊ CỦA PHÒNG ";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Transparent;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(901, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(50, 42);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblPhong);
            this.panel2.Controls.Add(this.dgvHopDong);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(951, 362);
            this.panel2.TabIndex = 86;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhong.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblPhong.Location = new System.Drawing.Point(3, 3);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(145, 37);
            this.lblPhong.TabIndex = 114;
            this.lblPhong.Text = "[ PHÒNG ]";
            // 
            // dgvHopDong
            // 
            this.dgvHopDong.AllowUserToAddRows = false;
            this.dgvHopDong.AllowUserToResizeColumns = false;
            this.dgvHopDong.AllowUserToResizeRows = false;
            this.dgvHopDong.BackgroundColor = System.Drawing.Color.White;
            this.dgvHopDong.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHopDong.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHopDong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHopDong.ColumnHeadersHeight = 40;
            this.dgvHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHopDong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xem,
            this.sua,
            this.giatri,
            this.mahopdong,
            this.ngaylamhopdong,
            this.ngaythue,
            this.ngaytra,
            this.chuthuephong});
            this.dgvHopDong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvHopDong.EnableHeadersVisualStyles = false;
            this.dgvHopDong.Location = new System.Drawing.Point(0, 43);
            this.dgvHopDong.MultiSelect = false;
            this.dgvHopDong.Name = "dgvHopDong";
            this.dgvHopDong.ReadOnly = true;
            this.dgvHopDong.RowHeadersVisible = false;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.dgvHopDong.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvHopDong.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHopDong.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvHopDong.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.dgvHopDong.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvHopDong.RowTemplate.Height = 25;
            this.dgvHopDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHopDong.Size = new System.Drawing.Size(951, 319);
            this.dgvHopDong.TabIndex = 116;
            this.dgvHopDong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHopDong_CellContentClick);
            // 
            // xem
            // 
            this.xem.ActiveLinkColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            this.xem.DefaultCellStyle = dataGridViewCellStyle2;
            this.xem.HeaderText = "Xem";
            this.xem.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.xem.LinkColor = System.Drawing.Color.Blue;
            this.xem.Name = "xem";
            this.xem.ReadOnly = true;
            this.xem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.xem.Text = "Xem";
            this.xem.UseColumnTextForLinkValue = true;
            this.xem.VisitedLinkColor = System.Drawing.Color.Blue;
            this.xem.Width = 40;
            // 
            // sua
            // 
            this.sua.ActiveLinkColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue;
            this.sua.DefaultCellStyle = dataGridViewCellStyle3;
            this.sua.HeaderText = "Sửa";
            this.sua.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.sua.LinkColor = System.Drawing.Color.Blue;
            this.sua.Name = "sua";
            this.sua.ReadOnly = true;
            this.sua.Text = "Sửa";
            this.sua.UseColumnTextForLinkValue = true;
            this.sua.VisitedLinkColor = System.Drawing.Color.Blue;
            this.sua.Width = 40;
            // 
            // giatri
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.giatri.DefaultCellStyle = dataGridViewCellStyle4;
            this.giatri.HeaderText = "Giá trị Hợp đồng";
            this.giatri.Name = "giatri";
            this.giatri.ReadOnly = true;
            this.giatri.Width = 120;
            // 
            // mahopdong
            // 
            this.mahopdong.HeaderText = "mahopdong";
            this.mahopdong.Name = "mahopdong";
            this.mahopdong.ReadOnly = true;
            this.mahopdong.Visible = false;
            // 
            // ngaylamhopdong
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.ngaylamhopdong.DefaultCellStyle = dataGridViewCellStyle5;
            this.ngaylamhopdong.HeaderText = "Ngày làm hợp đồng";
            this.ngaylamhopdong.Name = "ngaylamhopdong";
            this.ngaylamhopdong.ReadOnly = true;
            this.ngaylamhopdong.Width = 120;
            // 
            // ngaythue
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.ngaythue.DefaultCellStyle = dataGridViewCellStyle6;
            this.ngaythue.HeaderText = "Ngày thuê phòng";
            this.ngaythue.Name = "ngaythue";
            this.ngaythue.ReadOnly = true;
            this.ngaythue.Width = 120;
            // 
            // ngaytra
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.ngaytra.DefaultCellStyle = dataGridViewCellStyle7;
            this.ngaytra.HeaderText = "Ngày trả phòng";
            this.ngaytra.Name = "ngaytra";
            this.ngaytra.ReadOnly = true;
            this.ngaytra.Width = 120;
            // 
            // chuthuephong
            // 
            this.chuthuephong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chuthuephong.HeaderText = "Người đứng ra thuê phòng";
            this.chuthuephong.Name = "chuthuephong";
            this.chuthuephong.ReadOnly = true;
            // 
            // FormHopDongCuaPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(951, 410);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHopDongCuaPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CÁC HỢP ĐỒNG CỦA PHÒNG";
            this.Load += new System.EventHandler(this.FormChuyenPhong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvHopDong;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.DataGridViewLinkColumn xem;
        private System.Windows.Forms.DataGridViewLinkColumn sua;
        private System.Windows.Forms.DataGridViewTextBoxColumn giatri;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahopdong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaylamhopdong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaythue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaytra;
        private System.Windows.Forms.DataGridViewTextBoxColumn chuthuephong;
    }
}