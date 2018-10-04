using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Security.Cryptography;

namespace BAL
{
    public class BAL_NguoiDung
    {
        public List<DTONguoiDung> GetAll()
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                List<DTONguoiDung> liDtoND = new List<DTONguoiDung>();
                foreach(NguoiDung nd in pt.NguoiDungs.ToList())
                {
                    DTONguoiDung dtoND = new DTONguoiDung();
                    dtoND.manguoidung = nd.MaNguoiDung;
                    dtoND.tendangnhap = nd.TenDangNhap;
                    dtoND.madangnhap = nd.MaDangNhap;
                    dtoND.admin = nd.Admin;
                    dtoND.status = nd.Status;
                    liDtoND.Add(dtoND);
                }
                return liDtoND;
            }
        }

        public DTONguoiDung DetailNguoiDung(int MaNguoiDung)
        {
            return GetAll().Where(n=>n.manguoidung == MaNguoiDung).FirstOrDefault();
        }

        public List<DTONguoiDung> Search(string TuTim)
        {
            return GetAll().Where(u => u.tendangnhap.Contains(TuTim)).ToList(); 
        }

        public void ThemNguoiDung(DTONguoiDung dtoND)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.NguoiDung_Them(dtoND.tendangnhap, dtoND.madangnhap, dtoND.admin, dtoND.status);
                pt.SubmitChanges();
            }
        }

        public void SuaNguoiDung(DTONguoiDung dtoND)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.NguoiDung_Sua(dtoND.manguoidung,dtoND.tendangnhap, dtoND.madangnhap, dtoND.admin, dtoND.status);
                pt.SubmitChanges();
            }
        }

        public void XoaNguoiDung(int MaNguoiDung)
        {
            using (PhongTroDBDataContext pt = new PhongTroDBDataContext())
            {
                pt.NguoiDung_Xoa(MaNguoiDung);
                pt.SubmitChanges();
            }
        }

        string key = "A!9HHhi%XjjYY4YP2@Nob009X";

        public string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }
    }
}
