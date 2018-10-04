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
    public partial class FormDSCuocPhi : Form
    {
        public FormDSCuocPhi()
        {
            InitializeComponent();
        }
        BAL_CuocPhi balCP = new BAL_CuocPhi();
        public static DataTable dtCP;

        private void FormDSCuocPhi_Load(object sender, EventArgs e)
        {
            foreach(DTOCuocPhi cp in balCP.GetAll())
            {
                string chon = "Chọn";
                int soluong = 0;
                foreach (DataRow dr in dtCP.Rows)
                {
                    if (Convert.ToInt32(dr["macuocphi"].ToString()) == cp.macuocphi)
                    {
                        chon = "Đã chọn";
                        soluong = Convert.ToInt32(dr["soluong"].ToString());
                    }
                }
                dgvCuocPhi.Rows.Add(chon, cp.tencuocphi, "+", soluong, "-", cp.giacuocphi, "Xem", cp.macuocphi);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCuocPhi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvCuocPhi.Columns[e.ColumnIndex].Name == "xem" && e.RowIndex > -1)
            {
                FormCuocPhi.state = 1;
                FormCuocPhi.MaCuoc = Convert.ToInt32(dgvCuocPhi.Rows[e.RowIndex].Cells["macuocphi"].Value);
                FormCuocPhi frm = new FormCuocPhi();
                frm.ShowDialog();
            }
            else if (dgvCuocPhi.Columns[e.ColumnIndex].Name == "chon" && e.RowIndex > -1)
            {
                if (dgvCuocPhi.Rows[e.RowIndex].Cells["chon"].Value.ToString() == "Chọn")
                {
                    dgvCuocPhi.Rows[e.RowIndex].Cells["chon"].Value = "Đã chọn";
                    dgvCuocPhi.Rows[e.RowIndex].Cells["soluong"].Value = 1;
                }
                else
                {
                    dgvCuocPhi.Rows[e.RowIndex].Cells["chon"].Value = "Chọn";
                    dgvCuocPhi.Rows[e.RowIndex].Cells["soluong"].Value = 0;
                }
            }
            else if (dgvCuocPhi.Columns[e.ColumnIndex].Name == "tang" && e.RowIndex > -1)
            {
                int soluong = Convert.ToInt32(dgvCuocPhi.Rows[e.RowIndex].Cells["soluong"].Value);
                dgvCuocPhi.Rows[e.RowIndex].Cells["soluong"].Value = soluong + 1;
            }
            else if (dgvCuocPhi.Columns[e.ColumnIndex].Name == "giam" && e.RowIndex > -1)
            {
                if (Convert.ToInt32(dgvCuocPhi.Rows[e.RowIndex].Cells["soluong"].Value)> 0)
                {
                    int soluong = Convert.ToInt32(dgvCuocPhi.Rows[e.RowIndex].Cells["soluong"].Value);
                    dgvCuocPhi.Rows[e.RowIndex].Cells["soluong"].Value = soluong - 1; 
                }
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            dtCP.Rows.Clear();
            foreach(DataGridViewRow dgr in dgvCuocPhi.Rows)
            {
                if(dgr.Cells["chon"].Value.ToString() == "Đã chọn")
                {
                    DataRow dr = dtCP.NewRow();
                    dr["macuocphi"] = dgr.Cells["macuocphi"].Value;
                    dr["soluong"] = dgr.Cells["soluong"].Value;
                    dtCP.Rows.Add(dr);
                }
            }
            this.Close();
        }
    }
}
