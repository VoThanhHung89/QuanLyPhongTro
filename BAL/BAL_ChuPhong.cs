﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;

namespace BAL
{
    public class BAL_ChuPhong
    {
        public List<DTOChuPhong> GetAll()
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                List<DTOChuPhong> liDtoCP = new List<DTOChuPhong>();
                foreach( ChuPhong cp in pt.ChuPhongs.ToList())
                {
                    DTOChuPhong dtoCP = new DTOChuPhong();
                    dtoCP.machuphong = cp.MaChuPhong;
                    dtoCP.tenchuphong = cp.TenChuPhong;
                    dtoCP.gioitinh = cp.GioiTinh;
                    dtoCP.sodinhdanh = cp.SoDinhDanh;
                    dtoCP.sodienthoai = cp.SoDienThoai;
                    dtoCP.diachi = cp.DiaChi;
                    liDtoCP.Add(dtoCP);
                }
                return liDtoCP;
            }
        }
        public DTOChuPhong DetailChuPhong(int MaChu)
        {
            return GetAll().Where(c => c.machuphong == MaChu).FirstOrDefault();
        }
        /// <summary>
        /// Tìm kiếm
        /// </summary>
        /// <param name="searchby">-0:Tên chủ phòng -1:Số định danh -2:Số điện thoại -3:Địa chỉ</param>
        /// <param name="timkiem"></param>
        /// <returns></returns>
        public List<DTOChuPhong> Search(int SearchBy, string TuTim)
        {
            List<DTOChuPhong> liDtoCP = new List<DTOChuPhong>();
            switch (SearchBy)
            {
                case 0:
                    liDtoCP = GetAll().Where(c => c.tenchuphong.Contains(TuTim)).ToList();
                    break;
                case 1:
                    liDtoCP = GetAll().Where(c => c.sodinhdanh.Contains(TuTim)).ToList();
                    break;
                case 2:
                    liDtoCP = GetAll().Where(c => c.sodienthoai.Contains(TuTim)).ToList();
                    break;
                default:
                    liDtoCP = GetAll().Where(c => c.diachi.Contains(TuTim)).ToList();
                    break;
            }
            return liDtoCP;
        }
        public void ThemChuPhong(DTOChuPhong dtoCP)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.ChuPhong_Them(dtoCP.tenchuphong.ToUpper(), dtoCP.gioitinh, dtoCP.sodinhdanh, dtoCP.sodienthoai, dtoCP.diachi);
                pt.SubmitChanges();
            }
        }
        public void SuaChuPhong(DTOChuPhong dtoCP)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.ChuPhong_Sua(dtoCP.machuphong, dtoCP.tenchuphong.ToUpper(), dtoCP.gioitinh, dtoCP.sodinhdanh, dtoCP.sodienthoai, dtoCP.diachi);
                pt.SubmitChanges();
            }
        }
        public void XoaChuphong(int MaChu)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.ChuPhong_Xoa(MaChu);
                pt.SubmitChanges();
            }
        }
    }
}
