﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BAL
{
    public class BAL_HopDong
    {
        public List<DTOHopDong> GetAll()
        {
            using(PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                List<DTOHopDong> liDtoHD = new List<DTOHopDong>();
                foreach(HopDong hd in pt.HopDongs)
                {
                    DTOHopDong dtoHD = new DTOHopDong();
                    dtoHD.mahopdong = hd.MaHopDong;
                    dtoHD.ngaythue = hd.NgayThue;
                    dtoHD.ngaytra = hd.NgayTra;
                    dtoHD.ngaylamhopdong = hd.NgayLamHopDong;
                    dtoHD.tiencoc = hd.TienCoc;
                    dtoHD.giathue = hd.GiaThue;
                    dtoHD.chisodien = hd.ChiSoDien;
                    dtoHD.chisonuoc = hd.ChiSoNuoc;
                    dtoHD.ghichu = hd.GhiChu;
                    dtoHD.status = hd.Status;
                    liDtoHD.Add(dtoHD);
                }
                return liDtoHD;
            }
        }
        public DTOHopDong DetailHopDong(Int64 mahopdong)
        {
            return GetAll().Where(h => h.mahopdong == mahopdong).FirstOrDefault();
        }
        public Int64 MaHopDongSearchByAll(DTOHopDong dtoHD)
        {
            if (dtoHD.ngaylamhopdong == null)
                return GetAll().Where(h => Convert.ToDateTime(h.ngaythue).Date == Convert.ToDateTime(dtoHD.ngaythue).Date &&
                        Convert.ToDateTime(h.ngaytra).Date == Convert.ToDateTime(dtoHD.ngaytra).Date && 
                        h.ngaylamhopdong == null &&
                        h.tiencoc == dtoHD.tiencoc && h.giathue == dtoHD.giathue && h.chisodien == h.chisodien && h.chisonuoc == dtoHD.chisonuoc &&
                        h.ghichu == dtoHD.ghichu).Select(h => h.mahopdong).FirstOrDefault();
            else if(dtoHD.ngaytra == null)
                return GetAll().Where(h => Convert.ToDateTime(h.ngaythue).Date == Convert.ToDateTime(dtoHD.ngaythue).Date &&
                        h.ngaytra == null &&
                        Convert.ToDateTime(h.ngaylamhopdong).Date == Convert.ToDateTime(dtoHD.ngaylamhopdong).Date && 
                        h.tiencoc == dtoHD.tiencoc && h.giathue == dtoHD.giathue && h.chisodien == h.chisodien && h.chisonuoc == dtoHD.chisonuoc &&
                        h.ghichu == dtoHD.ghichu).Select(h => h.mahopdong).FirstOrDefault();
            else if (dtoHD.ghichu == null)
                return GetAll().Where(h => Convert.ToDateTime(h.ngaythue).Date == Convert.ToDateTime(dtoHD.ngaythue).Date &&
                        Convert.ToDateTime(h.ngaytra).Date == Convert.ToDateTime(dtoHD.ngaytra).Date &&
                        Convert.ToDateTime(h.ngaylamhopdong).Date == Convert.ToDateTime(dtoHD.ngaylamhopdong).Date && 
                        h.tiencoc == dtoHD.tiencoc && h.giathue == dtoHD.giathue && h.chisodien == h.chisodien && h.chisonuoc == dtoHD.chisonuoc &&
                        h.ghichu == null).Select(h => h.mahopdong).FirstOrDefault();
            else if (dtoHD.ngaytra == null && dtoHD.ngaylamhopdong == null)
                return GetAll().Where(h => Convert.ToDateTime(h.ngaythue).Date == Convert.ToDateTime(dtoHD.ngaythue).Date && 
                        h.ngaytra == null &&
                        h.ngaylamhopdong == null && 
                        h.tiencoc == dtoHD.tiencoc && h.giathue == dtoHD.giathue && h.chisodien == h.chisodien && h.chisonuoc == dtoHD.chisonuoc &&
                        h.ghichu == dtoHD.ghichu).Select(h => h.mahopdong).FirstOrDefault();
            else if (dtoHD.ngaytra == null && dtoHD.ghichu == null)
                return GetAll().Where(h => Convert.ToDateTime(h.ngaythue).Date == Convert.ToDateTime(dtoHD.ngaythue).Date &&
                        h.ngaytra == null &&
                        Convert.ToDateTime(h.ngaylamhopdong).Date == Convert.ToDateTime(dtoHD.ngaylamhopdong).Date &&
                        h.tiencoc == dtoHD.tiencoc && h.giathue == dtoHD.giathue && h.chisodien == h.chisodien && h.chisonuoc == dtoHD.chisonuoc &&
                        h.ghichu == null).Select(h => h.mahopdong).FirstOrDefault();
            else if (dtoHD.ngaylamhopdong == null && dtoHD.ghichu == null)
                return GetAll().Where(h => Convert.ToDateTime(h.ngaythue).Date == Convert.ToDateTime(dtoHD.ngaythue).Date &&
                        Convert.ToDateTime(h.ngaytra).Date == Convert.ToDateTime(dtoHD.ngaytra).Date &&
                        h.ngaylamhopdong == null &&
                        h.tiencoc == dtoHD.tiencoc && h.giathue == dtoHD.giathue && h.chisodien == h.chisodien && h.chisonuoc == dtoHD.chisonuoc &&
                        h.ghichu == null).Select(h => h.mahopdong).FirstOrDefault();
            else if (dtoHD.ngaytra == null && dtoHD.ngaylamhopdong == null && dtoHD.ghichu == null)
                return GetAll().Where(h => Convert.ToDateTime(h.ngaythue).Date == Convert.ToDateTime(dtoHD.ngaythue).Date &&
                        h.ngaytra == null &&
                        h.ngaylamhopdong == null &&
                        h.tiencoc == dtoHD.tiencoc && h.giathue == dtoHD.giathue && h.chisodien == h.chisodien && h.chisonuoc == dtoHD.chisonuoc &&
                        h.ghichu == null).Select(h => h.mahopdong).FirstOrDefault();
            else return GetAll().Where(h => Convert.ToDateTime(h.ngaythue).Date == Convert.ToDateTime(dtoHD.ngaythue).Date &&
                        Convert.ToDateTime(h.ngaytra).Date == Convert.ToDateTime(dtoHD.ngaytra).Date &&
                        Convert.ToDateTime(h.ngaylamhopdong).Date == Convert.ToDateTime(dtoHD.ngaylamhopdong).Date &&
                        h.tiencoc == dtoHD.tiencoc && h.giathue == dtoHD.giathue && h.chisodien == h.chisodien && h.chisonuoc == dtoHD.chisonuoc &&
                        h.ghichu == dtoHD.ghichu).Select(h => h.mahopdong).FirstOrDefault();
        }
        public void CapNhatStatus()
        {
            BAL_ThuePhong balTP = new BAL_ThuePhong();
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                foreach(HopDong hd in pt.HopDongs.Where(h => h.NgayThue.Date < DateTime.Now.Date).ToList())
                {
                    if(hd.NgayTra == null || DateTime.Now.Date < Convert.ToDateTime(hd.NgayTra).Date)
                    {
                        hd.Status = true;
                        int maphong = balTP.MaPhongTuMaHopDong(hd.MaHopDong);
                        Phong ph = pt.Phongs.Where(p => p.MaPhong == maphong).SingleOrDefault();
                        ph.Status = true;
                        pt.SubmitChanges();
                    }
                }
            }
        }
        /// <summary>
        /// -1:Hết hạn 0:Còn hạn 1:Tương lai
        /// </summary>
        /// <param name="mahopdong"></param>
        /// <returns></returns>
        public int GiaTriHopDongVoiNgayHienTai(Int64 mahopdong)
        {
            int giatri = -1;
            DTOHopDong dtoHD = GetAll().Where(h => h.mahopdong == mahopdong).SingleOrDefault();
            if (dtoHD.ngaythue.Date >= DateTime.Now.Date) giatri = 1;
            else
            {
                if (dtoHD.ngaytra == null || Convert.ToDateTime(dtoHD.ngaytra).Date > DateTime.Now.Date) giatri = 0;
                else if (Convert.ToDateTime(dtoHD.ngaytra).Date < DateTime.Now.Date) giatri = -1;
            }
            return giatri;
        }
        public DTOHopDong HopDongHienTai(int maphong)
        {
            BAL_ThuePhong balTP = new BAL_ThuePhong();

            DTOHopDong dtoHDHT = new DTOHopDong();
            foreach (Int64 mahopdong in balTP.DanhSachMaHopDongTheoMaPhong(maphong))
            {
                DTOHopDong dtoHD = DetailHopDong(mahopdong);
                if (dtoHD.status == true) dtoHDHT = dtoHD;
            }
            return dtoHDHT;
        }
        public List<DTOHopDong> HopDongTrongTuongLai(int maphong)
        {
            BAL_ThuePhong balTP = new BAL_ThuePhong();

            List<DTOHopDong> liDtoHDTL = new List<DTOHopDong>();
            foreach (Int64 mahopdong in balTP.DanhSachMaHopDongTheoMaPhong(maphong))
            {
                DTOHopDong dtoHD = DetailHopDong(mahopdong);
                if (dtoHD.ngaythue.Date > DateTime.Now.Date) liDtoHDTL.Add(dtoHD);
            }
            return liDtoHDTL;
        }
        public void ThemHopDong(DTOHopDong dtoHD)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.HopDong_Them(dtoHD.ngaythue, dtoHD.ngaytra, dtoHD.ngaylamhopdong, dtoHD.tiencoc, dtoHD.giathue, dtoHD.chisodien, dtoHD.chisonuoc, dtoHD.ghichu);
                pt.SubmitChanges();
            }
            BAL_ThuePhong balTP = new BAL_ThuePhong();
            BAL_Khach balK = new BAL_Khach();
            foreach (Int64 makhach in balTP.DanhSachMaKhachTheoMaHopDong(dtoHD.mahopdong))
            {
                balK.CapNhatStatusTungKhach(makhach);
            }
        }
        public void SuaHopDong(DTOHopDong dtoHD)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.HopDong_Sua(dtoHD.mahopdong, dtoHD.ngaythue, dtoHD.ngaytra, dtoHD.ngaylamhopdong, dtoHD.tiencoc,
                    dtoHD.giathue, dtoHD.chisodien, dtoHD.chisonuoc, dtoHD.ghichu);
                pt.SubmitChanges();
            }
            BAL_ThuePhong balTP = new BAL_ThuePhong();
            BAL_Khach balK = new BAL_Khach();
            foreach(Int64 makhach in balTP.DanhSachMaKhachTheoMaHopDong(dtoHD.mahopdong))
            {
                balK.CapNhatStatusTungKhach(makhach);
            }
        }
        public void XoaHopDong(Int64 mahopdong)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.HopDong_Xoa(mahopdong);
                pt.SubmitChanges();
            }
        }
    }
}
