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

        public List<ImportTraining> GetListTraining()
        {
            List<ImportTraining> result = new List<ImportTraining>();
            var query = from c in ObjectContext.Vlu_ChuongTrinhDT
                        select new ImportTraining
                        {
                            ID = c.ID,
                            NamHoc = c.NamHoc,
                            HocKy = c.HocKy,
                            KhoaID = c.KhoaID,
                            MaKhoa = c.Vlu_Khoa.MaKhoa,
                            TenKhoa = c.Vlu_Khoa.TenKhoa,
                            LopID = c.LopID,
                            MaLop = c.Vlu_LopHoc.MaLop,
                            TenLop = c.Vlu_LopHoc.TenLop,
                            MonHocID = c.MonHocID,
                            MaMonHoc = c.Vlu_MonHoc.MaMonHoc,
                            TenMonHoc = c.Vlu_MonHoc.TenMonHoc,
                            ThuocNhom = c.Vlu_MonHoc.ThuocNhom,
                            CreatedDate = c.NgayTao
                        };
            result = query.ToList();
            return result;
        }

        public int DeleteTraining(ImportTraining obj)
        {
            //1: can't find obj
            Vlu_ChuongTrinhDT objTraining = ObjectContext.Vlu_ChuongTrinhDT.FirstOrDefault(c => c.ID == obj.ID);
            if (objTraining != null)
            {
                ObjectContext.DeleteObject(objTraining);
                ObjectContext.SaveChanges();
            }
            else return 1;
            return 0;
        }

        public int ImportListTraining(List<ImportTraining> listImport)
        {
            //Check timeout import
            int result = 0;
            foreach (var item in listImport)
            {
                Vlu_MonHoc objMH = ObjectContext.Vlu_MonHoc.FirstOrDefault(c => c.MonHocID == item.MonHocID);
                Vlu_Khoa objKhoa = ObjectContext.Vlu_Khoa.FirstOrDefault(c => c.KhoaID == item.KhoaID);
                Vlu_LopHoc objLop = ObjectContext.Vlu_LopHoc.FirstOrDefault(c => c.LopID == item.LopID);
                if (objMH != null && objKhoa != null && objLop != null)
                {
                    Vlu_ChuongTrinhDT obj = new Vlu_ChuongTrinhDT();
                    obj.ID = -1;
                    obj.Vlu_MonHoc = objMH;
                    obj.Vlu_Khoa = objKhoa;
                    obj.Vlu_LopHoc = objLop;
                    obj.NamHoc = item.NamHoc;
                    obj.HocKy = item.HocKy;
                    obj.NgayTao = DateTime.Now;
                    obj.NguoiTao = ServiceContext.User.Identity.Name;
                    obj.NgayCapNhat = DateTime.Now;
                    obj.NguoiCapNhat = ServiceContext.User.Identity.Name;
                    result++;
                    ObjectContext.AddToVlu_ChuongTrinhDT(obj);
                }
            }
            if (result > 0)
                ObjectContext.SaveChanges();
            return result;
        }
    }
}
