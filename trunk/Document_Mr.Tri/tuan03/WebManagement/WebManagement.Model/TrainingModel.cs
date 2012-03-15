using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel.DomainServices.Client;

using WebManagement.Common;
using WebManagement.Service;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Security.Principal;

namespace WebManagement.Model
{
    [Export(typeof(ITrainingModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class TrainingModel : ModelBase, ITrainingModel
    {
        #region Events
        public event EventHandler<EntityResultsArgs<Vlu_PhongHoc>> GetListRoomComplete;
        public event EventHandler<EntityResultsArgs<Vlu_PhongHoc>> GetRoomComplete;
        public event EventHandler<EntityResultsArgs<Vlu_PhongHoc>> GetRoomByKeyComplete;
        public event EventHandler<SubmitOperationEventArgs> SaveRoomComplete;
        public event EventHandler<SubmitOperationEventArgs> DeleteRoomComplete;

        public event EventHandler<EntityResultsArgs<Vlu_Khoa>> GetListDepartmentComplete;
        public event EventHandler<EntityResultsArgs<Vlu_Khoa>> GetDepartmentComplete;
        public event EventHandler<EntityResultsArgs<Vlu_Khoa>> GetDepartmentParentComplete;
        public event EventHandler<EntityResultsArgs<Vlu_Khoa>> GetDepartmentByKeyComplete;
        public event EventHandler<SubmitOperationEventArgs> SaveDepartmentComplete;
        public event EventHandler<SubmitOperationEventArgs> DeleteDepartmentComplete;

        public event EventHandler<EntityResultsArgs<Vlu_LopHoc>> GetListClassComplete;
        public event EventHandler<EntityResultsArgs<Vlu_LopHoc>> GetClassComplete;
        public event EventHandler<EntityResultsArgs<Vlu_LopHoc>> GetClassParentComplete;
        public event EventHandler<EntityResultsArgs<Vlu_LopHoc>> GetClassByKeyComplete;
        public event EventHandler<SubmitOperationEventArgs> SaveClassComplete;
        public event EventHandler<SubmitOperationEventArgs> DeleteClassComplete;

        public event EventHandler<EntityResultsArgs<Vlu_MonHoc>> GetListSubjectComplete;
        public event EventHandler<EntityResultsArgs<Vlu_MonHoc>> GetSubjectComplete;
        public event EventHandler<EntityResultsArgs<Vlu_MonHoc>> GetSubjectByKeyComplete;
        public event EventHandler<SubmitOperationEventArgs> SaveSubjectComplete;
        public event EventHandler<SubmitOperationEventArgs> DeleteSubjectComplete;

        public event EventHandler<ComplexResultsArgs<Training>> GetListTrainingComplete;
        public event EventHandler<EntityResultsArgs<Vlu_ChuongTrinhDT>> GetTrainingComplete;
        public event EventHandler<SubmitOperationEventArgs> SaveTrainingComplete;
        public event EventHandler<SubmitOperationEventArgs> DeleteTrainingComplete;
        #endregion

        #region Public Methods
        public void GetListRoomAsync()
        {
            PerformQuery(Model.GetVlu_PhongHocQuery(), GetListRoomComplete, false);
        }

        public void GetRoomAsync(int id)
        {
            if (id == -1)
            {
                Vlu_PhongHoc obj = new Vlu_PhongHoc();
                obj.PhongID = id;
                obj.MaPhong = string.Empty;
                obj.TenPhong = string.Empty;
                obj.NgayTao = DateTime.Now;
                obj.NguoiTao = SystemConfig.UserName;
                List<Vlu_PhongHoc> lst = new List<Vlu_PhongHoc>();
                lst.Add(obj);
                if (GetRoomComplete != null)
                    GetRoomComplete(this, new EntityResultsArgs<Vlu_PhongHoc>(lst.ToArray()));
            }
            else
            {
                var query = from c in Model.GetVlu_PhongHocQuery()
                            where c.PhongID == id
                            select c;
                PerformQuery(query, GetRoomComplete, false);
            }
        }

        public void GetRoomByKeyAsync(int id, string keyName)
        {
            var query = from c in Model.GetVlu_PhongHocQuery()
                        where c.MaPhong == keyName && c.PhongID != id
                        select c;
            PerformQuery(query, GetRoomByKeyComplete, false);
        }

        public void SaveRoomAsync(Vlu_PhongHoc obj)
        {
            if (obj.PhongID == -1)
                Model.Vlu_PhongHocs.Add(obj);
            PerformSubmitChanged(SaveRoomComplete);
        }

        public void DeleteRoomAsync(Vlu_PhongHoc obj)
        {
            Model.Vlu_PhongHocs.Remove(obj);
            PerformSubmitChanged(DeleteRoomComplete);
        }



        public void GetListDepartmentAsync()
        {
            PerformQuery(Model.GetVlu_KhoaQuery(), GetListDepartmentComplete, false);
        }

        public void GetDepartmentAsync(int id, int handlerType)
        {
            if (id == -1)
            {
                Vlu_Khoa obj = new Vlu_Khoa();
                obj.KhoaID = id;
                obj.MaKhoa = string.Empty;
                obj.TenKhoa = string.Empty;
                obj.Loai = 0;
                obj.SapXep = 0;
                obj.NgayTao = DateTime.Now;
                obj.NguoiTao = SystemConfig.UserName;
                List<Vlu_Khoa> lst = new List<Vlu_Khoa>();
                lst.Add(obj);
                switch (handlerType)
                {
                    case 0: GetDepartmentComplete(this, new EntityResultsArgs<Vlu_Khoa>(lst.ToArray()));
                        break;
                    case 1: GetDepartmentParentComplete(this, new EntityResultsArgs<Vlu_Khoa>(lst.ToArray()));
                        break;
                }
            }
            else
            {
                var query = from c in Model.GetVlu_KhoaQuery()
                            where c.KhoaID == id
                            select c;
                switch (handlerType)
                {
                    case 0: PerformQuery(query, GetDepartmentComplete, false);
                        break;
                    case 1: PerformQuery(query, GetDepartmentParentComplete, false);
                        break;
                }
            }
        }

        public void GetDepartmentByKeyAsync(int id, string keyName)
        {
            var query = from c in Model.GetVlu_KhoaQuery()
                        where c.MaKhoa == keyName && c.KhoaID != id
                        select c;
            PerformQuery(query, GetDepartmentByKeyComplete, false);
        }

        public void SaveDepartmentAsync(Vlu_Khoa obj)
        {
            if (obj.KhoaID == -1)
                Model.Vlu_Khoas.Add(obj);
            PerformSubmitChanged(SaveDepartmentComplete);
        }

        public void DeleteDepartmentAsync(Vlu_Khoa obj)
        {
            Model.Vlu_Khoas.Remove(obj);
            PerformSubmitChanged(DeleteDepartmentComplete);
        }



        public void GetListClassAsync()
        {
            PerformQuery(Model.GetVlu_LopHocQuery(), GetListClassComplete, false);
        }

        public void GetClassAsync(int id, int handlerType)
        {
            if (id == -1)
            {
                Vlu_LopHoc obj = new Vlu_LopHoc();
                obj.LopID = id;
                obj.MaLop = string.Empty;
                obj.TenLop = string.Empty;
                obj.NgayTao = DateTime.Now;
                obj.NguoiTao = SystemConfig.UserName;                
                List<Vlu_LopHoc> lst = new List<Vlu_LopHoc>();
                lst.Add(obj);
                switch (handlerType)
                {
                    case 0: GetClassComplete(this, new EntityResultsArgs<Vlu_LopHoc>(lst.ToArray()));
                        break;
                    case 1: GetClassParentComplete(this, new EntityResultsArgs<Vlu_LopHoc>(lst.ToArray()));
                        break;
                }
            }
            else
            {
                var query = from c in Model.GetVlu_LopHocQuery()
                            where c.KhoaID == id
                            select c;
                switch (handlerType)
                {
                    case 0: PerformQuery(query, GetClassComplete, false);
                        break;
                    case 1: PerformQuery(query, GetClassParentComplete, false);
                        break;
                }
            }
        }

        public void GetClassByKeyAsync(int id, string keyName)
        {
            var query = from c in Model.GetVlu_LopHocQuery()
                        where c.MaLop == keyName && c.LopID != id
                        select c;
            PerformQuery(query, GetClassByKeyComplete, false);
        }

        public void SaveClassAsync(Vlu_LopHoc obj)
        {
            if (obj.LopID == -1)
                Model.Vlu_LopHocs.Add(obj);
            PerformSubmitChanged(SaveClassComplete);
        }

        public void DeleteClassAsync(Vlu_LopHoc obj)
        {
            Model.Vlu_LopHocs.Remove(obj);
            PerformSubmitChanged(DeleteClassComplete);
        }



        public void GetListSubjectAsync()
        {
            PerformQuery(Model.GetVlu_MonHocQuery(), GetListSubjectComplete, false);
        }

        public void GetSubjectAsync(int id)
        {
            if (id == -1)
            {
                Vlu_MonHoc obj = new Vlu_MonHoc();
                obj.MonHocID = id;
                obj.MaMonHoc = string.Empty;
                obj.TenMonHoc = string.Empty;
                obj.NgayTao = DateTime.Now;
                obj.NguoiTao = SystemConfig.UserName;
                List<Vlu_MonHoc> lst = new List<Vlu_MonHoc>();
                lst.Add(obj);
                GetSubjectComplete(this, new EntityResultsArgs<Vlu_MonHoc>(lst.ToArray()));
            }
            else
            {
                var query = from c in Model.GetVlu_MonHocQuery()
                            where c.MonHocID == id
                            select c;
                PerformQuery(query, GetSubjectComplete, false);
            }
        }

        public void GetSubjectByKeyAsync(int id, string keyName)
        {
            var query = from c in Model.GetVlu_MonHocQuery()
                        where c.MaMonHoc == keyName && c.MonHocID != id
                        select c;
            PerformQuery(query, GetSubjectByKeyComplete, false);
        }

        public void SaveSubjectAsync(Vlu_MonHoc obj)
        {
            if (obj.MonHocID == -1)
                Model.Vlu_MonHocs.Add(obj);
            PerformSubmitChanged(SaveSubjectComplete);
        }

        public void DeleteSubjectAsync(Vlu_MonHoc obj)
        {
            Model.Vlu_MonHocs.Remove(obj);
            PerformSubmitChanged(DeleteSubjectComplete);
        }



        public void GetListTrainingAsync()
        {
            ModelBusiness.GetListTraining(c =>
            {
                if (c.HasError)
                    GetListTrainingComplete(this, new ComplexResultsArgs<Training>(c.Error));
                else
                    GetListTrainingComplete(this, new ComplexResultsArgs<Training>(c.Value.ToArray()));
            }, null);
        }

        public void GetTrainingAsync(int id)
        {
            if (id == -1)
            {
                Vlu_ChuongTrinhDT obj = new Vlu_ChuongTrinhDT();
                obj.ID = id;
                obj.NamHoc = DateTime.Now.Year;
                obj.HocKy = 1;
                obj.KhoaID = -1;
                obj.LopID = -1;
                obj.MonHocID = -1;
                obj.NgayTao = DateTime.Now;
                obj.NguoiTao = SystemConfig.UserName;
                List<Vlu_ChuongTrinhDT> lst = new List<Vlu_ChuongTrinhDT>();
                lst.Add(obj);
                GetTrainingComplete(this, new EntityResultsArgs<Vlu_ChuongTrinhDT>(lst.ToArray()));
            }
            else
            {
                var query = from c in Model.GetVlu_MonHocQuery()
                            where c.MonHocID == id
                            select c;
                PerformQuery(query, GetSubjectComplete, false);
            }
        }

        public void SaveTrainingAsync(Vlu_ChuongTrinhDT obj)
        {
            if (obj.ID == -1)
                Model.Vlu_ChuongTrinhDTs.Add(obj);
            PerformSubmitChanged(SaveTrainingComplete);
        }

        public void DeleteTrainingAsync(Vlu_ChuongTrinhDT obj)
        {
            Model.Vlu_ChuongTrinhDTs.Remove(obj);
            PerformSubmitChanged(DeleteTrainingComplete);
        }
        #endregion
    }
}
