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
    public partial class FormChuPhong : Form
    {
        public FormChuPhong()
        {
            InitializeComponent();
        }
        /// <summary>
        /// -1:sửa 0:thêm 1:xem
        /// </summary>
        public static int state=0;
        /// <summary>
        /// Mã chủ phòng.
        /// </summary>
        public static int machuphong = -1;
        BAL_ChuPhong balCP = new BAL_ChuPhong();

        private void FormChuPhong_Load(object sender, EventArgs e)
        {
            if (state == 0)//Thêm
            {
                txtMaChuPhong.Text = txtTenChuPhong.Text = txtSoDinhDanh.Text = txtSoDienThoai.Text = txtDiaChi.Text = string.Empty;
                txtTenChuPhong.ReadOnly = txtSoDinhDanh.ReadOnly = txtSoDienThoai.ReadOnly = txtDiaChi.ReadOnly = false;
                rdbNam.Enabled = rdbNu.Enabled = true;
                btnLuu.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                DTOChuPhong cp = balCP.DetailChuPhong(machuphong);
                txtMaChuPhong.Text = cp.machuphong.ToString();
                txtTenChuPhong.Text = cp.tenchuphong;
                if(cp.gioitinh) { rdbNam.Checked = true; }
                else rdbNu.Checked = true;
                txtSoDinhDanh.Text = cp.sodinhdanh;
                txtSoDienThoai.Text = cp.sodienthoai;
                txtDiaChi.Text = cp.diachi;
                //Sửa
                if (state == -1)
                {
                    rdbNam.Enabled = rdbNu.Enabled = true;
                    txtTenChuPhong.ReadOnly = txtSoDinhDanh.ReadOnly = txtSoDienThoai.ReadOnly = txtDiaChi.ReadOnly = false;
                    btnLuu.Visible = true;
                }
                //Xem
                else 
                {
                    rdbNam.Enabled = rdbNu.Enabled = false;
                    txtTenChuPhong.ReadOnly = txtSoDinhDanh.ReadOnly = txtSoDienThoai.ReadOnly = txtDiaChi.ReadOnly = true;
                    btnLuu.Visible = false;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DTOChuPhong cp = new DTOChuPhong()
            {
                tenchuphong = txtTenChuPhong.Text.Trim(),
                gioitinh = ((rdbNam.Checked) ? true : false),
                sodinhdanh = txtSoDinhDanh.Text.Trim(),
                sodienthoai = txtSoDienThoai.Text.Trim(),
                diachi = txtDiaChi.Text.Trim()
            };
            //Kiểm tra dữ liệu khi lưu
            //Có lỗi
            if(cp.tenchuphong == string.Empty || cp.sodinhdanh == string.Empty || cp.diachi == string.Empty)
            {
                string loi = "Có lỗi! Bạn không được để trống:";
                loi += "\n- Tên chủ phòng.";
                loi += "\n- Số định danh.";
                loi += "\n- Địa chỉ.";
                MessageBox.Show(loi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Không lỗi
            else
            {
                //Thêm
                if (state == 0)
                {
                    try
                    {
                        balCP.ThemChuPhong(cp);
                        DialogResult dr = MessageBox.Show("Thêm dữ liệu thành công.\nBạn có muốn tiếp tục thêm thông tin mới?", "Thông báo", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            txtTenChuPhong.Text = txtSoDinhDanh.Text = txtSoDienThoai.Text = txtDiaChi.Text = string.Empty;
                            txtTenChuPhong.Focus();
                        }
                        else this.Close();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Thêm dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                //Sửa
                else
                {
                    cp.machuphong = machuphong;
                    try
                    {
                        balCP.SuaChuPhong(cp);
                        MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo");
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Cập nhật thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenChuPhong.Text = txtSoDinhDanh.Text = txtSoDienThoai.Text = txtDiaChi.Text = string.Empty;
            txtTenChuPhong.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
