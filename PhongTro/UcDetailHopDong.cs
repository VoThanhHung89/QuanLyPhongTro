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
    public partial class UcDetailHopDong : UserControl
    {
        public UcDetailHopDong()
        {
            InitializeComponent();
        }
        private static UcDetailHopDong _inStance;
        public static UcDetailHopDong InStance
        { 
                get {
                    if (_inStance == null)
                        _inStance = new UcDetailHopDong();
                    return _inStance;
                }
        }
        BAL_ChuPhong balCP = new BAL_ChuPhong();
        BAL_LoaiPhong balLP = new BAL_LoaiPhong();
        BAL_Phong balP = new BAL_Phong();
        BAL_Khach balK = new BAL_Khach();
        BAL_CuocPhi balCuoc = new BAL_CuocPhi();
        BAL_ChiuCuocPhi balCCP = new BAL_ChiuCuocPhi();
        BAL_HopDong balHD = new BAL_HopDong();
        BAL_ThuePhong balTP = new BAL_ThuePhong();

        private void UcDetailHopDong_Load(object sender, EventArgs e)
        {
            foreach(DTOHopDong dtoHD in balHD.GetAll())
            {
                dgvHopDong.Rows.Add(dtoHD.mahopdong, balTP.MaPhongTuMaHopDong(dtoHD.mahopdong),
                                balP.DetailPhong(balTP.MaPhongTuMaHopDong(dtoHD.mahopdong)).tenphong,
                                dtoHD.ngaylamhopdong, dtoHD.ngaythue, dtoHD.ngaytra);
            }
            dgvHopDong.Sort(dgvHopDong.Columns["ngaythue"], ListSortDirection.Descending);
        }

        private void dgvHopDong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHopDong.Rows.Count > 0)
            {
                DataGridViewRow dgr = dgvHopDong.CurrentRow;
                DTOPhong p = balP.DetailPhong(Convert.ToInt32(dgr.Cells["maphong"].Value));
                DTOHopDong hd = balHD.DetailHopDong(Convert.ToInt64(dgr.Cells["mahopdong"].Value));
                Int64 machuthuephong = balTP.MaChuPhong(Convert.ToInt32(dgr.Cells["maphong"].Value), hd.mahopdong);

                rtbHopDong.Clear();

                rtbHopDong.Text = "THÔNG TIN HỢP ĐỒNG THUÊ PHÒNG: " + p.tenphong + Environment.NewLine;
                rtbHopDong.Text += Environment.NewLine;

                if (balHD.GiaTriHopDongVoiNgayHienTai(hd.mahopdong) == -1) rtbHopDong.Text += "HỢP ĐỒNG ĐÃ HẾT HẠN" + Environment.NewLine;
                else if (balHD.GiaTriHopDongVoiNgayHienTai(hd.mahopdong) == 0) rtbHopDong.Text += "HỢP ĐỒNG VẪN CÒN HẠN" + Environment.NewLine;
                else rtbHopDong.Text += "HỢP ĐỒNG VẪN CHƯA ĐẾN NGÀY DÙNG" + Environment.NewLine;

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

                dgvCuocPhi.Rows.Clear();
                foreach (DTOChiuCuocPhi dtoCCP in balCCP.ChiuCuocPhiTuMaHopDong(hd.mahopdong))
                {
                    dgvCuocPhi.Rows.Add(dtoCCP.macuocphi, balCuoc.DetailCuocPhi(dtoCCP.macuocphi).tencuocphi, dtoCCP.soluong, "Xem");
                }
                dgvKhach.Rows.Clear();
                foreach(Int64 makhach in balTP.DanhSachMaKhachTheoMaHopDong(hd.mahopdong))
                {
                    //Hiện ảnh
                    if (balK.DetailKhach(makhach).hinh != null)
                    {
                        Bitmap img = new Bitmap(Image.FromFile(balK.DetailKhach(makhach).hinh), new Size(60, 70));
                        dgvKhach.Rows.Add(img, makhach, balK.DetailKhach(makhach).tenkhach, "Xem");
                    }
                    else dgvKhach.Rows.Add(null, makhach, balK.DetailKhach(makhach).tenkhach, "Xem");
                }
            }
        }

        private void dgvCuocPhi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvCuocPhi.Columns[e.ColumnIndex].Name == "xem_Cuoc" && e.RowIndex > -1)
            {
                FormCuocPhi.state = 1;
                FormCuocPhi.MaCuoc= Convert.ToInt32(dgvCuocPhi.Rows[e.RowIndex].Cells["macuocphi"].Value);
                FormCuocPhi frm = new FormCuocPhi();
                frm.ShowDialog();
            }
        }

        private void dgvKhach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhach.Columns[e.ColumnIndex].Name == "xem_Khach" && e.RowIndex > -1)
            {
                FormDetailKhach.state = 1;
                FormDetailKhach.makhach = Convert.ToInt64(dgvKhach.Rows[e.RowIndex].Cells["makhach"].Value);
                FormDetailKhach frm = new FormDetailKhach();
                frm.Show();
            }
        }
    }
}
