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
    public partial class UCHopDongThue : UserControl
    {
        public UCHopDongThue()
        {
            InitializeComponent();
        }
        private static UCHopDongThue _inStance;
        public static UCHopDongThue InStance
        {
            get
            {
                if (_inStance == null)
                    _inStance = new UCHopDongThue();
                return _inStance;
            }
        }
        BAL_ChuPhong balCP = new BAL_ChuPhong();
        BAL_LoaiPhong balLP = new BAL_LoaiPhong();
        BAL_Phong balP = new BAL_Phong();
        BAL_Khach balK = new BAL_Khach();
        BAL_ThuePhong balTP = new BAL_ThuePhong();
        BAL_HopDong balHD = new BAL_HopDong();
        BAL_ChiSoThang balCST = new BAL_ChiSoThang();
        BAL_CuocPhi balCuoc = new BAL_CuocPhi();
        BAL_ChiuCuocPhi balCCP = new BAL_ChiuCuocPhi();

        private void UCHopDongThue_Load(object sender, EventArgs e)
        {
            cboTimKiem.SelectedIndex = 0;
            //Tải danh sách Phòng.
            foreach (DTOPhong p in balP.GetAll())
            {
                string tenloai = balLP.DetailLoaiPhong(p.maloaiphong).tenloaiphong;
                dgvPhong.Rows.Add(tenloai, p.tenphong, p.maphong);
            }
        }

        private void TaiThongTinHopDong()
        {
            int maphong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["maphong"].Value);
            DTOPhong p = balP.DetailPhong(maphong);
            DTOHopDong hd = balHD.HopDongHienTai(maphong);
            Int64 machuthuephong = balTP.MaChuPhong(maphong, hd.mahopdong);

            #region Tải thông tin hợp đồng

            rtbHopDong.Clear();

            rtbHopDong.Text = "THÔNG TIN HỢP ĐỒNG THUÊ PHÒNG: " + p.tenphong + Environment.NewLine;
            if (hd.ngaylamhopdong == null) rtbHopDong.Text += Environment.NewLine + "Ngày làm Hợp đồng thuê: (Không có.)" + Environment.NewLine;
            else rtbHopDong.Text += Environment.NewLine + "Ngày làm Hợp đồng thuê: " + Convert.ToDateTime(hd.ngaylamhopdong).ToShortDateString() + Environment.NewLine;
            if (hd.ngaytra == null) rtbHopDong.Text += "Ngày thuê phòng từ: " + hd.ngaythue.ToShortDateString() + " đến ngày (Không có.)" + Environment.NewLine;
            else rtbHopDong.Text += "Ngày thuê phòng từ: " + hd.ngaythue.ToShortDateString() + " đến ngày " + Convert.ToDateTime(hd.ngaytra).ToShortDateString() + Environment.NewLine;
            rtbHopDong.Text += Environment.NewLine;
            rtbHopDong.Text += "Người thuê phòng: " + balK.DetailKhach(machuthuephong).tenkhach + Environment.NewLine;
            rtbHopDong.Text += Environment.NewLine;
            rtbHopDong.Text += "Tiền cọc khi thuê phòng: " + string.Format("{0:#,##0.##}", hd.tiencoc) + Environment.NewLine;
            rtbHopDong.Text += "Giá thuê phòng: " + string.Format("{0:#,##0.##}", hd.giathue) + Environment.NewLine;
            rtbHopDong.Text += Environment.NewLine;
            rtbHopDong.Text += "Chỉ số điện của phòng lúc làm hợp đồng thuê: " + string.Format("{0:#,##0.##}", hd.chisodien) + Environment.NewLine;
            rtbHopDong.Text += "Chỉ số nước của phòng lúc làm hợp đồng thuê: " + string.Format("{0:#,##0.##}", hd.chisonuoc) + Environment.NewLine;
            rtbHopDong.Text += "Ghi chú của hợp đồng: " + hd.ghichu + Environment.NewLine;
            rtbHopDong.Text += Environment.NewLine;

            rtbHopDong.Text += "Danh sách các loại cước phí mà khách thuê phải trả: (" + balCCP.ChiuCuocPhiTuMaHopDong(hd.mahopdong).Count.ToString() + " loại)" + Environment.NewLine;
            rtbHopDong.Text += "============================================" + Environment.NewLine;
            int socuoc = 1;
            rtbHopDong.Text += "STT" + "\t" + "Tên cước phí" + "\t" +"\t" + "\t" + "Số lượng" + "\t" + "Giá cước" + Environment.NewLine;
            rtbHopDong.Text += "============================================" + Environment.NewLine;
            foreach (DTOChiuCuocPhi ccp in balCCP.ChiuCuocPhiTuMaHopDong(hd.mahopdong))
            {
                DTOCuocPhi cp = balCuoc.DetailCuocPhi(ccp.macuocphi);
                rtbHopDong.Text += socuoc.ToString() + "\t" + cp.tencuocphi.ToUpper();

                if (cp.tencuocphi.ToUpper().Length > 12) rtbHopDong.Text += "\t" + "\t" ;
                else rtbHopDong.Text += "\t" + "\t" + "\t";

                rtbHopDong.Text += ccp.soluong.ToString();

                rtbHopDong.Text += "\t" + "\t" + string.Format("{0:#,##0.##}", cp.giacuocphi) + Environment.NewLine;
                socuoc += 1;
            }
            rtbHopDong.Text += "-------------------------------------------------------------------------------" + Environment.NewLine;
            rtbHopDong.Text += Environment.NewLine;

            rtbHopDong.Text += "Danh sách Khách đang thuê phòng: (" + balTP.DanhSachMaKhachTheoMaHopDong(hd.mahopdong).Count.ToString() + " người)" + Environment.NewLine;
            rtbHopDong.Text += "==========================================================" + Environment.NewLine;
            int sokhach = 1;
            rtbHopDong.Text += "STT" + "\t" + "Tên khách" + "\t" + "\t" +"\t" + "\t" + "Giới Tính" + "\t" + "Số định danh" + Environment.NewLine;
            rtbHopDong.Text += "==========================================================" + Environment.NewLine;
            foreach (Int64 makhach in balTP.DanhSachMaKhachTheoMaHopDong(hd.mahopdong))
            {
                DTOKhach k = balK.DetailKhach(makhach);
                rtbHopDong.Text += sokhach.ToString() + "\t" + k.tenkhach.ToUpper();

                if (k.tenkhach.ToUpper().Length > 17) rtbHopDong.Text += "\t";
                else if (k.tenkhach.ToUpper().Length > 17) rtbHopDong.Text += "\t" + "\t" ;
                else if (k.tenkhach.ToUpper().Length > 12) rtbHopDong.Text += "\t" + "\t" + "\t" ;
                else rtbHopDong.Text += "\t" + "\t" + "\t" + "\t" ;

                if (k.gioitinh) rtbHopDong.Text += "Nam" ;
                else rtbHopDong.Text += "Nữ" ;

                rtbHopDong.Text += "\t" + "\t" + k.sodinhdanh.ToString() + Environment.NewLine;
                sokhach += 1;
            }
            rtbHopDong.Text += "---------------------------------------------------------------------------------------------------------" + Environment.NewLine;
            #endregion
        }

        private void dgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            //Tải các thông tin liên quan đến Phòng: Thông tin Phòng + DS Hợp Đồng cũ + Tải HĐ còn hiệu lực.
            if (dgvPhong.CurrentRow.Index > -1)
            {
                int maphong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["maphong"].Value);
                DTOPhong p = balP.DetailPhong(maphong);
                int maloaiphong = balP.DetailPhong(maphong).maloaiphong;
                DTOLoaiPhong lp = balLP.DetailLoaiPhong(maloaiphong);
                int machuphong = balLP.DetailLoaiPhong(maloaiphong).machuphong;
                DTOChuPhong cp = balCP.DetailChuPhong(machuphong);

                #region Thông tin phòng trên Textbox
                lblTieuDe.Text = @"PHÒNG:  [ " + p.tenphong + @" ]";
                lblLSHopDong.Text = @"Các hợp đồng thuê trước đây của phòng: [ " + p.tenphong + @" ]";

                string thongtin = string.Empty;
                thongtin += "Tên chủ phòng: " + cp.tenchuphong + Environment.NewLine;
                thongtin += "Tên loại phòng: " + lp.tenloaiphong + Environment.NewLine;
                thongtin += "Tên phòng: " + p.tenphong + Environment.NewLine;
                thongtin += Environment.NewLine;
                if (p.status)
                    thongtin += "Trạng thái phòng: ĐANG CHO THUÊ" + Environment.NewLine;

                else
                    thongtin += "Trạng thái phòng: CÒN TRỐNG" + Environment.NewLine;
                thongtin += Environment.NewLine;
                thongtin += "Giá thuê: " + string.Format("{0:#,##0.##}", lp.giathue) + Environment.NewLine;
                thongtin += "Số khách ở tối đa: " + lp.sokhach + Environment.NewLine;
                thongtin += "Thông tin: " + lp.thongtin + Environment.NewLine;
                thongtin += "Địa chỉ: " + lp.diachi + Environment.NewLine;
                thongtin += "Tình trạng phòng: " + p.tinhtrangphong;

                txtThongTinPhong.Text = thongtin;
                #endregion

                //Tải thông tin hợp đồng đang còn hiệu lực.
                if (p.status) TaiThongTinHopDong();
                else
                {
                    rtbHopDong.Clear();
                    rtbHopDong.Text = "HIỆN TẠI PHÒNG CÒN TRỐNG.";
                }
                
                //Load danh sách lịch sử hợp đồng.
                dgvHopDong.Rows.Clear();
                foreach (Int64 mahopdong in balTP.DanhSachMaHopDongTheoMaPhong(p.maphong))
                {
                    DTOHopDong hd = balHD.DetailHopDong(mahopdong);
                    string giatriHD = "Đã hết hạn";
                    if (balHD.GiaTriHopDongVoiNgayHienTai(hd.mahopdong) == 0) giatriHD = "Còn hạn dùng";
                    if (balHD.GiaTriHopDongVoiNgayHienTai(hd.mahopdong) == 1) giatriHD = "Chưa đến ngày dùng";

                    dgvHopDong.Rows.Add("Xem", hd.mahopdong, hd.ngaylamhopdong, hd.ngaythue, hd.ngaytra,
                                    hd.tiencoc, hd.giathue, giatriHD, "Chuyển", "Sửa", "Xóa");
                }
                dgvHopDong.Sort(dgvHopDong.Columns["ngaythue"], ListSortDirection.Descending);
            }
            if (dgvPhong.SelectedRows.Count == 0) txtThongTinPhong.Text = string.Empty;
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            FormHopDong.state = 0;
            FormHopDong.maphong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["maphong"].Value);
            FormHopDong frm = new FormHopDong();
            frm.ShowDialog();
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            int maphong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["maphong"].Value);
            if(balHD.HopDongHienTai(maphong).mahopdong != 0)
            {
                FormHopDong.state = -1;
                FormHopDong.maphong = maphong;
                FormHopDong.mahopdong = balHD.HopDongHienTai(maphong).mahopdong;
                FormHopDong frm = new FormHopDong();
                frm.ShowDialog();
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

        //Xem hợp đồng thuê cũ.
        private void dgvHopDong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHopDong.Columns[e.ColumnIndex].Name == "xem" && e.RowIndex > -1)
            {
                FormHopDong.state = 1;
                FormHopDong.maphong= Convert.ToInt32(dgvPhong.CurrentRow.Cells["maphong"].Value);
                FormHopDong.mahopdong = Convert.ToInt64(dgvHopDong.Rows[e.RowIndex].Cells["mahopdong"].Value);
                FormHopDong frm = new FormHopDong();
                frm.ShowDialog();
            }
            else if (dgvHopDong.Columns[e.ColumnIndex].Name == "chuyenphong" && e.RowIndex > -1)
            {
                if (dgvHopDong.Rows[e.RowIndex].Cells["giatrihopdong"].Value.ToString() != "Đã hết hạn")
                {
                    FormChuyenPhongChoHopDong frm = new FormChuyenPhongChoHopDong();
                    frm.ShowDialog();
                }
                else MessageBox.Show("Thao tác bị từ chối vì Hợp đồng đã hết hạn.", "Thông báo");
            }
            else if (dgvHopDong.Columns[e.ColumnIndex].Name == "sua" && e.RowIndex > -1)
            {
                if (dgvHopDong.Rows[e.RowIndex].Cells["giatrihopdong"].Value.ToString() != "Đã hết hạn")
                {
                    Int64 mahopdong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["maphong"].Value);
                    int maphong = balTP.MaPhongTuMaHopDong(mahopdong);

                    FormHopDong.state = -1;
                    FormHopDong.maphong = maphong;
                    FormHopDong.mahopdong = mahopdong;
                    FormHopDong frm = new FormHopDong();
                    frm.ShowDialog();
                }
                else MessageBox.Show("Thao tác bị từ chối vì Hợp đồng đã hết hạn.", "Thông báo");
            }
            else if (dgvHopDong.Columns[e.ColumnIndex].Name == "xoa" && e.RowIndex > -1)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa thông tin Hợp đồng trên và các thông tin liên quan?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    try
                    {
                        balHD.XoaHopDong(Convert.ToInt64(dgvHopDong.Rows[e.RowIndex].Cells["mahopdong"].Value));
                        MessageBox.Show("Xóa thông tin thành công.");

                        dgvHopDong.Rows.RemoveAt(e.RowIndex);

                        int maphong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["maphong"].Value);
                        DTOPhong p = balP.DetailPhong(maphong);
                        if (p.status)
                        {
                            btnSuaHD.Visible = true;
                            btnTaoHD.Visible = false;
                            TaiThongTinHopDong();
                        }
                        else
                        {
                            btnSuaHD.Visible = false;
                            btnTaoHD.Visible = true;
                            rtbHopDong.Clear();
                            rtbHopDong.Text = "HIỆN TẠI PHÒNG CÒN TRỐNG.";
                        }
                    }
                    catch(Exception ex) { MessageBox.Show("Xóa thông tin thất bại.\n"+ ex.ToString(), "Thông báo"); }
                }
            }
        }
    }
}
