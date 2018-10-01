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
    public class BAL_Khach
    {
        public List<DTOKhach> GetAll()
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                List<DTOKhach> liDtoK = new List<DTOKhach>();
                foreach(Khach k in pt.Khaches.ToList())
                {
                    DTOKhach dtoK = new DTOKhach();
                    dtoK.makhach = k.MaKhach;
                    dtoK.tenkhach = k.TenKhach;
                    dtoK.ngaysinh = k.NgaySinh;
                    dtoK.gioitinh = k.GioiTinh;
                    dtoK.sodinhdanh = k.SoDinhDanh;
                    dtoK.sodienthoai = k.SoDienThoai;
                    dtoK.diachi = k.DiaChi;
                    dtoK.hinh = k.Hinh;
                    dtoK.tinhtranghonnhan = k.TinhTrangHonNhan;
                    dtoK.dangkytamtru = k.DangKyTamTru;
                    dtoK.status = k.Status;
                    liDtoK.Add(dtoK);
                }
                return liDtoK;
            }
        }
        public DTOKhach DetailKhach(Int64 makhach)
        {
            return GetAll().Where(k => k.makhach == makhach).FirstOrDefault();
        }
        public List<DTOKhach> Search(int cachtim, string timkiem)
        {
            List<DTOKhach> liDtoK = new List<DTOKhach>();
            switch (cachtim)
            {
                case 0://Tìm Theo Tên Khách
                    liDtoK = GetAll().Where(k => k.tenkhach.Contains(timkiem)).ToList();
                    break;
                case 1://Tìm Theo Ngày Sinh
                    //int ngay = Convert.ToInt32(timkiem.Substring(0, 2));
                    //int thang = Convert.ToInt32(timkiem.Substring(3, 2));
                    //int nam = Convert.ToInt32(timkiem.Substring(6, 4));
                    //liK = pt.Khaches.Where(k => k.NgaySinh.Day == ngay && k.NgaySinh.Month == thang && k.NgaySinh.Year == nam).ToList();
                    liDtoK = GetAll().Where(k => k.ngaysinh.Date == Convert.ToDateTime(timkiem).Date).ToList();
                    break;
                case 2://Tìm Theo số định danh
                    liDtoK = GetAll().Where(k => k.sodinhdanh.Contains(timkiem)).ToList();
                    break;
                case 3://Tìm theo Số điện thoại
                    liDtoK = GetAll().Where(k => k.sodienthoai.Contains(timkiem)).ToList();
                    break;
                default://Tìm theo địa chỉ.
                    liDtoK = GetAll().Where(k => k.diachi.Contains(timkiem)).ToList();
                    break;
            }
            return liDtoK;
        }
        public void ThemKhach(DTOKhach dtoK)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.Khach_Them(dtoK.tenkhach.ToUpper(), dtoK.ngaysinh, dtoK.gioitinh, dtoK.sodinhdanh,
                    dtoK.sodienthoai, dtoK.diachi, dtoK.hinh, dtoK.tinhtranghonnhan, dtoK.dangkytamtru);
                pt.SubmitChanges();
            }
        }
        public void SuaKhach(DTOKhach dtoK)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.Khach_Sua(dtoK.makhach, dtoK.tenkhach.ToUpper(), dtoK.ngaysinh, dtoK.gioitinh, dtoK.sodinhdanh,
                    dtoK.sodienthoai, dtoK.diachi, dtoK.hinh, dtoK.tinhtranghonnhan, dtoK.dangkytamtru);
                pt.SubmitChanges();
            }
        }
        public void XoaKhach(Int64 makhach)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.Khach_Xoa(makhach);
                pt.SubmitChanges();
            }
        }
        public void CapNhatStatusTungKhach(Int64 makhach)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                bool trangthai = false;
                Khach k = pt.Khaches.Where(kh => kh.MaKhach == makhach).FirstOrDefault();
                List<Int64> liMaHD = pt.ThuePhongs.Where(t => t.MaKhach == makhach).Select(t => t.MaHopDong).ToList();
                foreach(Int64 mahd in liMaHD)
                {
                    HopDong hd = pt.HopDongs.Where(h => h.MaHopDong == mahd).FirstOrDefault();
                    if (hd.Status) trangthai = true;
                }
                k.Status = trangthai;
                pt.SubmitChanges();
            }
        }
        public void CapNhatStatusAll()
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                foreach(Khach k in pt.Khaches)
                {
                    bool trangthai = false;
                    List<Int64> liMaHD = pt.ThuePhongs.Where(t => t.MaKhach == k.MaKhach).Select(t => t.MaHopDong).ToList();
                    foreach (Int64 mahd in liMaHD)
                    {
                        HopDong hd = pt.HopDongs.Where(h => h.MaHopDong == mahd).FirstOrDefault();
                        if (hd.Status) trangthai = true;
                    }
                    k.Status = trangthai;
                }
                pt.SubmitChanges();
            }
        }
    }
}
