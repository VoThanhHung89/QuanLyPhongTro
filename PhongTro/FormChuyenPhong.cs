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
    public partial class FormChuyenPhong : Form
    {
        public FormChuyenPhong()
        {
            InitializeComponent();
        }
        BAL_Khach balK = new BAL_Khach();
        BAL_LoaiPhong balLP = new BAL_LoaiPhong();
        BAL_Phong balP = new BAL_Phong();
        BAL_ThuePhong balTP = new BAL_ThuePhong();
        BAL_HopDong balHD = new BAL_HopDong();
        public static int maphongOld;

        private void FormChuyenPhong_Load(object sender, EventArgs e)
        {
            cboTimKiem.SelectedIndex = 0;
            //Tải hợp đồng hiện tại và tương lai của phòng
            dgvHopDong.Rows.Clear();
            DTOHopDong hd = balHD.HopDongHienTai(maphongOld);
            if (hd.mahopdong != 0)
            {
                string TenChuThuePhongHienTai = balK.DetailKhach(balTP.MaChuPhong(maphongOld, hd.mahopdong)).tenkhach;
                dgvHopDong.Rows.Add(false, hd.mahopdong, hd.ngaylamhopdong, hd.ngaythue, hd.ngaytra, TenChuThuePhongHienTai);
            }
            foreach(DTOHopDong hdtl in balHD.HopDongTrongTuongLai(maphongOld))
            {
                string TenChuThuePhongTuongLai = balK.DetailKhach(balTP.MaChuPhong(maphongOld, hdtl.mahopdong)).tenkhach;
                dgvHopDong.Rows.Add(false, hd.mahopdong, hdtl.ngaylamhopdong, hdtl.ngaythue, hdtl.ngaytra, TenChuThuePhongTuongLai);
            }
            //Tải danh sách Phòng.
            foreach (DTOPhong p in balP.GetAll())
            {
                if(p.maphong != maphongOld)
                {
                    string tenloai = balLP.DetailLoaiPhong(p.maloaiphong).tenloaiphong;
                    dgvPhong.Rows.Add(false , tenloai, p.tenphong, p.maphong);
                }
            }
        }

        private void dgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvPhong.Columns[e.ColumnIndex].Name == "chon" && e.RowIndex > -1)
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
                foreach(DataGridViewRow dgr in dgvPhong.Rows)
                {
                    if (dgr.Index == e.RowIndex)
                        dgr.Cells["chon"].Value = true;
                    else dgr.Cells["chon"].Value = false;
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
                    if (p.maphong != maphongOld)
                    {
                        string tenloai = balLP.DetailLoaiPhong(p.maloaiphong).tenloaiphong;
                        dgvPhong.Rows.Add( false , tenloai, p.tenphong, p.maphong);
                    }
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
                    if(p.maphong != maphongOld)
                    {
                        string tenloai = balLP.DetailLoaiPhong(p.maloaiphong).tenloaiphong;
                        dgvPhong.Rows.Add( false , tenloai, p.tenphong, p.maphong);
                    }
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
                if (p.maphong != maphongOld)
                {
                    string tenloai = balLP.DetailLoaiPhong(p.maloaiphong).tenloaiphong;
                    dgvPhong.Rows.Add( false , tenloai, p.tenphong, p.maphong);
                }
            }
        }
        #endregion

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
