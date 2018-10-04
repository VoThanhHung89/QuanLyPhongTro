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
    public partial class FormHopDongCuaPhong : Form
    {
        public FormHopDongCuaPhong()
        {
            InitializeComponent();
        }
        BAL_Khach balK = new BAL_Khach();
        BAL_LoaiPhong balLP = new BAL_LoaiPhong();
        BAL_Phong balP = new BAL_Phong();
        BAL_ThuePhong balTP = new BAL_ThuePhong();
        BAL_HopDong balHD = new BAL_HopDong();
        public static int MaPhong;

        private void FormChuyenPhong_Load(object sender, EventArgs e)
        {
            lblPhong.Text = "[ " + balP.DetailPhong(MaPhong).tenphong + " ]";
            //Tải hợp đồng hiện tại và tương lai của phòng
            dgvHopDong.Rows.Clear();
            foreach(Int64 MaHopDong in balTP.DanhSachMaHopDongTheoMaPhong(MaPhong))
            {
                DTOHopDong hd = balHD.DetailHopDong(MaHopDong);
                string GiaTri = "Đã hết hạn";
                if (balHD.GiaTriHopDongVoiNgayHienTai(MaHopDong) == 0) GiaTri = "Đang sử dụng";
                if (balHD.GiaTriHopDongVoiNgayHienTai(MaHopDong) == 1) GiaTri = "Chưa đến ngày dùng";
                dgvHopDong.Rows.Add("Xem", "Sửa", GiaTri, MaHopDong, hd.ngaylamhopdong, hd.ngaythue, hd.ngaytra, balK.DetailKhach(balTP.MaChuPhong(MaPhong, MaHopDong)).tenkhach);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHopDong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvHopDong.Columns[e.ColumnIndex].Name == "xem" && e.RowIndex > -1)
            {
                FormHopDong.state = 1;
                FormHopDong.maphong = MaPhong;
                FormHopDong.mahopdong = Convert.ToInt64(dgvHopDong.Rows[e.RowIndex].Cells["mahopdong"].Value);
                FormHopDong frm = new FormHopDong();
                frm.ShowDialog();
            }
            else if (dgvHopDong.Columns[e.ColumnIndex].Name == "sua" && e.RowIndex > -1)
            {
                FormHopDong.state = -1;
                FormHopDong.maphong = MaPhong;
                FormHopDong.mahopdong = Convert.ToInt64(dgvHopDong.Rows[e.RowIndex].Cells["mahopdong"].Value);
                FormHopDong frm = new FormHopDong();
                frm.ShowDialog();
            }
        }
    }
}
