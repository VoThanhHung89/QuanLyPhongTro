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
    public partial class UCKhach : UserControl
    {
        private static UCKhach _inStance;
        public static UCKhach InStance
        {
            get
            {
                if (_inStance == null)
                    _inStance = new UCKhach();
                return _inStance;
            }
        }
        public UCKhach()
        {
            InitializeComponent();
        }
        // Dùng -18 để loại PhongTro/bin/debug
        private string pathNoPic = System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().Length - 18) + @"Image\Customer_96px.png";
        private string pathPic = System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().Length - 18) + @"Image\Customer\";
        //Thông tin ảnh sau khi nhấn nút tải ảnh
        private string picSource = string.Empty;
        private string picName = string.Empty;
        BAL_Khach balK = new BAL_Khach();
        BAL_LoaiPhong balLP = new BAL_LoaiPhong();
        BAL_Phong balP = new BAL_Phong();
        BAL_HopDong balHD = new BAL_HopDong();
        BAL_ThuePhong balTP = new BAL_ThuePhong();

        private void BindingGridView()
        {
            if (dgvKhach.RowCount > 0)
            {
                DTOKhach k = balK.DetailKhach(Convert.ToInt64(dgvKhach.CurrentRow.Cells["makhach"].Value));

                txtTenKhach.Text = k.tenkhach;
                if (k.hinh != null)
                {
                    //Trường hợp laod ảnh thành công.
                    try
                    {
                        ptbAnh.Image = Image.FromFile(k.hinh);
                    }
                    //Trường hợp load ảnh thất bại.
                    catch(Exception ex)
                    {
                        MessageBox.Show("Tải ảnh thất bại.\n"+ex.ToString(),"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ptbAnh.Image = Image.FromFile(pathNoPic);
                    }
                }
                else ptbAnh.Image = Image.FromFile(pathNoPic);

                dgvPhong.Rows.Clear();
                foreach(DTOThuePhong tp in balTP.ThuePhongTuMaKhach(k.makhach))
                {
                    string tenphong = balP.DetailPhong(tp.maphong).tenphong;
                    string tenloaiphong = balLP.DetailLoaiPhong(balP.DetailPhong(tp.maphong).maloaiphong).tenloaiphong;
                    string vaitro, giatrihopdong;
                    if (tp.chuphong) vaitro = "Chủ phòng";
                    else vaitro = "Thuê cùng";
                    if (balHD.DetailHopDong(tp.mahopdong).status) giatrihopdong = "Hợp đồng còn hạn";
                    else giatrihopdong = "Hợp đồng đã hết hạn";
                    dgvPhong.Rows.Add(tenloaiphong, tenphong, giatrihopdong,vaitro,tp.mahopdong, tp.maphong, "Xem hợp đồng");
                }
            }
            else
            {
                ptbAnh.Image = Image.FromFile(pathNoPic);
                txtTenKhach.Text = string.Empty; 
            }
        }

        private void UCKhach_Load(object sender, EventArgs e)
        {
            cboTim.SelectedIndex = 0;
            dgvKhach.DataSource = balK.GetAll();
       
            BindingGridView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormDetailKhach.state = 0;
            FormDetailKhach.makhach = -1;
            FormDetailKhach frm = new FormDetailKhach();
            frm.ShowDialog();
        
            dgvKhach.DataSource = balK.GetAll();
            BindingGridView();
        }

        #region Ảnh
        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opFile = new OpenFileDialog { Filter = "JPEG|*.jpg|PNG|*.png|BMP|*.bmp", ValidateNames = true, Multiselect = false })
            {
                if(opFile.ShowDialog() == DialogResult.OK)
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
            catch(Exception ex) { MessageBox.Show("Lỗi: \n"+ ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Tìm kiếm
        private void cboTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTim.SelectedIndex == 1)
            {
                FormSearchDate.ngaytim = string.Empty;
                FormSearchDate frm = new FormSearchDate();
                frm.ShowDialog();
                txtTim.Text = FormSearchDate.ngaytim;
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvKhach.DataSource = balK.Search(cboTim.SelectedIndex, txtTim.Text.Trim());
                BindingGridView();
            }
            catch(Exception ex) { MessageBox.Show("Lỗi:\n"+ex.ToString(),"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                dgvKhach.DataSource = balK.Search(cboTim.SelectedIndex, txtTim.Text.Trim());
                BindingGridView();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi:\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        private void dgvKhach_SelectionChanged(object sender, EventArgs e)
        {
            BindingGridView();
        }

        private void dgvKhach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvKhach.Columns[e.ColumnIndex].Name == "xem" && e.RowIndex > -1)
            {
                FormDetailKhach.state = 1;
                FormDetailKhach.makhach = Convert.ToInt64(dgvKhach.Rows[e.RowIndex].Cells["makhach"].Value);
                FormDetailKhach frm = new FormDetailKhach();
                frm.ShowDialog();
            }
            else if (dgvKhach.Columns[e.ColumnIndex].Name == "sua" && e.RowIndex > -1)
            {
                FormDetailKhach.state = -1;
                FormDetailKhach.makhach = Convert.ToInt64(dgvKhach.Rows[e.RowIndex].Cells["makhach"].Value);
                FormDetailKhach frm = new FormDetailKhach();
                frm.ShowDialog();
            }
            else if (dgvKhach.Columns[e.ColumnIndex].Name == "xoa" && e.RowIndex > -1)
            {
                string UserPic = balK.DetailKhach(Convert.ToInt64(dgvKhach.CurrentRow.Cells["makhach"].Value)).hinh;
                try
                {
                    balK.XoaKhach(Convert.ToInt64(dgvKhach.CurrentRow.Cells["makhach"].Value));
                    //Xóa ảnh
                    //try
                    //{
                    //    Image img = Image.FromFile(UserPic);
                    //    img.Dispose();
                    //    System.IO.File.Delete(UserPic);
                    //}
                    //catch(Exception ex) { MessageBox.Show("Không thể xóa ảnh.\n"+ex.ToString(),"Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex) { MessageBox.Show("Xóa dữ liệu thất bại!\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                //Load lại dữ liệu
                dgvKhach.DataSource = balK.GetAll();
                BindingGridView();
            }
        }
    }
}
