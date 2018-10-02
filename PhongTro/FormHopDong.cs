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
    public partial class FormHopDong : Form
    {
        public FormHopDong()
        {
            InitializeComponent();
        }
        /// <summary>
        /// -1:Sửa 0:Thêm 1:Xem
        /// </summary>
        public static int state = 0;
        public static Int64 mahopdong = -1;
        public static int maphong = -1;
        BAL_LoaiPhong balLP = new BAL_LoaiPhong();
        BAL_Phong balP = new BAL_Phong();
        BAL_ChiSoThang balCST = new BAL_ChiSoThang();
        BAL_Khach balK = new BAL_Khach();
        BAL_CuocPhi balCuoc = new BAL_CuocPhi();
        BAL_HopDong balHD = new BAL_HopDong();
        BAL_ChiuCuocPhi balCCP = new BAL_ChiuCuocPhi();
        BAL_ThuePhong balTP = new BAL_ThuePhong();
        
        private void LoadThongTin()
        {
            //Thêm
            if (state == 0)
            {
                //Trường hợp chọn Thêm Hợp đồng từ FormChinh
                if (maphong == -1)
                {
                    cboPhong.Enabled = true;
                }
                //Trường hợp Thêm Hợp đồng từ UCHopDong
                else
                {
                    cboPhong.Text = balP.DetailPhong(maphong).tenphong;
                    cboPhong.SelectedValue = maphong;
                    cboPhong.Enabled = false;
                }

                chbNgayLamHD.Enabled = chbNgayTra.Enabled = true;
                dtpNgayLap.Enabled = dtpNgayThue.Enabled = dtpNgayTra.Enabled = true;
                nmrGiaThue.Enabled = nmrTienCoc.Enabled = nmrSoDien.Enabled = nmrSoNuoc.Enabled = true;
                txtGhiChu.ReadOnly = false;
                cboKhachThue.Enabled = true;
                btnThemKhach.Visible = btnThemCuocPhi.Visible = true;
                btnClear.Visible = btnLuuHD.Visible = true;

                DTOPhong p = balP.DetailPhong(Convert.ToInt32(cboPhong.SelectedValue));
                nmrGiaThue.Value = balLP.DetailLoaiPhong(p.maloaiphong).giathue;
                nmrSoDien.Value = Convert.ToInt64(balCST.ChiSoMoiNhat(p.maphong).chisodien);
                nmrSoNuoc.Value = Convert.ToInt64(balCST.ChiSoMoiNhat(p.maphong).chisonuoc);
            }
            //Sửa - Xem
            else
            {
                DTOHopDong hd = balHD.DetailHopDong(mahopdong);
                if (hd.ngaylamhopdong == null) chbNgayLamHD.Checked = true;
                else dtpNgayLap.Value = hd.ngaylamhopdong.GetValueOrDefault();
                dtpNgayThue.Value = hd.ngaythue;
                if (hd.ngaytra == null) chbNgayTra.Checked = true;
                else dtpNgayTra.Value = hd.ngaytra.GetValueOrDefault();
                nmrTienCoc.Value = Convert.ToInt64(hd.tiencoc);
                nmrGiaThue.Value = Convert.ToInt64(hd.giathue);
                nmrSoDien.Value = Convert.ToInt64(hd.chisodien);
                nmrSoNuoc.Value = Convert.ToInt64(hd.chisonuoc);
                txtGhiChu.Text = hd.ghichu;

                cboPhong.SelectedValue = maphong;

                DataTable dtK = new DataTable();
                dtK.Columns.Add("makhach", typeof(Int64));
                dtK.Columns.Add("tenkhach", typeof(string));
                foreach (Int64 makhach in balTP.DanhSachMaKhachTheoMaHopDong(hd.mahopdong))
                {
                    //Taỉ ảnh
                    if (balK.DetailKhach(makhach).hinh != null)
                    {
                        Bitmap img = new Bitmap(Image.FromFile(balK.DetailKhach(makhach).hinh), new Size(60, 70));
                        dgvKhach.Rows.Add(img, balK.DetailKhach(makhach).tenkhach, "Xem", "Xóa", makhach);
                    }
                    else dgvKhach.Rows.Add(null, balK.DetailKhach(makhach).tenkhach, "Xem", "Xóa", makhach);

                    //Tải dữ liệu cho combobox Khách đại diện
                    DataRow dr = dtK.NewRow();
                    dr["makhach"] = makhach;
                    dr["tenkhach"] = balK.DetailKhach(makhach).tenkhach;
                    dtK.Rows.Add(dr);
                }

                cboKhachThue.DisplayMember = "tenkhach";
                cboKhachThue.ValueMember = "makhach";
                cboKhachThue.DataSource = dtK;
                cboKhachThue.SelectedValue = balTP.MaChuPhong(maphong, mahopdong);

                foreach (DTOChiuCuocPhi ccp in balCCP.ChiuCuocPhiTuMaHopDong(hd.mahopdong))
                {
                    dgvCuocPhi.Rows.Add(balCuoc.DetailCuocPhi(ccp.macuocphi).tencuocphi, ccp.soluong, balCuoc.DetailCuocPhi(ccp.macuocphi).giacuocphi, "Xem", "Xóa");
                }
                //Sửa
                if (state == -1)
                {
                    cboPhong.Enabled = false;
                    chbNgayLamHD.Enabled = chbNgayTra.Enabled = true;
                    dtpNgayLap.Enabled = dtpNgayThue.Enabled = dtpNgayTra.Enabled = true;
                    nmrGiaThue.Enabled = nmrTienCoc.Enabled = nmrSoDien.Enabled = nmrSoNuoc.Enabled = true;
                    txtGhiChu.ReadOnly = false;
                    cboKhachThue.Enabled = true;
                    btnThemKhach.Visible = btnThemCuocPhi.Visible = true;
                    btnClear.Visible = btnLuuHD.Visible = true;
                }
                //Xem
                else
                {
                    cboPhong.Enabled = false;
                    chbNgayLamHD.Enabled = chbNgayTra.Enabled = false;
                    dtpNgayLap.Enabled = dtpNgayThue.Enabled = dtpNgayTra.Enabled = false;
                    nmrGiaThue.Enabled = nmrTienCoc.Enabled = nmrSoDien.Enabled = nmrSoNuoc.Enabled = false;
                    txtGhiChu.ReadOnly = true;
                    cboKhachThue.Enabled = false;
                    btnThemKhach.Visible = btnThemCuocPhi.Visible = false;
                    btnClear.Visible = btnLuuHD.Visible = false;
                }
            }
        }

        private void FormHopDong_Load(object sender, EventArgs e)
        {
            //Load Combobox Phòng
            DataTable dtP = new DataTable();
            dtP.Columns.Add("maphong", typeof(int));
            dtP.Columns.Add("tenphong", typeof(string));
            foreach (DTOPhong ph in balP.GetAll())
            {
                DataRow dr = dtP.NewRow();
                dr["maphong"] = ph.maphong;
                dr["tenphong"] = ph.tenphong;
                dtP.Rows.Add(dr);
            }
            cboPhong.DisplayMember = "tenphong";
            cboPhong.ValueMember = "maphong";
            cboPhong.DataSource = dtP;

            LoadThongTin();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if(state == 0)
            chbNgayLamHD.Checked = chbNgayTra.Checked = false;
            dtpNgayLap.Value = dtpNgayThue.Value = dtpNgayTra.Value = DateTime.Now;
            nmrTienCoc.Value = nmrGiaThue.Value = nmrSoDien.Value = nmrSoNuoc.Value = 0;
            txtGhiChu.Text = string.Empty;
            cboKhachThue.DataSource = null;
            dgvKhach.Rows.Clear();
            dgvCuocPhi.Rows.Clear();
        }

        #region Ngày tháng
        private void chbNgayLamHD_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNgayLamHD.Checked) dtpNgayLap.Visible = false;
            else dtpNgayLap.Visible = true;
        }

        private void chbNgayTra_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNgayTra.Checked) dtpNgayTra.Visible = false;
            else dtpNgayTra.Visible = true;
        }
        #endregion

        #region Khách
        private void btnThemKhach_Click(object sender, EventArgs e)
        {
            FormDSKhach.liMaKhach = new List<int>();
            foreach (DataGridViewRow dgr in dgvKhach.Rows)
            {
                FormDSKhach.liMaKhach.Add(Convert.ToInt32(dgr.Cells["makhach"].Value));
            }
            FormDSKhach frm = new FormDSKhach();
            frm.ShowDialog();

            dgvKhach.Rows.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("tenkhach", typeof(string));
            dt.Columns.Add("makhach", typeof(int));
            cboKhachThue.DisplayMember = "tenkhach";
            cboKhachThue.ValueMember = "makhach";
            foreach (int i in FormDSKhach.liMaKhach)
            {
                //Taỉ ảnh
                if (balK.DetailKhach(i).hinh != null)
                {
                    Bitmap img = new Bitmap(Image.FromFile(balK.DetailKhach(i).hinh), new Size(60, 70));
                    dgvKhach.Rows.Add(img, balK.DetailKhach(i).tenkhach, "Xem", "Xóa", balK.DetailKhach(i).makhach);
                }
                else dgvKhach.Rows.Add(null, balK.DetailKhach(i).tenkhach, "Xem", "Xóa", balK.DetailKhach(i).makhach);

                //Tải dữ liệu cho combobox Khách đại diện
                DataRow dr = dt.NewRow();
                dr["makhach"] = i;
                dr["tenkhach"] = balK.DetailKhach(i).tenkhach;
                dt.Rows.Add(dr);
            }
            cboKhachThue.DataSource = dt;
            FormDSKhach.liMaKhach = null;
        }

        private void dgvKhach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhach.Columns[e.ColumnIndex].Name == "xem" && e.RowIndex > -1)
            {
                FormDetailKhach.state = 1;
                FormDetailKhach.makhach = Convert.ToInt32(dgvKhach.Rows[e.RowIndex].Cells["makhach"].Value);
                FormDetailKhach frm = new FormDetailKhach();
                frm.Show();
            }
            else if (dgvKhach.Columns[e.ColumnIndex].Name == "xoa" && e.RowIndex > -1 && state != 1)
            {
                dgvKhach.Rows.RemoveAt(e.RowIndex);
                //Load lai combobox Khách đại diện
                DataTable dt = new DataTable();
                dt.Columns.Add("tenkhach", typeof(string));
                dt.Columns.Add("makhach", typeof(int));
                cboKhachThue.DisplayMember = "tenkhach";
                cboKhachThue.ValueMember = "makhach";
                foreach (DataGridViewRow dgr in dgvKhach.Rows)
                {
                    //Tải dữ liệu cho combobox Khách đại diện
                    DataRow dr = dt.NewRow();
                    dr["makhach"] = Convert.ToInt32(dgr.Cells["makhach"].Value);
                    dr["tenkhach"] = balK.DetailKhach(Convert.ToInt32(dgr.Cells["makhach"].Value)).tenkhach;
                    dt.Rows.Add(dr);
                }
                cboKhachThue.DataSource = dt;
            }
        }
        #endregion

        #region Cước phí
        private void btnThemCuocPhi_Click(object sender, EventArgs e)
        {
            FormDSCuocPhi.dtCP = new DataTable();
            FormDSCuocPhi.dtCP.Columns.Add("macuocphi", typeof(int));
            FormDSCuocPhi.dtCP.Columns.Add("soluong", typeof(int));
            for (int i = 0; i < dgvCuocPhi.Rows.Count; i++)
            {
                DataRow dr = FormDSCuocPhi.dtCP.NewRow();
                dr["macuocphi"] = Convert.ToInt32(dgvCuocPhi.Rows[i].Cells["macuocphi"].Value);
                dr["soluong"] = Convert.ToInt32(dgvCuocPhi.Rows[i].Cells["soluong"].Value);
                FormDSCuocPhi.dtCP.Rows.Add(dr);
            }
            FormDSCuocPhi frm = new FormDSCuocPhi();
            frm.ShowDialog();
            dgvCuocPhi.Rows.Clear();
            foreach (DataRow dr in FormDSCuocPhi.dtCP.Rows)
            {
                dgvCuocPhi.Rows.Add(balCuoc.DetailCuocPhi(Convert.ToInt32(dr["macuocphi"].ToString())).tencuocphi,
                                                            Convert.ToInt32(dr["soluong"].ToString()),
                                                            balCuoc.DetailCuocPhi(Convert.ToInt32(dr["macuocphi"].ToString())).giacuocphi,
                                                            "Xem",
                                                            "Xóa",
                                                            balCuoc.DetailCuocPhi(Convert.ToInt32(dr["macuocphi"].ToString())).macuocphi);
            }
            FormDSCuocPhi.dtCP.Rows.Clear();
        }

        private void dgvCuocPhi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCuocPhi.Columns[e.ColumnIndex].Name == "xoa_Cuoc" && e.RowIndex > -1 && state != 1)
            {
                dgvCuocPhi.Rows.RemoveAt(e.RowIndex);
            }
            else if (dgvCuocPhi.Columns[e.ColumnIndex].Name == "xem_Cuoc" && e.RowIndex > -1)
            {
                FormCuocPhi.state = 1;
                FormCuocPhi.macuoc = Convert.ToInt32(dgvCuocPhi.Rows[e.RowIndex].Cells["macuocphi"].Value);
                FormCuocPhi frm = new FormCuocPhi();
                frm.ShowDialog();
            }
        }

        #endregion

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            DTOHopDong hd = new DTOHopDong();
            hd.ngaythue = dtpNgayThue.Value;
            if (chbNgayTra.Checked) hd.ngaytra = null;
            else hd.ngaytra = dtpNgayTra.Value;
            if (chbNgayLamHD.Checked) hd.ngaylamhopdong = null;
            else hd.ngaylamhopdong = dtpNgayLap.Value;
            hd.tiencoc = Convert.ToInt64(nmrTienCoc.Value);
            hd.giathue = Convert.ToInt64(nmrGiaThue.Value);
            hd.chisodien = Convert.ToInt64(nmrSoDien.Value);
            hd.chisonuoc = Convert.ToInt64(nmrSoNuoc.Value);
            if (txtGhiChu.Text.Trim() == string.Empty) hd.ghichu = null;
            else hd.ghichu = txtGhiChu.Text.Trim();

            try
            {
                //Thêm Hợp đồng.
                if (state == 0)
                {
                    if(balHD.KiemTraHopLeHopDong(hd, balHD.HopDongHienTaiVaTuongLai(Convert.ToInt32(cboPhong.SelectedValue)))  == false)
                    {
                        MessageBox.Show("Với Ngày Thuê như trên thì Phòng không trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        balHD.ThemHopDong(hd);

                        #region Chỉ số tháng của phòng ngay ngày thuê hợp đồng.
                        DTOChiSoThang cst = new DTOChiSoThang()
                        {
                            maphong = Convert.ToInt32(cboPhong.SelectedValue),
                            ngaycapnhat = hd.ngaythue,
                            chisodien = Convert.ToInt64(nmrSoDien.Value),
                            chisonuoc = Convert.ToInt64(nmrSoNuoc.Value)
                        };
                        //Có rồi thì cập nhật.
                        if (balCST.CheckCST(cst.maphong, cst.ngaycapnhat)) balCST.SuaChiSoThang(cst);
                        //Chưa có thì thêm mới.
                        else balCST.ThemChiSoThang(cst);
                        #endregion

                        //Lấy mã hợp đồng.
                        hd.mahopdong = balHD.MaHopDongSearchByAll(hd);

                        #region Thêm Chịu cước phí. 
                        foreach (DataGridViewRow dgr in dgvCuocPhi.Rows)
                        {
                            DTOChiuCuocPhi ccp = new DTOChiuCuocPhi()
                            {
                                mahopdong = hd.mahopdong,
                                macuocphi = Convert.ToInt32(dgr.Cells["macuocphi"].Value),
                                soluong = Convert.ToInt32(dgr.Cells["soluong"].Value)
                            };
                            balCCP.ThemChiuCuocPhi(ccp);
                        }
                        #endregion

                        #region Thêm Thuê Phòng.
                        foreach (DataGridViewRow dgr in dgvKhach.Rows)
                        {
                            DTOThuePhong dtoTP = new DTOThuePhong()
                            {
                                maphong = Convert.ToInt32(cboPhong.SelectedValue.ToString()),
                                makhach = Convert.ToInt64(dgr.Cells["makhach"].Value),
                                mahopdong = hd.mahopdong
                            };
                            if (Convert.ToInt64(cboKhachThue.SelectedValue.ToString()) == dtoTP.makhach) dtoTP.chuphong = true;
                            else dtoTP.chuphong = false;
                            balTP.ThemThuePhong(dtoTP);
                        }
                        #endregion

                        MessageBox.Show("Tạo Hợp đồng mới thành công.", "Thông báo");
                    }
                }
                //Sửa Hợp đồng.
                else if (state == -1)
                {
                    hd.mahopdong = mahopdong;

                    balHD.SuaHopDong(hd);

                    #region Chỉ số tháng của phòng ngay ngày thuê hợp đồng.
                    DTOChiSoThang cst = new DTOChiSoThang()
                    {
                        maphong = Convert.ToInt32(cboPhong.SelectedValue),
                        ngaycapnhat = hd.ngaythue,
                        chisodien = Convert.ToInt64(nmrSoDien.Value),
                        chisonuoc = Convert.ToInt64(nmrSoNuoc.Value)
                    };
                    //Có rồi thì cập nhật.
                    if (balCST.CheckCST(cst.maphong, cst.ngaycapnhat)) balCST.SuaChiSoThang(cst);
                    //Chưa có thì thêm mới.
                    else balCST.ThemChiSoThang(cst);
                    #endregion

                    #region Sửa Chịu cước phí. 
                    List<DTOChiuCuocPhi> liCCP_Moi = new List<DTOChiuCuocPhi>();
                    foreach (DataGridViewRow dgr in dgvCuocPhi.Rows)
                    {
                        DTOChiuCuocPhi ccp = new DTOChiuCuocPhi()
                        {
                            mahopdong = hd.mahopdong,
                            macuocphi = Convert.ToInt32(dgr.Cells["macuocphi"].Value),
                            soluong = Convert.ToInt32(dgr.Cells["soluong"].Value)
                        };
                        liCCP_Moi.Add(ccp);
                    }
                    //Lấy danh sách chịu cước phí cũ.
                    List<DTOChiuCuocPhi> liCCP_Cu = balCCP.ChiuCuocPhiTuMaHopDong(hd.mahopdong);
                    //So sánh list mới và cũ. [Chưa có thì thêm mới-Có thì cập nhật]
                    foreach (DTOChiuCuocPhi ccp_moi in liCCP_Moi)
                    {
                        bool tontai = false;
                        foreach (DTOChiuCuocPhi ccp_cu in liCCP_Cu)
                        {
                            if (ccp_moi.macuocphi == ccp_cu.macuocphi) { tontai = true; break; }
                        }
                        if (tontai == true) balCCP.SuaChiuCuocPhi(ccp_moi);
                        else balCCP.ThemChiuCuocPhi(ccp_moi);
                    }
                    //So sánh list cũ và mới. Nếu mới không có thì xóa của cũ.
                    foreach (DTOChiuCuocPhi ccp_cu in liCCP_Cu)
                    {
                        bool tontai = false;
                        foreach (DTOChiuCuocPhi ccp_moi in liCCP_Moi)
                        {
                            if (ccp_cu.macuocphi == ccp_moi.macuocphi) { tontai = true; break; }
                        }
                        if (tontai == false) balCCP.XoaChiuCuocPhi(ccp_cu);
                    }
                    #endregion

                    #region Sửa Thuê Phòng.
                    List<DTOThuePhong> liTP_Moi = new List<DTOThuePhong>();
                    foreach (DataGridViewRow dgr in dgvKhach.Rows)
                    {
                        DTOThuePhong dtoTP = new DTOThuePhong()
                        {
                            maphong = Convert.ToInt32(cboPhong.SelectedValue.ToString()),
                            makhach = Convert.ToInt64(dgr.Cells["makhach"].Value),
                            mahopdong = hd.mahopdong
                        };
                        if (Convert.ToInt64(cboKhachThue.SelectedValue.ToString()) == dtoTP.makhach) dtoTP.chuphong = true;
                        else dtoTP.chuphong = false;
                        liTP_Moi.Add(dtoTP);
                    }
                    //Thực hiện giống Chịu Cước Phí
                    List<DTOThuePhong> liTP_Cu = balTP.ThuePhongTuMaHopDong(hd.mahopdong);
                    foreach (DTOThuePhong tp_moi in liTP_Moi)
                    {
                        bool tontai = false;
                        foreach (DTOThuePhong tp_cu in liTP_Cu)
                        {
                            if (tp_moi.mahopdong == tp_cu.mahopdong && tp_moi.maphong == tp_cu.maphong && tp_moi.makhach == tp_cu.makhach)
                            { tontai = true; break; }
                        }
                        if (tontai == true) balTP.SuaThuePhong(tp_moi);
                        else balTP.ThemThuePhong(tp_moi);
                    }
                    foreach (DTOThuePhong tp_cu in liTP_Cu)
                    {
                        bool tontai = false;
                        foreach (DTOThuePhong tp_moi in liTP_Moi)
                        {
                            if (tp_moi.mahopdong == tp_cu.mahopdong && tp_moi.maphong == tp_cu.maphong && tp_moi.makhach == tp_cu.makhach)
                            { tontai = true; break; }
                        }
                        if (tontai == false) balTP.XoaThuePhong(tp_cu);
                    }
                    #endregion
                    
                    MessageBox.Show("Cập nhật thông tin Hợp đồng thành công!", "Thông báo");
                }
            }
            catch(Exception ex) { MessageBox.Show("Thao tác thất bại.\n"+ex.ToString(),"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtThongTinPhong.Clear();
            if (balHD.HopDongHienTai(Convert.ToInt32(cboPhong.SelectedValue)).mahopdong != 0)
            {
                txtThongTinPhong.Text += "Đang cho thuê từ: " + balHD.HopDongHienTai(Convert.ToInt32(cboPhong.SelectedValue)).ngaythue.ToShortDateString() + " đến ";
                if (balHD.HopDongHienTai(Convert.ToInt32(cboPhong.SelectedValue)).ngaytra != null)
                    txtThongTinPhong.Text += Convert.ToDateTime(balHD.HopDongHienTai(Convert.ToInt32(cboPhong.SelectedValue)).ngaytra).ToShortDateString() + Environment.NewLine;
                else txtThongTinPhong.Text += "( Chưa xác định )" + Environment.NewLine;
            }
            foreach(DTOHopDong hd in balHD.HopDongTrongTuongLai(Convert.ToInt32(cboPhong.SelectedValue)))
            {
                if (hd.mahopdong != 0)
                {
                    txtThongTinPhong.Text += "Sẽ cho thuê từ: " + hd.ngaythue.ToShortDateString() + " đến ";
                    if (hd.ngaytra != null) txtThongTinPhong.Text += Convert.ToDateTime(hd.ngaytra).ToShortDateString() + Environment.NewLine;
                    else txtThongTinPhong.Text += "( Chưa xác định )" + Environment.NewLine;
                }
            }

            LoadThongTin();
        }
    }
}
