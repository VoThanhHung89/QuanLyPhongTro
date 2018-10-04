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
    public partial class FormChiSoThang_Detail : Form
    {
        public FormChiSoThang_Detail()
        {
            InitializeComponent();
        }
        BAL_ChuPhong balCP = new BAL_ChuPhong();
        BAL_LoaiPhong balLP = new BAL_LoaiPhong();
        BAL_Phong balP = new BAL_Phong();
        BAL_ChiSoThang balCST = new BAL_ChiSoThang();
        public static int MaPhongCST;

        private void ClearBinding()
        {
            dtpNgayCapNhat.DataBindings.Clear();
            txtSoDien.DataBindings.Clear();
            txtSoNuoc.DataBindings.Clear();
        }

        private void LoadData()
        {
            lblTenPhong.Text = balP.DetailPhong(MaPhongCST).tenphong;
            lblTenLoai.Text = balLP.DetailLoaiPhong(balP.DetailPhong(MaPhongCST).maloaiphong).tenloaiphong;
            lblTenChu.Text = balCP.DetailChuPhong(balLP.DetailLoaiPhong(balP.DetailPhong(MaPhongCST).maloaiphong).machuphong).tenchuphong;
            dgvPhong.DataSource = balCST.ChiSoTheoMaPhongAllTime(MaPhongCST);
            if (dgvPhong.Rows.Count > 0)
            {
                ClearBinding();
                dtpNgayCapNhat.DataBindings.Add("Value", dgvPhong.DataSource, "ngaycapnhat");
                txtSoDien.DataBindings.Add("Text", dgvPhong.DataSource, "chisodien");
                txtSoNuoc.DataBindings.Add("Text", dgvPhong.DataSource, "chisonuoc");
            }
        }

        private void FormChiSoThang_Detail_Load(object sender, EventArgs e)
        {
            LoadData();
            //Setting Control
            dtpNgayCapNhat.Enabled = txtSoDien.Enabled = txtSoNuoc.Enabled = false;
            btnLamLai.Visible = btnLuu.Visible = false;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Setting Control
            dtpNgayCapNhat.Enabled = txtSoDien.Enabled = txtSoNuoc.Enabled = true;
            btnLamLai.Visible = btnLuu.Visible = true;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
            
            dtpNgayCapNhat.Value = DateTime.Now;

            ClearBinding();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Setting Control
            dtpNgayCapNhat.Enabled = txtSoDien.Enabled = txtSoNuoc.Enabled = true;
            btnLamLai.Visible = btnLuu.Visible = true;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;

            ClearBinding();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(DialogResult.OK == MessageBox.Show("Bạn muốn xóa thông tin trên?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                DTOChiSoThang dtoCST = new DTOChiSoThang()
                {
                    maphong = MaPhongCST,
                    ngaycapnhat = dtpNgayCapNhat.Value
                };
                balCST.XoaChiSoThang(dtoCST);
                MessageBox.Show("Xóa thông tin thành công.","Thông báo");
                LoadData();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DTOChiSoThang dtoCST = new DTOChiSoThang()
            {
                maphong = MaPhongCST,
                ngaycapnhat = dtpNgayCapNhat.Value,
                chisodien = Convert.ToInt64(txtSoDien.Text),
                chisonuoc = Convert.ToInt64(txtSoNuoc.Text)
            };
            //Thêm
            if (!balCST.CheckCST(MaPhongCST, dtpNgayCapNhat.Value))
            {
                try { balCST.ThemChiSoThang(dtoCST); MessageBox.Show("Thêm dữ liệu thành công.", "Thông báo"); }
                    catch(Exception ex) { MessageBox.Show("Thêm dữ liệu thất bại."+ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            //Sửa
            else
            {
                if (DialogResult.OK == MessageBox.Show("Tiến hành cập nhật thông tin Điện - Nước", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                try { balCST.SuaChiSoThang(dtoCST); MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo"); }
                    catch (Exception ex) { MessageBox.Show("Cập nhật dữ liệu thất bại." + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            
            LoadData();
            //Setting Control
            dtpNgayCapNhat.Enabled = txtSoDien.Enabled = txtSoNuoc.Enabled = false;
            btnLamLai.Visible = btnLuu.Visible = false;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = true;
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            LoadData();
            //Setting Control
            dtpNgayCapNhat.Enabled = txtSoDien.Enabled = txtSoNuoc.Enabled = false;
            btnLamLai.Visible = btnLuu.Visible = false;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Kiểm tra nhập số
        private void txtSoDien_TextChanged(object sender, EventArgs e)
        {
            string checkString = txtSoDien.Text;
            for(int i=0; i< checkString.Length; i++)
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
