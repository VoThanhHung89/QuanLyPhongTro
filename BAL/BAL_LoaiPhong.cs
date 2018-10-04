using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BAL
{
    public class BAL_LoaiPhong
    {
        public List<DTOLoaiPhong> GetAll()
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                List<DTOLoaiPhong> liLP = new List<DTOLoaiPhong>();
                foreach(LoaiPhong lp in pt.LoaiPhongs.ToList())
                {
                    DTOLoaiPhong dtoLP = new DTOLoaiPhong();
                    dtoLP.maloaiphong = lp.MaLoaiPhong;
                    dtoLP.machuphong = lp.MaChuPhong;
                    dtoLP.tenloaiphong = lp.TenLoaiPhong;
                    dtoLP.giathue = Convert.ToDecimal(lp.GiaThue);
                    dtoLP.sokhach = Convert.ToInt32(lp.SoKhach);
                    dtoLP.thongtin = lp.ThongTin;
                    dtoLP.diachi = lp.DiaChi;
                    liLP.Add(dtoLP);
                }
                return liLP;
            }
        }
        public List<DTOLoaiPhong> GetAllByMaChu(int MaChu)
        {
            return GetAll().Where(l => l.machuphong == MaChu).ToList();
        }
        public DTOLoaiPhong DetailLoaiPhong(int MaLoai)
        {
            return GetAll().Where(l => l.maloaiphong == MaLoai).FirstOrDefault();
        }
        public List<DTOLoaiPhong> Search(int MaChu, int Searchby, string TuTim)
        {
            List<DTOLoaiPhong> liDtoLP = new List<DTOLoaiPhong>();
            switch (Searchby)
            {
                case 0:
                    liDtoLP = GetAll().Where(lp => lp.machuphong == MaChu && lp.tenloaiphong.Contains(TuTim)).ToList();
                    break;
                case 1:
                    liDtoLP = GetAll().Where(lp => lp.machuphong == MaChu && lp.giathue == Convert.ToInt32(TuTim)).ToList();
                    break;
                case 2:
                    liDtoLP = GetAll().Where(lp => lp.machuphong == MaChu && lp.thongtin.Contains(TuTim)).ToList();
                    break;
                default:
                    liDtoLP = GetAll().Where(lp => lp.machuphong == MaChu && lp.diachi.Contains(TuTim)).ToList();
                    break;
            }
            return liDtoLP;
        }
        public void ThemLoaiPhong(DTOLoaiPhong dtoLP)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.LoaiPhong_Them(dtoLP.machuphong, dtoLP.tenloaiphong.ToUpper(), dtoLP.giathue, dtoLP.sokhach, dtoLP.thongtin, dtoLP.diachi);
                pt.SubmitChanges();
            }
        }
        public void SuaLoaiPhong(DTOLoaiPhong dtoLP)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.LoaiPhong_Sua(dtoLP.maloaiphong, dtoLP.machuphong, dtoLP.tenloaiphong.ToUpper(), dtoLP.giathue, dtoLP.sokhach, dtoLP.thongtin, dtoLP.diachi);
                pt.SubmitChanges();
            }
        }
        public void XoaLoaiPhong(int MaLoai)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.LoaiPhong_Xoa(MaLoai);
                pt.SubmitChanges();
            }
        }
    }
}
