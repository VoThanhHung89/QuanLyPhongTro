namespace PhongTro
{
    partial class FormDSCuocPhi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDSCuocPhi));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvCuocPhi = new System.Windows.Forms.DataGridView();
            this.chon = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tencuocphi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tang = new System.Windows.Forms.DataGridViewButtonColumn();
            this.soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giam = new System.Windows.Forms.DataGridViewButtonColumn();
            this.giacuocphi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xem = new System.Windows.Forms.DataGridViewLinkColumn();
            this.macuocphi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuocPhi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.btnDuyet);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 42);
            this.panel1.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(3, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "DANH SÁCH CƯỚC PHÍ";
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
            this.btnThoat.Location = new System.Drawing.Point(610, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(50, 42);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvCuocPhi
            // 
            this.dgvCuocPhi.AllowUserToAddRows = false;
            this.dgvCuocPhi.AllowUserToResizeColumns = false;
            this.dgvCuocPhi.AllowUserToResizeRows = false;
            this.dgvCuocPhi.BackgroundColor = System.Drawing.Color.White;
            this.dgvCuocPhi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCuocPhi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCuocPhi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCuocPhi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCuocPhi.ColumnHeadersHeight = 40;
            this.dgvCuocPhi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chon,
            this.tencuocphi,
            this.tang,
            this.soluong,
            this.giam,
            this.giacuocphi,
            this.xem,
            this.macuocphi});
            this.dgvCuocPhi.EnableHeadersVisualStyles = false;
            this.dgvCuocPhi.Location = new System.Drawing.Point(0, 41);
            this.dgvCuocPhi.MultiSelect = false;
            this.dgvCuocPhi.Name = "dgvCuocPhi";
            this.dgvCuocPhi.RowHeadersVisible = false;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.dgvCuocPhi.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCuocPhi.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.dgvCuocPhi.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCuocPhi.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.dgvCuocPhi.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCuocPhi.RowTemplate.Height = 25;
            this.dgvCuocPhi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuocPhi.Size = new System.Drawing.Size(660, 373);
            this.dgvCuocPhi.TabIndex = 77;
            this.dgvCuocPhi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuocPhi_CellContentClick);
            // 
            // chon
            // 
            this.chon.ActiveLinkColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            this.chon.DefaultCellStyle = dataGridViewCellStyle2;
            this.chon.HeaderText = "Chọn";
            this.chon.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.chon.LinkColor = System.Drawing.Color.Blue;
            this.chon.Name = "chon";
            this.chon.VisitedLinkColor = System.Drawing.Color.Blue;
            this.chon.Width = 80;
            // 
            // tencuocphi
            // 
            this.tencuocphi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tencuocphi.HeaderText = "Tên cước phí";
            this.tencuocphi.Name = "tencuocphi";
            this.tencuocphi.ReadOnly = true;
            // 
            // tang
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.tang.DefaultCellStyle = dataGridViewCellStyle3;
            this.tang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tang.HeaderText = "Tăng";
            this.tang.Name = "tang";
            this.tang.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tang.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tang.Text = "";
            this.tang.Width = 40;
            // 
            // soluong
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.soluong.DefaultCellStyle = dataGridViewCellStyle4;
            this.soluong.HeaderText = "Số lượng";
            this.soluong.Name = "soluong";
            // 
            // giam
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSalmon;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSalmon;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.giam.DefaultCellStyle = dataGridViewCellStyle5;
            this.giam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.giam.HeaderText = "Giảm";
            this.giam.Name = "giam";
            this.giam.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.giam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.giam.Width = 40;
            // 
            // giacuocphi
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.giacuocphi.DefaultCellStyle = dataGridViewCellStyle6;
            this.giacuocphi.HeaderText = "Giá cước";
            this.giacuocphi.Name = "giacuocphi";
            this.giacuocphi.ReadOnly = true;
            // 
            // xem
            // 
            this.xem.ActiveLinkColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Blue;
            this.xem.DefaultCellStyle = dataGridViewCellStyle7;
            this.xem.HeaderText = "Xem";
            this.xem.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.xem.LinkColor = System.Drawing.Color.Blue;
            this.xem.Name = "xem";
            this.xem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.xem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.xem.Text = "Xem";
            this.xem.UseColumnTextForLinkValue = true;
            this.xem.VisitedLinkColor = System.Drawing.Color.Blue;
            this.xem.Width = 40;
            // 
            // macuocphi
            // 
            this.macuocphi.HeaderText = "mã cước phí";
            this.macuocphi.Name = "macuocphi";
            this.macuocphi.Visible = false;
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
            this.btnDuyet.Location = new System.Drawing.Point(562, 0);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(50, 42);
            this.btnDuyet.TabIndex = 78;
            this.btnDuyet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDuyet.UseVisualStyleBackColor = false;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // FormDSCuocPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(660, 416);
            this.ControlBox = false;
            this.Controls.Add(this.dgvCuocPhi);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDSCuocPhi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DANH SÁCH CÁC LOẠI CƯỚC PHÍ";
            this.Load += new System.EventHandler(this.FormDSCuocPhi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuocPhi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvCuocPhi;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.DataGridViewLinkColumn chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn tencuocphi;
        private System.Windows.Forms.DataGridViewButtonColumn tang;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluong;
        private System.Windows.Forms.DataGridViewButtonColumn giam;
        private System.Windows.Forms.DataGridViewTextBoxColumn giacuocphi;
        private System.Windows.Forms.DataGridViewLinkColumn xem;
        private System.Windows.Forms.DataGridViewTextBoxColumn macuocphi;
    }
}