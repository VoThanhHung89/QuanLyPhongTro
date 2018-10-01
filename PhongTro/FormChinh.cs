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
    public partial class FormChinh : Form
    {
        public FormChinh()
        {
            InitializeComponent();
        }
        BAL_HopDong balHD = new BAL_HopDong();
        BAL_Khach balK = new BAL_Khach();

        private void FormChinh_Load(object sender, EventArgs e)
        {
            lblTieuDe.Text = "[ CHƯƠNG TRÌNH QUẢN LÝ PHÒNG TRỌ]";
            //Cập nhật thông tin.
            try
            {
                balHD.CapNhatStatus();
                balK.CapNhatStatusAll();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        #region Tổng Quan
        private void mniThemUser_Click(object sender, EventArgs e)
        {
            FormNguoiDung.state = 0;
            FormNguoiDung frm = new FormNguoiDung();
            frm.ShowDialog();
        }

        private void mniExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Chủ Phòng
        private void mniChuPhong_Click(object sender, EventArgs e)
        {
            pnlBottom.Controls.Add(UCChuPhong.InStance);
            UCChuPhong.InStance.BringToFront();
            lblTieuDe.Text = @"CHỦ PHÒNG TRỌ > THÔNG TIN QUẢN LÝ [ CHỦ PHÒNG - NGƯỜI DÙNG - CƯỚC PHÍ ]";
        }

        private void mniThemChuPhong_Click(object sender, EventArgs e)
        {
            FormChuPhong.state = 0;
            FormChuPhong frm = new FormChuPhong();
            frm.ShowDialog();
        }
        #endregion

        #region Phòng
        private void mniPhongTro_Click(object sender, EventArgs e)
        {
            pnlBottom.Controls.Add(UCPhong.InStance);
            UCPhong.InStance.BringToFront();
            lblTieuDe.Text = @"PHÒNG TRỌ > THÔNG TIN PHÒNG TRỌ [ LOẠI PHÒNG TRỌ - PHÒNG TRỌ ]";
        }

        private void mniThemLoaiPhong_Click(object sender, EventArgs e)
        {
            FormLoaiPhong.state = 0;
            FormLoaiPhong frm = new FormLoaiPhong();
            frm.ShowDialog();
        }

        private void mniThemPhong_Click(object sender, EventArgs e)
        {
            FormPhong.state = 0;
            FormPhong frm = new FormPhong();
            frm.ShowDialog();
        }

        private void mniThemCuocPhi_Click(object sender, EventArgs e)
        {
            FormCuocPhi.state = 0;
            FormCuocPhi frm = new FormCuocPhi();
            frm.ShowDialog();
        }

        private void mniCapNhatDienNuoc_Click(object sender, EventArgs e)
        {
            FormChiSoThang_All frm = new FormChiSoThang_All();
            frm.ShowDialog();
        }
        #endregion

        #region Khách
        private void mniKhachThue_Click(object sender, EventArgs e)
        {
            pnlBottom.Controls.Add(UCKhach.InStance);
            UCKhach.InStance.BringToFront();
            lblTieuDe.Text = @"KHÁCH THUÊ TRỌ > THÔNG TIN KHÁCH THUÊ";
        }

        private void mniThemKhach_Click(object sender, EventArgs e)
        {
            FormDetailKhach.state = 0;
            FormDetailKhach.makhach = -1;
            FormDetailKhach frm = new FormDetailKhach();
            frm.ShowDialog();
        }
        #endregion

        #region Hợp Đồng Thuê
        private void mniThongTinHopDong_Click(object sender, EventArgs e)
        {
            pnlBottom.Controls.Add(UCHopDongThue.InStance);
            UCHopDongThue.InStance.BringToFront();
            lblTieuDe.Text = @"HỢP ĐỒNG THUÊ TRỌ > THÔNG TIN HỢP ĐỒNG THUÊ";
        }

        private void mniDSHopDong_Click(object sender, EventArgs e)
        {
            pnlBottom.Controls.Add(UcDetailHopDong.InStance);
            UcDetailHopDong.InStance.BringToFront();
            lblTieuDe.Text = @"HỢP ĐỒNG THUÊ TRỌ > DANH SÁCH HỢP ĐỒNG";
        }

        private void mniTaoHopDong_Click(object sender, EventArgs e)
        {
            FormHopDong.state = 0;
            FormHopDong.mahopdong = -1;
            FormHopDong frm = new FormHopDong();
            frm.ShowDialog();
        }
        #endregion
        
    }
}
