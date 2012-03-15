using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebManagement.Service
{
    public class ImportClass
    {
        public int LopID { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int ParentID { get; set; }
        public string Parent { get; set; }
        public int KhoaID { get; set; }
        public string MaKhoa { get; set; }
    }
}
