using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebManagement.Service
{
    public class Training
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public string YearName { get; set; }
        public int Semester { get; set; }
        public string SemesterName { get; set; }
        public int KhoaID { get; set; }
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public int MonHocID { get; set; }
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int LopID { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
