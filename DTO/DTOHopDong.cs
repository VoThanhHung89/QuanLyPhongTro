using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOHopDong
    {
        public Int64 mahopdong { get; set; }
        public DateTime ngaythue { get; set; }
        public DateTime? ngaytra { get; set; }
        public DateTime? ngaylamhopdong { get; set; }
        public decimal? tiencoc { get; set; }
        public decimal? giathue { get; set; }
        public Int64? chisodien { get; set; }
        public Int64? chisonuoc { get; set; }
        public string ghichu { get; set; }
        public bool status { get; set; }
    }
}
