using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOKhach
    {
        public Int64 makhach { get; set; }
        public bool? status { get; set; }
        public string tenkhach { get; set; }
        public bool gioitinh { get; set; }
        public DateTime ngaysinh { get; set; }
        public string sodinhdanh { get; set; }
        public string sodienthoai { get; set; }
        public bool? dangkytamtru { get; set; }
        public bool? tinhtranghonnhan { get; set; }
        public string diachi { get; set; }
        public string hinh { get; set; }
    }
}
