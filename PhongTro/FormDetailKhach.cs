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
    public partial class FormDetailKhach : Form
    {
        public FormDetailKhach()
        {
            InitializeComponent();
        }
        BAL_Khach balK = new BAL_Khach();
        public static int state = -1;
        public static Int64 makhach;
        // Dùng -18 để loại PhongTro/bin/debug
        private string pathNoPic = System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().Length - 18) + @"Image\Customer_96px.png";
        private string pathPic = System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().Length - 18) + @"Image\Customer\";
        //Thông tin ảnh sau khi nhấn nút tải ảnh
        private string picSource = string.Empty;
        private string picName = string.Empty;

        private void FormDetailKhach_Load(object sender, EventArgs e)
        {
            if(state == 0)
            {
                btnTaiAnh.Visible = btnXoaAnh.Visible = btnClear.Visible = btnLuu.Visible = true;
                txtTenKhach.ReadOnly = txtSoDinhDanh.ReadOnly = txtSDT.ReadOnly = txtDiaChi.ReadOnly = false;
                grbGioiTinh.Enabled = grbHonNhan.Enabled = grbTamTru.Enabled = grbTrangThai.Enabled = true;
                ptbAnh.Image = Image.FromFile(pathNoPic);
                dtpNgaySinh.Enabled = true;
            }
            else
            {
                DTOKhach k = balK.DetailKhach(makhach);
                if (k.hinh != null) ptbAnh.Image = Image.FromFile(k.hinh);
                else ptbAnh.Image = Image.FromFile(pathNoPic);
                txtTenKhach.Text = k.tenkhach;
                txtSoDinhDanh.Text = k.sodinhdanh;
                if (k.gioitinh == true) rdbNam.Checked = true;
                txtSDT.Text = k.sodienthoai;
                dtpNgaySinh.Value = k.ngaysinh;
                if (k.tinhtranghonnhan == true) rdbDaKetHon.Checked = true;
                if (k.dangkytamtru == true) rdbDaDangKy.Checked = true;
                if (k.status == true) rdbDangThue.Checked = true;
                txtDiaChi.Text = k.diachi;
                if (state == -1)
                {
                    btnTaiAnh.Visible = btnXoaAnh.Visible = btnClear.Visible = btnLuu.Visible = true;
                    txtTenKhach.ReadOnly = txtSoDinhDanh.ReadOnly = txtSDT.ReadOnly = txtDiaChi.ReadOnly = false;
                    grbGioiTinh.Enabled = grbHonNhan.Enabled = grbTamTru.Enabled = grbTrangThai.Enabled = true;
                    dtpNgaySinh.Enabled = true; 
                }
                else
                {
                    btnTaiAnh.Visible = btnXoaAnh.Visible = btnClear.Visible = btnLuu.Visible = false;
                    txtTenKhach.ReadOnly = txtSoDinhDanh.ReadOnly = txtSDT.ReadOnly = txtDiaChi.ReadOnly = true;
                    grbGioiTinh.Enabled = grbHonNhan.Enabled = grbTamTru.Enabled = grbTrangThai.Enabled = false;
                    dtpNgaySinh.Enabled = false;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ptbAnh.Image = Image.FromFile(pathNoPic);
            picSource = pathNoPic;
            txtTenKhach.Text = string.Empty;
            txtSoDinhDanh.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Thao tác thêm hoặc sửa
            try
            {
                //Kiểm tra lỗi
                //Có lỗi
                if (txtTenKhach.Text.Trim() == string.Empty || txtSoDinhDanh.Text.Trim() == String.Empty)
                {
                    string loi = "Có lỗi! Bạn không được để trống:";
                    loi += "\n- Tên khách.";
                    loi += "\n- Số định danh.";
                    MessageBox.Show(loi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Không lỗi
                else
                {
                    //Thêm
                    if (state == 0)
                    {
                        DTOKhach k = new DTOKhach()
                        {
                            tenkhach = txtTenKhach.Text,
                            ngaysinh = dtpNgaySinh.Value,
                            gioitinh = ((rdbNam.Checked) ? true : false),
                            sodinhdanh = txtSoDinhDanh.Text,
                            sodienthoai = txtSDT.Text,
                            diachi = txtDiaChi.Text,
                            tinhtranghonnhan = ((rdbDaKetHon.Checked) ? true : false),
                            dangkytamtru = ((rdbDaDangKy.Checked) ? true : false),
                            status = ((rdbDangThue.Checked) ? true : false)
                        };
                        //Thông tin Ảnh
                        //Có Chọn Ảnh
                        if (picSource != string.Empty)
                        {
                            if (!System.IO.File.Exists(pathPic + picName))//Nếu chưa có thì chép vào.
                                System.IO.File.Copy(picSource, pathPic + picName);

                            picSource = pathPic + picName;
                        }
                        //Không chọn ảnh
                        else
                            picSource = pathNoPic;
                        k.hinh = picSource;
                        //Thêm khách
                        try
                        {
                            balK.ThemKhach(k);
                            DialogResult dr = MessageBox.Show("Thêm dữ liệu thành công.\nBạn có muốn tiếp tục thêm Khách?", "Thông báo", MessageBoxButtons.YesNo);
                            if (dr == DialogResult.Yes)
                            {
                                ptbAnh.Image = Image.FromFile(pathNoPic);
                                picSource = pathNoPic;
                                txtTenKhach.Text = string.Empty;
                                txtSoDinhDanh.Text = string.Empty;
                                txtSDT.Text = string.Empty;
                                txtDiaChi.Text = string.Empty;
                                txtTenKhach.Focus();
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thêm dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //Sửa
                    else if (state == -1)
                    {
                        DTOKhach k = new DTOKhach()
                        {
                            tenkhach = txtTenKhach.Text,
                            ngaysinh = dtpNgaySinh.Value,
                            gioitinh = ((rdbNam.Checked) ? true : false),
                            sodinhdanh = txtSoDinhDanh.Text,
                            sodienthoai = txtSDT.Text,
                            diachi = txtDiaChi.Text,
                            tinhtranghonnhan = ((rdbDaKetHon.Checked) ? true : false),
                            dangkytamtru = ((rdbDaDangKy.Checked) ? true : false),
                            status = ((rdbDangThue.Checked) ? true : false)
                        };
                        //Thông tin ảnh cũ của khách
                        string picOld = balK.DetailKhach(makhach).hinh;
                        //Thông tin Ảnh
                        if (picSource != pathNoPic && picSource != string.Empty)//Có chọn ảnh
                        {
                            if (!System.IO.File.Exists(pathPic + picName))//Nếu chưa có thì chép vào
                                System.IO.File.Copy(picSource, pathPic + picName);//Chép ảnh

                            picSource = pathPic + picName;
                        }
                        if (picSource == string.Empty)
                            picSource = picOld;
                        k.hinh = picSource;
                        //Sửa khách
                        try
                        {
                            balK.SuaKhach(k);
                            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Cập nhật dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            //Load lại dữ liệu
            
        }

        #region Ảnh
        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opFile = new OpenFileDialog { Filter = "JPEG|*.jpg|PNG|*.png|BMP|*.bmp", ValidateNames = true, Multiselect = false })
            {
                if (opFile.ShowDialog() == DialogResult.OK)
                {
                    picSource = opFile.FileName;
                    picName = opFile.SafeFileName;
                    ptbAnh.Image = Image.FromFile(picSource);
                }
            }
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            try
            {
                ptbAnh.Image = Image.FromFile(pathNoPic);
                picSource = pathNoPic;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

    }
}
