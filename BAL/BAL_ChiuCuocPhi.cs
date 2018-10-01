using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BAL
{
    public class BAL_ChiuCuocPhi
    {
        public List<DTOChiuCuocPhi> GetAll()
        {
            List<DTOChiuCuocPhi> liDtoCCP = new List<DTOChiuCuocPhi>();
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                foreach(ChiuCuocPhi ccp in pt.ChiuCuocPhis)
                {
                    DTOChiuCuocPhi dtoCCP = new DTOChiuCuocPhi();
                    dtoCCP.mahopdong = ccp.MaHopDong;
                    dtoCCP.macuocphi = ccp.MaCuocPhi;
                    dtoCCP.soluong = ccp.SoLuong;
                    liDtoCCP.Add(dtoCCP);
                }
            }
            return liDtoCCP;
        }
        public List<DTOChiuCuocPhi> ChiuCuocPhiTuMaHopDong(Int64 mahopdong)
        {
            return GetAll().Where(c => c.mahopdong == mahopdong).ToList();
        }
        public void ThemChiuCuocPhi(DTOChiuCuocPhi dtoCCP)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.ChiuCuocPhi_Them(dtoCCP.mahopdong, dtoCCP.macuocphi, dtoCCP.soluong);
                pt.SubmitChanges();
            }
        }
        public void SuaChiuCuocPhi(DTOChiuCuocPhi dtoCCP)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.ChiuCuocPhi_Sua(dtoCCP.mahopdong, dtoCCP.macuocphi, dtoCCP.soluong);
                pt.SubmitChanges();
            }
        }
        public void XoaChiuCuocPhi(DTOChiuCuocPhi dtoCCP)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.ChiuCuocPhi_Xoa(dtoCCP.mahopdong, dtoCCP.macuocphi);
                pt.SubmitChanges();
            }
        }
    }
}
