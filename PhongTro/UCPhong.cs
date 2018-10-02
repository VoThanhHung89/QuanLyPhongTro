using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BAL;

namespace PhongTro
{
    public partial class UCPhong : UserControl
    {
        private static UCPhong _inStance;
        public static UCPhong InStance
        {
            get
            {
                if (_inStance == null)
                    _inStance = new UCPhong();
                return _inStance;
            }
        }
        public UCPhong()
        {
            InitializeComponent();
        }
        BAL_LoaiPhong balLP = new BAL_LoaiPhong();
        BAL_Phong balP = new BAL_Phong();
        BAL_ChuPhong balCP = new BAL_ChuPhong();

        private void UCPhong_Load(object sender, EventArgs e)
        {
            //Load cboTenChuPhong
            cboTenChuPhong.DisplayMember = "TenChuPhong";
            cboTenChuPhong.ValueMember = "MaChuPhong";
            cboTenChuPhong.DataSource = balCP.GetAll();
            //Load Loại Phòng
            if (cboTenChuPhong.Items.Count > 0)
                dgvLoaiPhong.DataSource = balLP.GetAllByMaChu(Convert.ToInt32(cboTenChuPhong.SelectedValue.ToString()));

            cboTim_LP.SelectedIndex = 0;
            //Load cboLoaiPhong
            cboLoaiPhong.DisplayMember = "TenLoaiPhong";
            cboLoaiPhong.ValueMember = "MaLoaiPhong";
            cboLoaiPhong.DataSource = balLP.GetAll();
            //Load Phòng
            if (dgvLoaiPhong.RowCount > 0)
                dgvPhong.DataSource = balP.GetAllByMaLoai(Convert.ToInt32(dgvLoaiPhong.CurrentRow.Cells["maloaiphong_LP"].Value));
        }

