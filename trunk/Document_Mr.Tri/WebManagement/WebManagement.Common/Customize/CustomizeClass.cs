using System;

namespace WebManagement.Common
{
    public class CustomizeClass
    {
        public int ID { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }        
        public int KhoaID { get; set; }
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public int? ParentID { get; set; }
        public string ParentKey { get; set; }
        public string ParentName { get; set; }
    }
}
