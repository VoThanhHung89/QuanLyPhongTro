using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhongTro
{
    public partial class FormSearchDate : Form
    {
        public FormSearchDate()
        {
            InitializeComponent();
        }
        public static string ngaytim = string.Empty;

        private void FormSearchDate_Load(object sender, EventArgs e)
        {
            nmrNgay.Value = DateTime.Now.Day;
            nmrThang.Value = DateTime.Now.Month;
            nmrNam.Value = DateTime.Now.Year;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ngaytim = nmrNgay.Value + "/" + nmrThang.Value + "/" + nmrNam.Value;
            this.Close();
        }
    }
}
