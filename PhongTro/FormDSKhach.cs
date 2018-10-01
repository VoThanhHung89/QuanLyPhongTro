using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BAL;

namespace PhongTro
{
    public partial class FormDSKhach : Form
    {
        public FormDSKhach()
        {
            InitializeComponent();
        }
        BAL_Khach balK = new BAL_Khach();
        public static List<int> liMaKhach; 

        private void EditCellDgvKhach()
        {
            foreach (DataGridViewRow dgr in dgvKhach.Rows)
            {
                //Hiện ảnh
                if (dgr.Cells["hinhanh"].Value != null)
                {
                    Bitmap img = new Bitmap(Image.FromFile(dgr.Cells["hinhanh"].Value.ToString()), new Size(60, 70));
                    dgr.Cells["hinh"].Value = img;
                }
                //Tùy chỉnh Cell Chọn
                string chon = "Chọn";
                foreach(int i in liMaKhach)
                {
                    if (i == Convert.ToInt32(dgr.Cells["makhach"].Value))
                        chon = "Đã chọn";
                }
                dgr.Cells["chon"].Value = chon;
            }
        }

        private void FormDSKhach_Load(object sender, EventArgs e)
        {
            dgvKhach.DataSource = balK.GetAll();
            EditCellDgvKhach();
            cboTim.SelectedIndex = 0;
        }

        private void dgvKhach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhach.Columns[e.ColumnIndex].Name == "chon" && e.RowIndex > -1)
            {
                if (dgvKhach.Rows[e.RowIndex].Cells["chon"].Value.ToString() == "Chọn")
                {
                    liMaKhach.Add(Convert.ToInt32(dgvKhach.Rows[e.RowIndex].Cells["makhach"].Value.ToString()));
                    dgvKhach.Rows[e.RowIndex].Cells["chon"].Value = "Đã chọn";
                }
                else
                {
                    liMaKhach.Remove(Convert.ToInt32(dgvKhach.Rows[e.RowIndex].Cells["makhach"].Value.ToString()));
                    dgvKhach.Rows[e.RowIndex].Cells["chon"].Value = "Chọn";
                }
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            dgvKhach.DataSource = balK.Search(cboTim.SelectedIndex, txtTim.Text.Trim());
            EditCellDgvKhach();
            rdbHienTimKiem.Checked = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dgvKhach.DataSource = balK.Search(cboTim.SelectedIndex, txtTim.Text.Trim());
            EditCellDgvKhach();
            rdbHienTimKiem.Checked = true;
        }

        private void rdbHienTatCa_CheckedChanged(object sender, EventArgs e)
        {
            dgvKhach.DataSource = balK.GetAll();
            EditCellDgvKhach();
            cboTim.SelectedIndex = 0;
        }

        private void cboTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTim.SelectedIndex == 1)
            {
                FormSearchDate.ngaytim = string.Empty;
                FormSearchDate frm = new FormSearchDate();
                frm.ShowDialog();
                txtTim.Text = FormSearchDate.ngaytim;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
