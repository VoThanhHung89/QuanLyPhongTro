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
    public partial class FormPhong : Form
    {
        public FormPhong()
        {
            InitializeComponent();
        }
        public static int state = 0;
        public static int maphong = -1;
        public static int maloai = -1;
        BAL_Phong balP = new BAL_Phong();
        BAL_LoaiPhong balLP = new BAL_LoaiPhong();
        
        private void FormPhong_Load(object sender, EventArgs e)
        {
            //Load Loại Phòng
            cboTenLoaiPhong.DisplayMember = "TenLoaiPhong";
            cboTenLoaiPhong.ValueMember = "MaLoaiPhong";
            cboTenLoaiPhong.DataSource = balLP.GetAll();

            if (maloai != -1) cboTenLoaiPhong.SelectedValue = maloai;
            //Thêm
            if (state ==0)
            {
                txtMaPhong.Text = txtTenPhong.Text = txtTinhTrang.Text = string.Empty;
                txtTenPhong.ReadOnly = txtTinhTrang.ReadOnly = false;
                rdbDaThue.Enabled = rdbTrong.Enabled = true;
                cboTenLoaiPhong.Enabled = true;
                btnLuu.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                DTOPhong p = balP.DetailPhong(maphong);
                txtMaPhong.Text = p.maphong.ToString();
                txtTenPhong.Text = p.tenphong;
                if (p.status) rdbDaThue.Checked = true;
                else rdbTrong.Checked = true;
                txtTinhTrang.Text = p.tinhtrangphong;
                //Sửa
                if (state == -1)
                {
                    txtTenPhong.ReadOnly = txtTinhTrang.ReadOnly = false;
                    rdbDaThue.Enabled = rdbTrong.Enabled = true;
                    cboTenLoaiPhong.Enabled = rdbDaThue.Enabled = rdbTrong.Enabled = true;
                    btnLuu.Visible = true;
                }
                //Xem
                else
                {
                    txtTenPhong.ReadOnly = txtTinhTrang.ReadOnly = true;
                    rdbDaThue.Enabled = rdbTrong.Enabled = false;
                    cboTenLoaiPhong.Enabled = rdbDaThue.Enabled= rdbTrong.Enabled = false;
                    btnLuu.Visible = false;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DTOPhong p = new DTOPhong()
            {
                maloaiphong = Convert.ToInt32(cboTenLoaiPhong.SelectedValue),
                tenphong = txtTenPhong.Text,
                status = ((rdbDaThue.Checked)? true:false),
                tinhtrangphong = txtTinhTrang.Text
            };
            //Kiểm tra lỗi
            //Có lỗi
            if (txtTenPhong.Text == string.Empty)
            {
                string loi = "Có lỗi! Bạn không được để trống:";
                loi += "\n- Tên phòng.";
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
                        balP.ThemPhong(p);
                        DialogResult dr = MessageBox.Show("Thêm dữ liệu thành công.\nBạn có muốn tiếp tục thêm dữ liệu?", "Thông báo", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            txtTenPhong.Text = txtTinhTrang.Text = string.Empty;
                            txtTenPhong.Focus();
                        }
                        else this.Close();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Thêm dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                //Sửa
                else
                {
                    p.maphong = maphong;
                    try
                    {
                        balP.SuaPhong(p);
                        MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo");
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Cập nhật dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenPhong.Text = txtTinhTrang.Text = string.Empty;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
