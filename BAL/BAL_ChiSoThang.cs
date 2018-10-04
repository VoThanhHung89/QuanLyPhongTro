using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BAL
{
    public class BAL_ChiSoThang
    {
        private bool SoSanhString(string text1, string text2)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(text1, text2, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                return true;
            else return false;
        }
        public List<DTOChiSoThang> GetAll()
        {
            List<DTOChiSoThang> liDtoCST = new List<DTOChiSoThang>();
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                foreach(ChiSoThang cst in pt.ChiSoThangs.ToList())
                {
                    DTOChiSoThang dtoCST = new DTOChiSoThang();
                    dtoCST.maphong = cst.MaPhong;
                    dtoCST.ngaycapnhat = cst.NgayCapNhat;
                    dtoCST.chisodien = cst.ChiSoDien;
                    dtoCST.chisonuoc = cst.ChiSoNuoc;
                    liDtoCST.Add(dtoCST);
                }
            }
            return liDtoCST;
        }
        public List<DTOChiSoThang> ChiSoTheoMaPhongAllTime(int MaPhong)
        {
            return GetAll().Where(cs => cs.maphong == MaPhong).OrderByDescending(cs => cs.ngaycapnhat).ToList();
        }
        public DataTable ChiSoTheoThoiGian(List<DTOPhong> liDtoPhong, DateTime time)
        {
            BAL_ChuPhong balCP = new BAL_ChuPhong();
            BAL_LoaiPhong balLP = new BAL_LoaiPhong();

            DataTable dtP = new DataTable();
            dtP.Columns.Add("tenchuphong", typeof(string));
            dtP.Columns.Add("tenloaiphong", typeof(string));
            dtP.Columns.Add("maphong", typeof(Int32));
            dtP.Columns.Add("tenphong", typeof(string));
            dtP.Columns.Add("ngaycapnhat", typeof(DateTime));
            dtP.Columns.Add("chisodien", typeof(Int64));
            dtP.Columns.Add("chisonuoc", typeof(Int64));
            BAL_Phong balP = new BAL_Phong();
            foreach(DTOPhong dtoP in liDtoPhong)
            {
                DataRow dr = dtP.NewRow();

                int maloaiphong = balP.DetailPhong(dtoP.maphong).maloaiphong;
                dr["tenloaiphong"] = balLP.DetailLoaiPhong(maloaiphong).tenloaiphong;
                int machuphong = balLP.DetailLoaiPhong(maloaiphong).machuphong;
                dr["tenchuphong"] = balCP.DetailChuPhong(machuphong).tenchuphong;

                dr["maphong"] = dtoP.maphong;
                dr["tenphong"] = dtoP.tenphong;
                dr["ngaycapnhat"] = time;

                if (ChiSoTheoMaPhongVaThoiGian(dtoP.maphong, time).chisodien == null)
                    dr["chisodien"] = DBNull.Value;
                else dr["chisodien"] = ChiSoTheoMaPhongVaThoiGian(dtoP.maphong, time).chisodien;

                if (ChiSoTheoMaPhongVaThoiGian(dtoP.maphong, time).chisonuoc == null)
                    dr["chisonuoc"] = DBNull.Value;
                else dr["chisonuoc"] = ChiSoTheoMaPhongVaThoiGian(dtoP.maphong, time).chisonuoc;

                dtP.Rows.Add(dr);
            }
            return dtP;
        }
        public DTOChiSoThang ChiSoTheoMaPhongVaThoiGian(int maphong, DateTime time)
        {
            DTOChiSoThang dtoCST = new DTOChiSoThang();
            foreach (DTOChiSoThang cs in GetAll())
            {
                if (cs.maphong == maphong && cs.ngaycapnhat.Date == time.Date && cs.ngaycapnhat.Month == time.Month && cs.ngaycapnhat.Year == time.Year)
                {
                    dtoCST = cs;
                    break;
                }
            }
            return dtoCST;
        }
        public DTOChiSoThang ChiSoGanVoiNgayCanTim(int MaPhong, DateTime time)
        {
            return GetAll().Where(c => c.maphong == MaPhong && c.ngaycapnhat.Date < time.Date).OrderByDescending(c => c.ngaycapnhat).FirstOrDefault();
        }
        public DTOChiSoThang ChiSoMoiNhat(int MaPhong)
        {
            return GetAll().OrderByDescending(cp => cp.ngaycapnhat).Where(c => c.maphong == MaPhong).FirstOrDefault();
        }
        /// <summary>
        /// True:Đã có - False:Chưa có
        /// </summary>
        /// <param name="maphong"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool CheckCST(int MaPhong, DateTime time)
        {
                if (GetAll().Where(cs => cs.maphong == MaPhong && cs.ngaycapnhat.Date == time.Date).Count() >= 1)
                    return true;
                else return false;
        }
        public void ThemChiSoThang(DTOChiSoThang dtoCST)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.ChiSoThang_Them(dtoCST.maphong, dtoCST.ngaycapnhat, dtoCST.chisodien, dtoCST.chisonuoc);
                pt.SubmitChanges();
            }
        }
        public void SuaChiSoThang(DTOChiSoThang dtoCST)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.ChiSoThang_Sua(dtoCST.maphong, dtoCST.ngaycapnhat, dtoCST.chisodien, dtoCST.chisonuoc);
                pt.SubmitChanges();
            }
        }
        public void XoaChiSoThang(DTOChiSoThang dtoCST)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.ChiSoThang_Xoa(dtoCST.maphong, dtoCST.ngaycapnhat);
                pt.SubmitChanges();
            }
        }
    }
}
