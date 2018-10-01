using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BAL
{
    public class BAL_ThuePhong
    {
        public List<DTOThuePhong> GetAll()
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                List<DTOThuePhong> liDtoTP = new List<DTOThuePhong>();
                foreach(ThuePhong tp in pt.ThuePhongs)
                {
                    DTOThuePhong dtoTP = new DTOThuePhong();
                    dtoTP.maphong = tp.MaPhong;
                    dtoTP.makhach = tp.MaKhach;
                    dtoTP.mahopdong = tp.MaHopDong;
                    dtoTP.chuphong = tp.ChuPhong;
                    liDtoTP.Add(dtoTP);
                }
                return liDtoTP;
            }
        }
        public List<DTOThuePhong> ThuePhongTuMaPhong(int maphong)
        {
            return GetAll().Where(t => t.maphong == maphong).ToList();
        }
        public List<DTOThuePhong> ThuePhongTuMaHopDong(Int64 mahopdong)
        {
            return GetAll().Where(t => t.mahopdong == mahopdong).ToList();
        }
        public List<DTOThuePhong> ThuePhongTuMaKhach(Int64 makhach)
        {
            return GetAll().Where(t => t.makhach == makhach).ToList();
        }
        public List<Int64> DanhSachMaHopDongTheoMaPhong(int maphong)
        {
            return GetAll().Where(t => t.maphong == maphong).Select(t => t.mahopdong).Distinct().ToList();
        }
        public List<Int64> DanhSachMaKhachTheoMaHopDong(Int64 mahopdong)
        {
            return GetAll().Where(t => t.mahopdong == mahopdong).Select(t => t.makhach).ToList();
        }
        public Int64 MaChuPhong(int maphong, Int64 mahopdong)
        {
            return GetAll().Where(t => t.mahopdong == mahopdong && t.maphong == maphong && t.chuphong == true).Select(t => t.makhach).FirstOrDefault();
        }
        public int MaPhongTuMaHopDong(Int64 mahopdong)
        {
            return GetAll().Where(t => t.mahopdong == mahopdong).Select(t => t.maphong).Distinct().First();
        }
        public void ThemThuePhong(DTOThuePhong dtoTP)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.ThuePhong_Them(dtoTP.maphong, dtoTP.makhach, dtoTP.mahopdong, dtoTP.chuphong);
                pt.SubmitChanges();
            }
        }
        public void SuaThuePhong(DTOThuePhong dtoTP)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.ThuePhong_Sua(dtoTP.maphong, dtoTP.makhach, dtoTP.mahopdong, dtoTP.chuphong);
                pt.SubmitChanges();
            }
        }
        public void XoaThuePhong(DTOThuePhong dtoTP)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.ThuePhong_Xoa(dtoTP.maphong, dtoTP.makhach, dtoTP.mahopdong);
                pt.SubmitChanges();
            }
        }
    }
}
