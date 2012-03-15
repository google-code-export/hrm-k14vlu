namespace WebManagement.Service
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Data.Objects;
    using AuthenticationLib;
    using AuthenticationLib.AuthService;

    [RequiresAuthentication]
    [EnableClientAccess]
    public class BusinessService : LinqToEntitiesDomainService<Portal_VanLangEntities>
    {
        #region Properties
        private AuthController _controllerAuth;
        public AuthController ControllerAuth
        {
            get
            {
                if (_controllerAuth == null)
                    _controllerAuth = new AuthController();
                return _controllerAuth;
            }
        }
        #endregion

        public List<Authentication> GetListAuthenticationMenu(int userID, string groupKey)
        {
            List<Authentication> result = new List<Authentication>();
            result = ControllerAuth.GetListAuthenticationMenu(userID, groupKey);
            return result;
        }

        public List<Authentication> GetListAuthenticationForm(int userID, string groupKey, string keyName)
        {
            List<Authentication> result = new List<Authentication>();
            result = ControllerAuth.GetListAuthenticationForm(userID, groupKey, keyName);
            return result;
        }

        public int ChangePassword(int userID, string password, string newPassword)
        {
            return ControllerAuth.ChangePassword(userID, password, newPassword);
        }

        public List<Training> GetListTraining()
        {
            List<Training> result = new List<Training>();
            var query = from c in ObjectContext.Vlu_ChuongTrinhDT
                        select new Training
                        {
                            ID = c.ID,
                            Year = c.NamHoc,
                            YearName = c.NamHoc.ToString() + " - " + (c.NamHoc + 1).ToString(),
                            Semester = c.HocKy,
                            SemesterName = c.HocKy.ToString(),
                            KhoaID = c.KhoaID,
                            MaKhoa = c.Vlu_Khoa.MaKhoa,
                            TenKhoa = c.Vlu_Khoa.TenKhoa,
                            LopID = c.LopID,
                            MaLop = c.Vlu_LopHoc.MaLop,
                            TenLop = c.Vlu_LopHoc.TenLop,
                            MonHocID = c.MonHocID,
                            MaMonHoc = c.Vlu_MonHoc.MaMonHoc,
                            TenMonHoc = c.Vlu_MonHoc.TenMonHoc,
                            CreatedDate = c.NgayTao
                        };
            result = query.ToList();
            return result;
        }
    }
}
