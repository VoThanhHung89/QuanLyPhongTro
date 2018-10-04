using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;

namespace PhongTro
{
    public partial class UCChuPhong : UserControl
    {
        private static UCChuPhong _inStance;
        public static UCChuPhong InStance
        {
            get {
                if (_inStance == null)
                    _inStance = new UCChuPhong();
                return _inStance;
            }
        }
        public UCChuPhong()
        {
            InitializeComponent();
        }
        BAL_ChuPhong balCP = new BAL_ChuPhong();
        BAL_NguoiDung balND = new BAL_NguoiDung();
        BAL_CuocPhi balCuoc = new BAL_CuocPhi();

        private void LoadData()
        {
            //Load Chủ Phòng
            dgvChuPhong.DataSource = balCP.GetAll();
            cboTim_CP.SelectedIndex = 0;
            //Load Người Dùng
            dgvNguoiDung.DataSource = balND.GetAll();
            //Load Cước Phí
            dgvCuocPhi.DataSource = balCuoc.GetAll();
            cboTim_Cuoc.SelectedIndex = 0;
        }

        private void UCChuPhong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region Chủ Phòng
        private void btnThem_CP_Click(object sender, EventArgs e)
        {
            FormChuPhong.state = 0;
            FormChuPhong frm = new FormChuPhong();
            frm.ShowDialog();
            dgvChuPhong.DataSource = balCP.GetAll();
        }

        private void txtTim_CP_TextChanged(object sender, EventArgs e)
        {
            dgvChuPhong.DataSource = balCP.Search(cboTim_CP.SelectedIndex, txtTim_CP.Text);
        }

        private void btnTim_CP_Click(object sender, EventArgs e)
        {
            dgvChuPhong.DataSource = balCP.Search(cboTim_CP.SelectedIndex, txtTim_CP.Text);
        }

