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
    public partial class FormCuocPhi : Form
    {
        public FormCuocPhi()
        {
            InitializeComponent();
        }
        /// <summary>
        /// -1:Sửa 0:Thêm 1:Xem
        /// </summary>
        public static int state = 0;
        public static int macuoc = -1;
        BAL_CuocPhi balCuoc = new BAL_CuocPhi();

        private void FormCuocPhi_Load(object sender, EventArgs e)
        {
            //Thêm
            if(state == 0)
            {
                txtMaCuocPhi.Text = txtTenCuocPhi.Text = txtThongTin.Text = string.Empty;
                nmrGiaCuoc.Value = 0;
                txtTenCuocPhi.ReadOnly = txtThongTin.ReadOnly = nmrGiaCuoc.ReadOnly = false;
                btnLuu.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                DTOCuocPhi cuoc = balCuoc.DetailCuocPhi(macuoc);
                txtMaCuocPhi.Text = cuoc.macuocphi.ToString();
                txtTenCuocPhi.Text = cuoc.tencuocphi;
                nmrGiaCuoc.Value = cuoc.giacuocphi;
                txtThongTin.Text = cuoc.thongtin;
                //Sửa
                if (state == -1)
                {
                    txtTenCuocPhi.ReadOnly = txtThongTin.ReadOnly = nmrGiaCuoc.ReadOnly = false;
                    btnLuu.Visible = true;
                }
                //Xem
                else
                {
                    txtTenCuocPhi.ReadOnly = txtThongTin.ReadOnly = nmrGiaCuoc.ReadOnly = true;
                    btnLuu.Visible = false;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DTOCuocPhi cuoc = new DTOCuocPhi()
            {
                tencuocphi = txtTenCuocPhi.Text.Trim(),
                giacuocphi = nmrGiaCuoc.Value,
                thongtin = txtThongTin.Text.Trim()
            };
            //Kiểm tra lỗi
            //Có lỗi
            if (txtTenCuocPhi.Text==string.Empty || nmrGiaCuoc.Value<0)
            {
                string loi= "Có lỗi! Bạn không được để trống:";
                loi += "\n- Tên cước phí.";
                loi += "\n- Giá cước phí phải lớn hơn hoặc = 0";
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
                        balCuoc.ThemCuocPhi(cuoc);
                        DialogResult dr = MessageBox.Show("Thêm dữ liệu thành công.\nBạn có muốn tiếp tục thêm thông tin?", "Thông báo", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            txtTenCuocPhi.Text = txtThongTin.Text = string.Empty;
                            nmrGiaCuoc.Value = 0;
                            txtTenCuocPhi.Focus();
                        }
                        else this.Close();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Thêm dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                //Sửa
                else
                {
                    cuoc.macuocphi = macuoc;
                    try
                    {
                        balCuoc.SuaCuocPhi(cuoc);
                        MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo");
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Cập nhật thất bại.\n"+ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenCuocPhi.Text = txtThongTin.Text = string.Empty;
            nmrGiaCuoc.Value = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
