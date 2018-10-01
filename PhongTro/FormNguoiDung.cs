using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using DTO;

namespace PhongTro
{
    public partial class FormNguoiDung : Form
    {
        public FormNguoiDung()
        {
            InitializeComponent();
        }
        /// <summary>
        /// -1:sửa 0:thêm 1:xem 
        /// </summary>
        public static int state = 0;
        public static int manguoidung = -1;
        BAL_NguoiDung balND = new BAL_NguoiDung();

        private void FormNguoiDung_Load(object sender, EventArgs e)
        {
            //Thêm
            if (state == 0)
            {
                txtMaNguoiDung.Text = txtTenDangNhap.Text = txtMaDangNhap.Text = txtNhapLaiMa.Text = string.Empty;
                txtTenDangNhap.ReadOnly = txtMaDangNhap.ReadOnly = txtNhapLaiMa.ReadOnly = false;
                chbHienMK.Enabled = true;
                rdbAdmin.Enabled = rdbUser.Enabled = rdbHoatDong.Enabled = rdbNgungHoatDong.Enabled = true;
                btnLuu.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                DTONguoiDung nd = balND.DetailNguoiDung(manguoidung);
                txtMaNguoiDung.Text = nd.madangnhap.ToString();
                txtTenDangNhap.Text = nd.tendangnhap;
                if (nd.madangnhap != null)
                {
                    txtMaDangNhap.Text = balND.Decrypt(nd.madangnhap);
                    txtNhapLaiMa.Text = balND.Decrypt(nd.madangnhap);
                }
                if (nd.admin) rdbAdmin.Checked = true;
                else rdbUser.Checked = true;
                if (nd.status) rdbHoatDong.Checked = true;
                else rdbNgungHoatDong.Checked = false;
                //Sửa
                if (state == -1)
                {
                    txtTenDangNhap.ReadOnly = txtMaDangNhap.ReadOnly = txtNhapLaiMa.ReadOnly = false;
                    chbHienMK.Enabled = true;
                    rdbAdmin.Enabled = rdbUser.Enabled = rdbHoatDong.Enabled = rdbNgungHoatDong.Enabled = true;
                    btnLuu.Visible = true;
                }
                //Xem
                else 
                {
                    txtTenDangNhap.ReadOnly = txtMaDangNhap.ReadOnly = txtNhapLaiMa.ReadOnly = true;
                    chbHienMK.Enabled = false;
                    rdbAdmin.Enabled = rdbUser.Enabled = rdbHoatDong.Enabled = rdbNgungHoatDong.Enabled = false;
                    btnLuu.Visible = false;
                }
            }
            txtMaDangNhap.UseSystemPasswordChar = txtNhapLaiMa.UseSystemPasswordChar = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DTONguoiDung nd = new DTONguoiDung()
            {
                tendangnhap = txtTenDangNhap.Text.Trim(),
                madangnhap = balND.Encrypt(txtMaDangNhap.Text.Trim()),
                admin = ((rdbAdmin.Checked)? true: false),
                status = ((rdbHoatDong.Checked)? true: false)
            };
            //Kiểm tra dữ liệu
            //Có lỗi
            if (nd.tendangnhap == string.Empty || nd.madangnhap == string.Empty)
            {
                string loi = "Có lỗi! Bạn không được để trống:";
                loi += "\n- Ttên đăng nhập.";
                loi += "\n- Mật khẩu đăng nhập.";
                MessageBox.Show(loi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Mật khẩu nhập lại không trùng
            else if(txtMaDangNhap.Text.Trim() != txtNhapLaiMa.Text.Trim())
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNhapLaiMa.Text = string.Empty;
                txtNhapLaiMa.Focus();
            }
            //Không lỗi
            else
            {
                //Thêm.
                if (state == 0)
                {
                    try
                    {
                        balND.ThemNguoiDung(nd);
                        DialogResult dr = MessageBox.Show("Thêm dữ liệu thành công.\nBạn có muốn tiếp tục thêm dữ liệu?", "Thông báo", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            txtTenDangNhap.Text = txtMaDangNhap.Text = txtNhapLaiMa.Text = string.Empty;
                            txtTenDangNhap.Focus();
                        }
                        else this.Close();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Thêm dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                //Sửa.
                else
                {
                    nd.manguoidung = manguoidung;
                    try
                    {
                        balND.SuaNguoiDung(nd);
                        MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo");
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Cập nhật thất bại.\n"+ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = txtMaDangNhap.Text = txtNhapLaiMa.Text = string.Empty;
            txtTenDangNhap.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHienMK.Checked) 
                txtMaDangNhap.UseSystemPasswordChar = txtNhapLaiMa.UseSystemPasswordChar = false;
            else
                txtMaDangNhap.UseSystemPasswordChar = txtNhapLaiMa.UseSystemPasswordChar = true;
        }
    }
}
