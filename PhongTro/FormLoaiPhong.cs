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
    public partial class FormLoaiPhong : Form
    {
        public FormLoaiPhong()
        {
            InitializeComponent();
        }
        /// <summary>
        /// -1:Sửa 0:Thêm 1:Xem
        /// </summary>
        public static int state = 0;
        public static int maloai = -1;
        public static int machu = -1;
        BAL_LoaiPhong balLP = new BAL_LoaiPhong();
        BAL_ChuPhong balCP = new BAL_ChuPhong();

        private void FormLoaiPhong_Load(object sender, EventArgs e)
        {
            //Load Chủ Phòng
            cboTenChu.DisplayMember = "TenChuPhong";
            cboTenChu.ValueMember = "MaChuPhong";
            cboTenChu.DataSource = balCP.GetAll();

            //Thêm
            if (state ==0)
            {
                txtMaLoaiPhong.Text = txtTenLoai.Text = txtThongTin.Text = txtDiaChi.Text = string.Empty;
                nmrGiaThue.Value = nmrSoKhach.Value = 0;
                txtTenLoai.ReadOnly = txtThongTin.ReadOnly = txtDiaChi.ReadOnly = nmrGiaThue.ReadOnly = nmrSoKhach.ReadOnly = false;
                cboTenChu.Enabled = true;
                btnLuu.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                DTOLoaiPhong lp = balLP.DetailLoaiPhong(maloai);
                txtMaLoaiPhong.Text = lp.maloaiphong.ToString();
                txtTenLoai.Text = lp.tenloaiphong;
                nmrGiaThue.Value = lp.giathue;
                nmrSoKhach.Value = lp.sokhach;
                txtThongTin.Text = lp.thongtin;
                txtDiaChi.Text = lp.diachi;

                cboTenChu.SelectedValue = lp.machuphong;

                //Sửa
                if (state == -1)
                {
                    txtTenLoai.ReadOnly = txtThongTin.ReadOnly = txtDiaChi.ReadOnly = nmrGiaThue.ReadOnly = nmrSoKhach.ReadOnly = false;
                    cboTenChu.Enabled = true;
                    btnLuu.Visible = true;
                }
                //Xem
                else
                {
                    txtTenLoai.ReadOnly = txtThongTin.ReadOnly = txtDiaChi.ReadOnly = nmrGiaThue.ReadOnly = nmrSoKhach.ReadOnly = true;
                    cboTenChu.Enabled = false;
                    btnLuu.Visible = false;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DTOLoaiPhong lp = new DTOLoaiPhong()
            {
                machuphong = Convert.ToInt32(cboTenChu.SelectedValue),
                tenloaiphong = txtTenLoai.Text,
                giathue = Convert.ToDecimal(nmrGiaThue.Value),
                sokhach = Convert.ToInt32(nmrSoKhach.Value),
                thongtin = txtThongTin.Text,
                diachi = txtDiaChi.Text
            };
            //Kiểm tra lỗi
            //Có lỗi
            if(txtTenLoai.Text== string.Empty||nmrGiaThue.Value<0||nmrSoKhach.Value<0)
            {
                string loi = "Có lỗi! Bạn không được để trống:";
                loi += "\n- Tên loại.";
                loi += "\n- Giá thuê phải lớn hơn hoặc = 0.";
                loi += "\n- Số khách phải lớn hơn hoặc = 0.";
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
                        balLP.ThemLoaiPhong(lp);
                        DialogResult dr = MessageBox.Show("Thêm dữ liệu thành công.\nBạn có muốn thêm thông tin?", "Thông báo", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            txtTenLoai.Text = txtThongTin.Text = txtDiaChi.Text = string.Empty;
                            nmrGiaThue.Value = nmrSoKhach.Value = 0;
                            txtTenLoai.Focus();
                        }
                        else this.Close();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Thêm dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                //Sửa
                else
                {
                    lp.maloaiphong = Convert.ToInt32(txtMaLoaiPhong.Text);
                    try
                    {
                        balLP.SuaLoaiPhong(lp);
                        MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo");
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Cập nhật dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenLoai.Text = txtThongTin.Text = txtDiaChi.Text = string.Empty;
            nmrGiaThue.Value = nmrSoKhach.Value = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
