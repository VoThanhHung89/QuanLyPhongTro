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
    public class BAL_Phong
    {
        public List<DTOPhong> GetAll()
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                List<DTOPhong> liP = new List<DTOPhong>();
                foreach (Phong p in pt.Phongs.ToList())
                {
                    DTOPhong dtoP = new DTOPhong();
                    dtoP.maphong = p.MaPhong;
                    dtoP.maloaiphong = p.MaLoaiPhong;
                    dtoP.tenphong = p.TenPhong;
                    dtoP.status = p.Status;
                    dtoP.tinhtrangphong = p.TinhTrangPhong;
                    liP.Add(dtoP);
                }
                return liP;
            }
        }
        public List<DTOPhong> GetAllByMaLoai(int maloai)
        {
            return GetAll().Where(p=>p.maloaiphong == maloai).ToList();
        }
        public DTOPhong DetailPhong(int maphong)
        {
            return GetAll().Where(p => p.maphong == maphong).FirstOrDefault();
        }
        public List<DTOPhong> Search(int maloai, string timkiem)
        {
            return GetAll().Where(p => p.maloaiphong == maloai && p.tenphong.Contains(timkiem)).ToList();
        }
        /// <summary>
        /// Tìm kiếm rút gọn.
        /// </summary>
        /// <param name="searchby">0:tenchuphong-1:tenloaiphong-2:tenphong-3:All</param>
        /// <param name="timkiem"></param>
        /// <returns></returns>
        public List<DTOPhong> SearchP_LP_CP(int searchby, string timkiem)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                List<Phong> liP = new List<Phong>();
                switch (searchby)
                {
                    case 0:
                        liP = (from p in pt.Phongs
                                join lp in pt.LoaiPhongs on p.MaLoaiPhong equals lp.MaLoaiPhong
                                join cp in pt.ChuPhongs on lp.MaChuPhong equals cp.MaChuPhong
                                where (cp.TenChuPhong.Contains(timkiem))
                                select p).ToList() ;
                        break;
                    case 1:
                        liP = (from p in pt.Phongs
                                     join lp in pt.LoaiPhongs on p.MaLoaiPhong equals lp.MaLoaiPhong
                                     join cp in pt.ChuPhongs on lp.MaChuPhong equals cp.MaChuPhong
                                     where (lp.TenLoaiPhong.Contains(timkiem))
                                     select p).ToList();
                        break;
                    case 2:
                        liP = (from p in pt.Phongs
                                     join lp in pt.LoaiPhongs on p.MaLoaiPhong equals lp.MaLoaiPhong
                                     join cp in pt.ChuPhongs on lp.MaChuPhong equals cp.MaChuPhong
                                     where (p.TenPhong.Contains(timkiem))
                                     select p).ToList();
                        break;
                    default:
                        liP = (from p in pt.Phongs
                                     join lp in pt.LoaiPhongs on p.MaLoaiPhong equals lp.MaLoaiPhong
                                     join cp in pt.ChuPhongs on lp.MaChuPhong equals cp.MaChuPhong
                                     select p).ToList();
                        break;
                }
                List<DTOPhong> liDtoP = new List<DTOPhong>();
                foreach (Phong p in liP)
                {
                    DTOPhong dtoP = new DTOPhong();
                    dtoP.maphong = p.MaPhong;
                    dtoP.maloaiphong = p.MaLoaiPhong;
                    dtoP.tenphong = p.TenPhong;
                    dtoP.status = p.Status;
                    dtoP.tinhtrangphong = p.TinhTrangPhong;
                    liDtoP.Add(dtoP);
                }
                return liDtoP;
            }
        }
        public void ThemPhong(DTOPhong dtoP)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.Phong_Them(dtoP.maloaiphong, dtoP.tenphong.ToUpper(), dtoP.status, dtoP.tinhtrangphong);
                pt.SubmitChanges();
            }
        }
        public void SuaPhong(DTOPhong dtoP)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.Phong_Sua(dtoP.maphong, dtoP.maloaiphong, dtoP.tenphong.ToUpper(), dtoP.status, dtoP.tinhtrangphong);
                pt.SubmitChanges();
            }
        }
        public void XoaPhong(int maphong)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.Phong_Xoa(maphong);
                pt.SubmitChanges();
            }
        }
    }
}
