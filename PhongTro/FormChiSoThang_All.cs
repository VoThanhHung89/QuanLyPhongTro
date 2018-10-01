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
    public partial class FormChiSoThang_All : Form
    {
        public FormChiSoThang_All()
        {
            InitializeComponent();
        }
        BAL_ChuPhong balCP = new BAL_ChuPhong();
        BAL_LoaiPhong balLP = new BAL_LoaiPhong();
        BAL_Phong balP = new BAL_Phong();
        BAL_ChiSoThang balCST = new BAL_ChiSoThang();

        private void LoadData()
        {
            dtpNgayCapNhat.DataBindings.Clear();
            dtpNgayCapNhat.DataBindings.Add("Value", dgvPhong.DataSource, "ngaycapnhat");
            txtSoDien.DataBindings.Clear();
            txtSoDien.DataBindings.Add("Text", dgvPhong.DataSource, "chisodien");
            txtSoNuoc.DataBindings.Clear();
            txtSoNuoc.DataBindings.Add("Text", dgvPhong.DataSource, "chisonuoc");

            txtTenLoaiPhong.DataBindings.Clear();
            txtTenLoaiPhong.DataBindings.Add("Text", dgvPhong.DataSource,"tenloaiphong");
            txtTenPhong.DataBindings.Clear();
            txtTenPhong.DataBindings.Add("Text", dgvPhong.DataSource, "tenphong");
            txtTenChuPhong.DataBindings.Clear();
            txtTenChuPhong.DataBindings.Add("Text", dgvPhong.DataSource, "tenchuphong");
        }

        private void FormDien_Nuoc_Load(object sender, EventArgs e)
        {
            dgvPhong.DataSource = balCST.ChiSoTheoThoiGian(balP.GetAll(), DateTime.Now);
            LoadData();
            cboTimkiem.SelectedIndex = 0;
        }

        private void btnLen_Click(object sender, EventArgs e)
        {
            int dr = dgvPhong.CurrentRow.Index;

            if (txtSoDien.Text.Trim() == string.Empty)
                dgvPhong.Rows[dr].Cells["chisodien"].Value = DBNull.Value;
            else dgvPhong.Rows[dr].Cells["chisodien"].Value = txtSoDien.Text;
            if (txtSoNuoc.Text.Trim() == string.Empty)
                dgvPhong.Rows[dr].Cells["chisonuoc"].Value = DBNull.Value;
            else dgvPhong.Rows[dr].Cells["chisonuoc"].Value = txtSoNuoc.Text;

            if (dr > 0)
            {
                dgvPhong.Rows[dr - 1].Cells[0].Selected = true;
                txtSoDien.Text = dgvPhong.Rows[dr - 1].Cells["chisodien"].Value.ToString();
                txtSoNuoc.Text = dgvPhong.Rows[dr - 1].Cells["chisonuoc"].Value.ToString();
            } 
            else if (dr == 0) MessageBox.Show("Hết phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


            if (dgvPhong.SelectedRows.Count != 0)
            {
                int maphong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["maphong"].Value);
                DTOChiSoThang cstGanNgayNay = balCST.ChiSoGanVoiNgayCanTim(maphong, dtpNgayCapNhat.Value);
                if (cstGanNgayNay != null)
                {
                    dtpNgayGanNhat.Value = cstGanNgayNay.ngaycapnhat;
                    txtSoDienGanNhat.Text = cstGanNgayNay.chisodien.ToString();
                    txtSoNuocGanNhat.Text = cstGanNgayNay.chisonuoc.ToString();
                }
                else
                {
                    txtSoDienGanNhat.Text = txtSoNuocGanNhat.Text = String.Empty;
                }
            }
        }

        private void btnXuong_Click(object sender, EventArgs e)
        {
            int dr = dgvPhong.CurrentRow.Index;

            if (txtSoDien.Text.Trim() == string.Empty)
                dgvPhong.Rows[dr].Cells["chisodien"].Value = DBNull.Value;
            else dgvPhong.Rows[dr].Cells["chisodien"].Value = txtSoDien.Text;
            if (txtSoNuoc.Text.Trim() == string.Empty)
                dgvPhong.Rows[dr].Cells["chisonuoc"].Value = DBNull.Value;
            else dgvPhong.Rows[dr].Cells["chisonuoc"].Value = txtSoNuoc.Text;

            if (dr < dgvPhong.RowCount - 1)
            {
                dgvPhong.Rows[dr + 1].Cells[0].Selected = true;
                txtSoDien.Text = dgvPhong.Rows[dr + 1].Cells["chisodien"].Value.ToString();
                txtSoNuoc.Text = dgvPhong.Rows[dr + 1].Cells["chisonuoc"].Value.ToString();
            }
            else MessageBox.Show("Hết phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            if (dgvPhong.SelectedRows.Count != 0)
            {
                int maphong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["maphong"].Value);
                DTOChiSoThang cstGanNgayNay = balCST.ChiSoGanVoiNgayCanTim(maphong, dtpNgayCapNhat.Value);
                if (cstGanNgayNay != null)
                {
                    dtpNgayGanNhat.Value = cstGanNgayNay.ngaycapnhat;
                    txtSoDienGanNhat.Text = cstGanNgayNay.chisodien.ToString();
                    txtSoNuocGanNhat.Text = cstGanNgayNay.chisonuoc.ToString();
                }
                else
                {
                    txtSoDienGanNhat.Text = txtSoNuocGanNhat.Text = String.Empty;
                }
            }
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Bạn muốn tải lại toàn bộ thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                dgvPhong.DataSource = balCST.ChiSoTheoThoiGian(balP.GetAll(), DateTime.Now);
                cboTimkiem.SelectedIndex = 0;
                dtpNgayCapNhat.Value = DateTime.Now;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                //Lưu dữ liệu
                foreach (DataGridViewRow dgr in dgvPhong.Rows)
                {
                    if (dgr.Cells["chisodien"].Value != DBNull.Value || dgr.Cells["chisonuoc"].Value != DBNull.Value)
                    {
                        DTOChiSoThang dtoCST = new DTOChiSoThang()
                        {
                            maphong = Convert.ToInt32(dgr.Cells["maphong"].Value),
                            ngaycapnhat = Convert.ToDateTime(dgr.Cells["ngaycapnhat"].Value)
                        };
                        if (dgr.Cells["chisodien"].Value == DBNull.Value)
                            dtoCST.chisodien = null;
                        else dtoCST.chisodien = Convert.ToInt64(dgr.Cells["chisodien"].Value);
                        if (dgr.Cells["chisonuoc"].Value == DBNull.Value)
                            dtoCST.chisonuoc = null;
                        else dtoCST.chisonuoc = Convert.ToInt64(dgr.Cells["chisonuoc"].Value);

                        if (!balCST.CheckCST(dtoCST.maphong, dtoCST.ngaycapnhat))
                            balCST.ThemChiSoThang(dtoCST);
                        else balCST.SuaChiSoThang(dtoCST);
                    }
                }
                MessageBox.Show("Thao tác thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: \n" + ex.ToString(), "Thông báo");
            }
        }

        private void dtpNgayCapNhat_ValueChanged(object sender, EventArgs e)
        {
            dgvPhong.DataSource = balCST.ChiSoTheoThoiGian(balP.GetAll(), dtpNgayCapNhat.Value);
            LoadData();

            if(dgvPhong.SelectedRows.Count !=0 )
            {
                int maphong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["maphong"].Value);
                DTOChiSoThang cstGanNgayNay = balCST.ChiSoGanVoiNgayCanTim(maphong, dtpNgayCapNhat.Value);
                if(cstGanNgayNay != null)
                {
                    dtpNgayGanNhat.Value = cstGanNgayNay.ngaycapnhat;
                    txtSoDienGanNhat.Text = cstGanNgayNay.chisodien.ToString();
                    txtSoNuocGanNhat.Text = cstGanNgayNay.chisonuoc.ToString();
                }
                else
                {
                    txtSoDienGanNhat.Text = txtSoNuocGanNhat.Text = String.Empty;
                }
            }
        }

        //Tìm kiếm

        private void rdbAll_Click(object sender, EventArgs e)
        {
            dgvPhong.DataSource = balCST.ChiSoTheoThoiGian(balP.GetAll(), dtpNgayCapNhat.Value);
            LoadData();
            cboTimkiem.SelectedIndex = 0;
            txtTim.Text = string.Empty;
            rdbAll.Checked = true;
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            dgvPhong.DataSource = balCST.ChiSoTheoThoiGian(balP.SearchP_LP_CP(cboTimkiem.SelectedIndex, txtTim.Text.Trim()), dtpNgayCapNhat.Value);
            rdbSearch.Checked = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dgvPhong.DataSource = balCST.ChiSoTheoThoiGian(balP.SearchP_LP_CP(cboTimkiem.SelectedIndex, txtTim.Text.Trim()), dtpNgayCapNhat.Value);
            rdbSearch.Checked = true;
        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn muốn thoát tác vụ này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                this.Close();
        }

        #region  Kiểm tra nhập số vào textbox
        private void txtSoDien_TextChanged(object sender, EventArgs e)
        {
            string checkString = txtSoDien.Text;
            for(int i=0; i<checkString.Length; i++)
            {
                if (!char.IsNumber(checkString[i]))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtSoDien.Clear();
                    txtSoDien.Focus();
                }
            }
        }

        private void txtSoNuoc_TextChanged(object sender, EventArgs e)
        {
            string checkString = txtSoNuoc.Text;
            for (int i = 0; i < checkString.Length; i++)
            {
                if (!char.IsNumber(checkString[i]))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtSoNuoc.Clear();
                    txtSoNuoc.Focus();
                }
            }
        }
        #endregion
    }
}