        #region Loại Phòng
        private void btnThem_LP_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboTenChuPhong.Items.Count > 0)
                {
                    FormLoaiPhong.state = 0;
                    FormLoaiPhong.machu = Convert.ToInt32(cboTenChuPhong.SelectedValue);
                    FormLoaiPhong frm = new FormLoaiPhong();
                    frm.ShowDialog();
                    dgvLoaiPhong.DataSource = balLP.GetAllByMaChu(Convert.ToInt32(cboTenChuPhong.SelectedValue));
                    cboLoaiPhong.DataSource = balLP.GetAll();
                }
            }catch (Exception ex) { MessageBox.Show("Lỗi: \n"+ex.ToString(),"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtTim_LP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvLoaiPhong.DataSource = balLP.Search(Convert.ToInt32(cboTenChuPhong.SelectedValue), cboTim_LP.SelectedIndex, txtTim_LP.Text.Trim());
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnTim_LP_Click(object sender, EventArgs e)
        {
            try
            {
                dgvLoaiPhong.DataSource = balLP.Search(Convert.ToInt32(cboTenChuPhong.SelectedValue), cboTim_LP.SelectedIndex, txtTim_LP.Text.Trim());
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvLoaiPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvLoaiPhong.Columns[e.ColumnIndex].Name == "xem_LP" && e.RowIndex > -1)//Xem
            {
                FormLoaiPhong.state = 1;
                FormLoaiPhong.maloai = Convert.ToInt32(dgvLoaiPhong.Rows[e.RowIndex].Cells["maloaiphong_LP"].Value);
                FormLoaiPhong.machu = Convert.ToInt32(dgvLoaiPhong.Rows[e.RowIndex].Cells["machuphong_LP"].Value);
                FormLoaiPhong frm = new FormLoaiPhong();
                frm.ShowDialog();
                dgvLoaiPhong.DataSource = balLP.GetAllByMaChu(Convert.ToInt32(cboTenChuPhong.SelectedValue));
            }
            else if (dgvLoaiPhong.Columns[e.ColumnIndex].Name == "sua_LP" && e.RowIndex > -1)//sửa
            {
                FormLoaiPhong.state = -1;
                FormLoaiPhong.maloai = Convert.ToInt32(dgvLoaiPhong.Rows[e.RowIndex].Cells["maloaiphong_LP"].Value);
                FormLoaiPhong.machu = Convert.ToInt32(dgvLoaiPhong.Rows[e.RowIndex].Cells["machuphong_LP"].Value);
                FormLoaiPhong frm = new FormLoaiPhong();
                frm.ShowDialog();
                dgvLoaiPhong.DataSource = balLP.GetAllByMaChu(Convert.ToInt32(cboTenChuPhong.SelectedValue));
            }
            else if (dgvLoaiPhong.Columns[e.ColumnIndex].Name == "xoa_LP" && e.RowIndex > -1)//Xóa
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa dữ liệu trên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    try
                    {
                        balLP.XoaLoaiPhong(Convert.ToInt32(dgvLoaiPhong.Rows[e.RowIndex].Cells["maloaiphong_LP"].Value));
                        MessageBox.Show("Xóa dữ liệu thành công.", "Thông báo");
                        dgvLoaiPhong.DataSource = balLP.GetAllByMaChu(Convert.ToInt32(cboTenChuPhong.SelectedValue));
                        cboLoaiPhong.DataSource = balLP.GetAll();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Xóa dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void dgvLoaiPhong_SelectionChanged(object sender, EventArgs e)
        {
            cboLoaiPhong.Text = dgvLoaiPhong.CurrentRow.Cells["tenloaiphong"].Value.ToString();
        }
        #endregion

        #region Phòng
        private void btnThem_P_Click(object sender, EventArgs e)
        {
            if (dgvLoaiPhong.RowCount>0)
            {
                FormPhong.state = 0;
                FormPhong.maloai = Convert.ToInt32(cboLoaiPhong.SelectedValue);
                FormPhong frm = new FormPhong();
                frm.ShowDialog();
                dgvPhong.DataSource = balP.GetAllByMaLoai(Convert.ToInt32(dgvLoaiPhong.CurrentRow.Cells["maloaiphong_LP"].Value));
            }
        }

        private void cboLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPhong.DataSource = balP.GetAllByMaLoai(Convert.ToInt32(cboLoaiPhong.SelectedValue.ToString()));
            chbTatCaPhong.Checked = false;
        }

        private void txtTim_P_TextChanged(object sender, EventArgs e)
        {
            dgvPhong.DataSource = balP.Search(Convert.ToInt32(dgvLoaiPhong.CurrentRow.Cells["maloaiphong_LP"].Value), txtTim_P.Text.Trim());
        }

        private void btnTim_P_Click(object sender, EventArgs e)
        {
            dgvPhong.DataSource = balP.Search(Convert.ToInt32(dgvLoaiPhong.CurrentRow.Cells["maloaiphong_LP"].Value), txtTim_P.Text.Trim());
        }

        private void dgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhong.Columns[e.ColumnIndex].Name == "doiphong" && e.RowIndex > -1)//Quản lý thuê phòng
            {
                FormChuyenPhong.maphongOld= Convert.ToInt32(dgvPhong.Rows[e.RowIndex].Cells["maphong"].Value);
                FormChuyenPhong frm = new FormChuyenPhong();
                frm.ShowDialog();
            }
            else if (dgvPhong.Columns[e.ColumnIndex].Name == "chisothang" && e.RowIndex > -1)//Số điện - nước
            {
                FormChiSoThang_Detail.maphongDetail = Convert.ToInt32(dgvPhong.Rows[e.RowIndex].Cells["maphong"].Value);
                FormChiSoThang_Detail frm = new FormChiSoThang_Detail();
                frm.ShowDialog();
            }
            else if (dgvPhong.Columns[e.ColumnIndex].Name == "xem_P" && e.RowIndex > -1)//Xem
            {
                FormPhong.state = 1;
                FormPhong.maphong = Convert.ToInt32(dgvPhong.Rows[e.RowIndex].Cells["maphong"].Value);
                FormPhong.maloai = Convert.ToInt32(dgvPhong.Rows[e.RowIndex].Cells["maloaiphong_P"].Value);
                FormPhong frm = new FormPhong();
                frm.ShowDialog();
            }
            else if (dgvPhong.Columns[e.ColumnIndex].Name == "sua_P" && e.RowIndex > -1)//sửa
            {
                FormPhong.state = -1;
                FormPhong.maphong = Convert.ToInt32(dgvPhong.Rows[e.RowIndex].Cells["maphong"].Value);
                FormPhong.maloai = Convert.ToInt32(dgvPhong.Rows[e.RowIndex].Cells["maloaiphong_P"].Value);
                FormPhong frm = new FormPhong();
                frm.ShowDialog();
                dgvPhong.DataSource = balP.GetAllByMaLoai(Convert.ToInt32(cboLoaiPhong.SelectedValue));
            }
            else if (dgvPhong.Columns[e.ColumnIndex].Name == "xoa_P" && e.RowIndex > -1)//Xóa
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa dữ liệu trên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    try
                    {
                        balP.XoaPhong(Convert.ToInt32(dgvPhong.Rows[e.RowIndex].Cells["maphong"].Value));
                        MessageBox.Show("Xóa dữ liệu thành công.", "Thông báo");
                        dgvPhong.DataSource = balP.GetAllByMaLoai(Convert.ToInt32(cboLoaiPhong.SelectedValue));
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Xóa dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void btnDienNuoc_Click(object sender, EventArgs e)
        {
            FormChiSoThang_All frm = new FormChiSoThang_All();
            frm.ShowDialog();
        }
        #endregion

        private void chbTatCaPhong_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTatCaPhong.Checked)
            {
                chbTatCaPhong.Checked = true;
                dgvPhong.DataSource = balP.GetAll();
            }
            else
            {
                dgvPhong.DataSource = balP.GetAllByMaLoai(Convert.ToInt32(cboLoaiPhong.SelectedValue.ToString()));
            }
        }
    }
}
