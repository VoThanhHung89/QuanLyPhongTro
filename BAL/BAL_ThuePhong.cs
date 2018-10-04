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
        public List<DTOThuePhong> ThuePhongTuMaPhong(int MaPhong)
        {
            return GetAll().Where(t => t.maphong == MaPhong).ToList();
        }
        public List<DTOThuePhong> ThuePhongTuMaHopDong(Int64 MaHopDong)
        {
            return GetAll().Where(t => t.mahopdong == MaHopDong).ToList();
        }
        public List<DTOThuePhong> ThuePhongTuMaKhach(Int64 MaKhach)
        {
            return GetAll().Where(t => t.makhach == MaKhach).ToList();
        }
        public List<Int64> DanhSachMaHopDongTheoMaPhong(int MaPhong)
        {
            return GetAll().Where(t => t.maphong == MaPhong).Select(t => t.mahopdong).Distinct().ToList();
        }
        public List<Int64> DanhSachMaKhachTheoMaHopDong(Int64 MaHopDong)
        {
            return GetAll().Where(t => t.mahopdong == MaHopDong).Select(t => t.makhach).ToList();
        }
        public Int64 MaChuPhong(int MaPhong, Int64 MaHopDong)
        {
            return GetAll().Where(t => t.mahopdong == MaHopDong && t.maphong == MaPhong && t.chuphong == true).Select(t => t.makhach).FirstOrDefault();
        }
        public int MaPhongTuMaHopDong(Int64 MaHopDong)
        {
            return GetAll().Where(t => t.mahopdong == MaHopDong).Select(t => t.maphong).Distinct().First();
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
