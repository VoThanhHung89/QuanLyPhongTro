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
    public partial class FormChuyenPhongChoHopDong : Form
    {
        public FormChuyenPhongChoHopDong()
        {
            InitializeComponent();
        }
        BAL_LoaiPhong balLP = new BAL_LoaiPhong();
        BAL_Phong balP = new BAL_Phong();
        BAL_HopDong balHD = new BAL_HopDong();

        private void FormChuyenPhongChoHopDong_Load(object sender, EventArgs e)
        {
            cboTimKiem.SelectedIndex = 0;
            //Tải danh sách Phòng.
            foreach (DTOPhong p in balP.GetAll())
            {
                string tenloai = balLP.DetailLoaiPhong(p.maloaiphong).tenloaiphong;
                dgvPhong.Rows.Add(tenloai, p.tenphong, p.maphong);
            }
        }

        private void dgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                txtThongTinPhong.Clear();
                txtThongTinPhong.Text += "Phòng được chọn: " + dgvPhong.Rows[e.RowIndex].Cells["tenphong"].Value.ToString() + Environment.NewLine;
                txtThongTinPhong.Text += Environment.NewLine;

                int maphong = Convert.ToInt32(dgvPhong.Rows[e.RowIndex].Cells["maphong"].Value);
                if (balHD.HopDongHienTai(maphong).mahopdong != 0)
                {
                    txtThongTinPhong.Text += "Đang cho thuê từ: " + balHD.HopDongHienTai(maphong).ngaythue.ToShortDateString() + " đến ";
                    if (balHD.HopDongHienTai(maphong).ngaytra != null)
                        txtThongTinPhong.Text += Convert.ToDateTime(balHD.HopDongHienTai(maphong).ngaytra).ToShortDateString() + Environment.NewLine;
                    else txtThongTinPhong.Text += "( Chưa xác định )" + Environment.NewLine;
                }

                foreach (DTOHopDong hd in balHD.HopDongTrongTuongLai(maphong))
                {
                    if (hd.mahopdong != 0)
                    {
                        txtThongTinPhong.Text += "Sẽ cho thuê từ: " + hd.ngaythue.ToShortDateString() + " đến ";
                        if (hd.ngaytra != null) txtThongTinPhong.Text += Convert.ToDateTime(hd.ngaytra).ToShortDateString() + Environment.NewLine;
                        else txtThongTinPhong.Text += "( Chưa xác định )" + Environment.NewLine;
                    }
                }
            }
        }

        #region Tìm kiếm
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTim.Text))
            {
                dgvPhong.Rows.Clear();
                foreach (DTOPhong p in balP.SearchP_LP_CP(cboTimKiem.SelectedIndex, txtTim.Text.Trim()))
                {
                    string tenloai = balLP.DetailLoaiPhong(p.maloaiphong).tenloaiphong;
                    dgvPhong.Rows.Add(tenloai, p.tenphong, p.maphong);
                }
                chbAll.Checked = false;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTim.Text))
            {
                dgvPhong.Rows.Clear();
                foreach (DTOPhong p in balP.SearchP_LP_CP(cboTimKiem.SelectedIndex, txtTim.Text.Trim()))
                {
                    string tenloai = balLP.DetailLoaiPhong(p.maloaiphong).tenloaiphong;
                    dgvPhong.Rows.Add(tenloai, p.tenphong, p.maphong);
                }
                chbAll.Checked = false;
            }
        }

        private void chbAll_Click(object sender, EventArgs e)
        {
            chbAll.Checked = true;
            txtTim.Text = string.Empty;
            dgvPhong.Rows.Clear();
            foreach (DTOPhong p in balP.GetAll())
            {
                string tenloai = balLP.DetailLoaiPhong(p.maloaiphong).tenloaiphong;
                dgvPhong.Rows.Add(tenloai, p.tenphong, p.maphong);
            }
        }
        #endregion

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
