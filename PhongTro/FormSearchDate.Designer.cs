namespace PhongTro
{
    partial class FormSearchDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchDate));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nmrNgay = new System.Windows.Forms.NumericUpDown();
            this.nmrThang = new System.Windows.Forms.NumericUpDown();
            this.nmrNam = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrNam)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(32, 125);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 30);
            this.btnOk.TabIndex = 23;
            this.btnOk.Text = "Ok";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(154, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 42);
            this.panel1.TabIndex = 68;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(291, 37);
            this.label5.TabIndex = 0;
            this.label5.Text = "TÌM KIẾM THEO NGÀY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(27, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 25);
            this.label2.TabIndex = 72;
            this.label2.Text = "Ngày     Tháng          Năm";
            // 
            // nmrNgay
            // 
            this.nmrNgay.Font = new System.Drawing.Font("Segoe UI Semilight", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrNgay.Location = new System.Drawing.Point(33, 85);
            this.nmrNgay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nmrNgay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrNgay.Name = "nmrNgay";
            this.nmrNgay.Size = new System.Drawing.Size(52, 34);
            this.nmrNgay.TabIndex = 73;
            this.nmrNgay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrNgay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmrThang
            // 
            this.nmrThang.Font = new System.Drawing.Font("Segoe UI Semilight", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrThang.Location = new System.Drawing.Point(100, 85);
            this.nmrThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nmrThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrThang.Name = "nmrThang";
            this.nmrThang.Size = new System.Drawing.Size(52, 34);
            this.nmrThang.TabIndex = 74;
            this.nmrThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmrNam
            // 
            this.nmrNam.Font = new System.Drawing.Font("Segoe UI Semilight", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrNam.Location = new System.Drawing.Point(166, 85);
            this.nmrNam.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nmrNam.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.nmrNam.Name = "nmrNam";
            this.nmrNam.Size = new System.Drawing.Size(98, 34);
            this.nmrNam.TabIndex = 75;
            this.nmrNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrNam.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // FormSearchDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(293, 159);
            this.ControlBox = false;
            this.Controls.Add(this.nmrNam);
            this.Controls.Add(this.nmrThang);
            this.Controls.Add(this.nmrNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSearchDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TÌM KIẾM THEO NGÀY";
            this.Load += new System.EventHandler(this.FormSearchDate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrNam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nmrNgay;
        private System.Windows.Forms.NumericUpDown nmrThang;
        private System.Windows.Forms.NumericUpDown nmrNam;
    }
}