        private void dgvChuPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChuPhong.Columns[e.ColumnIndex].Name == "xem_CP" && e.RowIndex > -1)//Xem
            {
                FormChuPhong.state = 1;
                FormChuPhong.MaChuPhong = Convert.ToInt32(dgvChuPhong.Rows[e.RowIndex].Cells["machuphong_CP"].Value);
                FormChuPhong frm = new FormChuPhong();
                frm.ShowDialog();
                dgvChuPhong.DataSource = balCP.GetAll();
            }
            else if (dgvChuPhong.Columns[e.ColumnIndex].Name == "sua_CP" && e.RowIndex > -1)//Sửa
            {
                FormChuPhong.state = -1;
                FormChuPhong.MaChuPhong = Convert.ToInt32(dgvChuPhong.Rows[e.RowIndex].Cells["machuphong_CP"].Value);
                FormChuPhong frm = new FormChuPhong();
                frm.ShowDialog();
                dgvChuPhong.DataSource = balCP.GetAll();
            }
            else if (dgvChuPhong.Columns[e.ColumnIndex].Name == "xoa_CP" && e.RowIndex > -1)//Xóa
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa dữ liệu trên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    try
                    {
                        balCP.XoaChuphong(Convert.ToInt32(dgvChuPhong.Rows[e.RowIndex].Cells["machuphong_CP"].Value));
                        MessageBox.Show("Xóa dữ liệu thành công.", "Thông báo");
                        dgvChuPhong.DataSource = balCP.GetAll();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Người Dùng

        private void btnThem_ND_Click(object sender, EventArgs e)
        {
            FormNguoiDung.state = 0;
            FormNguoiDung frm = new FormNguoiDung();
            frm.ShowDialog();
            dgvNguoiDung.DataSource = balND.GetAll();
        }

        private void txtTim_ND_TextChanged(object sender, EventArgs e)
        {
            dgvNguoiDung.DataSource = balND.Search(txtTim_ND.Text);
        }

        private void btnTim_ND_Click(object sender, EventArgs e)
        {
            dgvNguoiDung.DataSource = balND.Search(txtTim_ND.Text);
        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNguoiDung.Columns[e.ColumnIndex].Name == "xem_ND" && e.RowIndex > -1)//Xem
            {
                FormNguoiDung.state = 1;
                FormNguoiDung.MaNguoiDung = Convert.ToInt32(dgvNguoiDung.Rows[e.RowIndex].Cells["manguoidung"].Value);
                FormNguoiDung frm = new FormNguoiDung();
                frm.ShowDialog();
                dgvNguoiDung.DataSource = balND.GetAll();
            }
            else if (dgvNguoiDung.Columns[e.ColumnIndex].Name == "sua_ND" && e.RowIndex > -1)//Sửa
            {
                FormNguoiDung.state = -1;
                FormNguoiDung.MaNguoiDung = Convert.ToInt32(dgvNguoiDung.Rows[e.RowIndex].Cells["manguoidung"].Value);
                FormNguoiDung frm = new FormNguoiDung();
                frm.ShowDialog();
                dgvNguoiDung.DataSource = balND.GetAll();
            }
            else if (dgvNguoiDung.Columns[e.ColumnIndex].Name == "xoa_ND" && e.RowIndex > -1)//Xóa
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa dữ liệu trên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    try
                    {
                        balND.XoaNguoiDung(Convert.ToInt32(dgvNguoiDung.Rows[e.RowIndex].Cells["manguoidung"].Value));
                        MessageBox.Show("Xóa dữ liệu thành công.", "Thông báo");
                        dgvNguoiDung.DataSource = balND.GetAll();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Xóa dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }
        #endregion

        #region Cước Phí

        private void btnThem_Cuoc_Click(object sender, EventArgs e)
        {
            FormCuocPhi.state = 0;
            FormCuocPhi frm = new FormCuocPhi();
            frm.ShowDialog();
            dgvCuocPhi.DataSource = balCuoc.GetAll();
        }

        private void txtTim_Cuoc_TextChanged(object sender, EventArgs e)
        {
            dgvCuocPhi.DataSource = balCuoc.Search(cboTim_Cuoc.SelectedIndex, txtTim_Cuoc.Text.Trim());
        }

        private void btnTim_Cuoc_Click(object sender, EventArgs e)
        { 
            dgvCuocPhi.DataSource = balCuoc.Search(cboTim_Cuoc.SelectedIndex, txtTim_Cuoc.Text.Trim());
        }

        private void dgvCuocPhi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCuocPhi.Columns[e.ColumnIndex].Name == "xem_Cuoc" && e.RowIndex > -1)//Xem
            {
                FormCuocPhi.state = 1;
                FormCuocPhi.MaCuoc = Convert.ToInt32(dgvCuocPhi.Rows[e.RowIndex].Cells["macuocphi"].Value);
                FormCuocPhi frm = new FormCuocPhi();
                frm.ShowDialog();
                dgvCuocPhi.DataSource = balCuoc.GetAll();
            }
            else if (dgvCuocPhi.Columns[e.ColumnIndex].Name == "sua_Cuoc" && e.RowIndex > -1)//Sửa
            {
                FormCuocPhi.state = -1;
                FormCuocPhi.MaCuoc = Convert.ToInt32(dgvCuocPhi.Rows[e.RowIndex].Cells["macuocphi"].Value);
                FormCuocPhi frm = new FormCuocPhi();
                frm.ShowDialog();
                dgvCuocPhi.DataSource = balCuoc.GetAll();
            }
            else if (dgvCuocPhi.Columns[e.ColumnIndex].Name == "xoa_Cuoc" && e.RowIndex > -1)//Xóa
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa dữ liệu trên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    try
                    {
                        balCuoc.XoaCuocPhi(Convert.ToInt32(dgvCuocPhi.Rows[e.RowIndex].Cells["macuocphi"].Value));
                        MessageBox.Show("Xóa dữ liệu thành công.", "Thông báo");
                        dgvCuocPhi.DataSource = balCuoc.GetAll();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Xóa dữ liệu thất bại.\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }
        #endregion
    }
}
