using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BAL
{
    public class BAL_CuocPhi
    {
        public List<DTOCuocPhi> GetAll()
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                List<DTOCuocPhi> liDtoCuoc = new List<DTOCuocPhi>();
                foreach(CuocPhi cuoc in pt.CuocPhis.ToList())
                {
                    DTOCuocPhi dtoCuoc = new DTOCuocPhi();
                    dtoCuoc.macuocphi = cuoc.MaCuocPhi;
                    dtoCuoc.tencuocphi = cuoc.TenCuocPhi;
                    dtoCuoc.giacuocphi = Convert.ToDecimal(cuoc.GiaCuocPhi);
                    dtoCuoc.thongtin = cuoc.ThongTin;
                    liDtoCuoc.Add(dtoCuoc);
                }
                return liDtoCuoc;
            }
        }
        public DTOCuocPhi DetailCuocPhi(int macuoc)
        {
            return GetAll().Where(c => c.macuocphi == macuoc).FirstOrDefault();
        }
        public List<DTOCuocPhi> Search(int searchby, string timkiem)
        {
            List<DTOCuocPhi> liDtoCuoc = new List<DTOCuocPhi>();
            if (searchby == 0)
                liDtoCuoc = GetAll().Where(c => c.tencuocphi.Contains(timkiem)).ToList();
            else
                liDtoCuoc = GetAll().Where(c => c.thongtin.Contains(timkiem)).ToList();
            return liDtoCuoc;
        }
        public void ThemCuocPhi(DTOCuocPhi dtoCuoc)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.CuocPhi_Them(dtoCuoc.tencuocphi, dtoCuoc.giacuocphi, dtoCuoc.thongtin);
                pt.SubmitChanges();
            }
        }
        public void SuaCuocPhi(DTOCuocPhi dtoCuoc)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.CuocPhi_Sua(dtoCuoc.macuocphi, dtoCuoc.tencuocphi, dtoCuoc.giacuocphi, dtoCuoc.thongtin);
                pt.SubmitChanges();
            }
        }
        public void XoaCuocPhi(int macuoc)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.CuocPhi_Xoa(macuoc);
                pt.SubmitChanges();
            }
        }
    }
}
