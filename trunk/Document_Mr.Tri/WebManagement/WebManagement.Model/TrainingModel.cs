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
        public event EventHandler<SubmitOperationEventArgs> ImportClassComplete;

        public event EventHandler<EntityResultsArgs<Vlu_MonHoc>> GetListSubjectComplete;
        public event EventHandler<EntityResultsArgs<Vlu_MonHoc>> GetSubjectComplete;
        public event EventHandler<EntityResultsArgs<Vlu_MonHoc>> GetSubjectByKeyComplete;
        public event EventHandler<SubmitOperationEventArgs> SaveSubjectComplete;
        public event EventHandler<SubmitOperationEventArgs> DeleteSubjectComplete;
        public event EventHandler<SubmitOperationEventArgs> ImportSubjectComplete;

        public event EventHandler<ComplexResultsArgs<ImportTraining>> GetListTrainingComplete;
        public event EventHandler<EntityResultsArgs<Vlu_ChuongTrinhDT>> GetTrainingComplete;
        public event EventHandler<SubmitOperationEventArgs> SaveTrainingComplete;
        public event EventHandler<InvokeOperationEventArgs> DeleteTrainingComplete;
        public event EventHandler<InvokeOperationEventArgs> ImportTrainingComplete;

        public event EventHandler<EntityResultsArgs<Vlu_DeCuongMonHoc>> GetListSubjectSummaryComplete;
        public event EventHandler<EntityResultsArgs<Vlu_DeCuongMonHoc>> GetSubjectSummaryComplete;
        public event EventHandler<SubmitOperationEventArgs> SaveSubjectSummaryComplete;
        public event EventHandler<SubmitOperationEventArgs> DeleteSubjectSummaryComplete;
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
                obj.CoSo = -1;
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
                            where c.LopID == id
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

        public void ImportClassAsync(List<Vlu_LopHoc> lstData, List<CustomizeClass> lstImport)
        {
            foreach (var item in lstImport)
            {
                Vlu_LopHoc obj = lstData.FirstOrDefault(c => c.MaLop == item.MaLop);
                if (obj == null)
                {
                    obj = new Vlu_LopHoc();
                    obj.LopID = -1;
                    obj.NgayTao = DateTime.Now;
                    obj.NguoiTao = SystemConfig.UserName;
                }
                else
                {
                    obj.NgayCapNhat = DateTime.Now;
                    obj.NguoiCapNhat = SystemConfig.UserName;
                }
                obj.MaLop = item.MaLop;
                obj.TenLop = item.TenLop;
                obj.ParentID = item.ParentID;
                obj.KhoaID = item.KhoaID;
                if (obj.LopID == -1)
                    Model.Vlu_LopHocs.Add(obj);
            }
            PerformSubmitChanged(ImportClassComplete);
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

        public void ImportSubjectAsync(List<Vlu_MonHoc> lstData, List<Vlu_MonHoc> lstImport)
        {
            foreach (var item in lstImport)
            {
                Vlu_MonHoc obj = lstData.FirstOrDefault(c => c.MaMonHoc == item.MaMonHoc);
                if (obj == null)
                {
                    obj = new Vlu_MonHoc();
                    obj.MonHocID = -1;
                    obj.NgayTao = DateTime.Now;
                    obj.NguoiTao = SystemConfig.UserName;
                    obj.TinhTrang = 0;
                    obj.Duyet = true;
                }
                else
                {
                    obj.NgayCapNhat = DateTime.Now;
                    obj.NguoiCapNhat = SystemConfig.UserName;
                }
                obj.MaMonHoc = item.MaMonHoc;
                obj.TenMonHoc = item.TenMonHoc;
                obj.DVHT = item.DVHT;
                obj.TS = item.TS;
                obj.LT = item.LT;
                obj.BT = item.BT;
                obj.TH = item.TH;
                obj.BTL = item.BTL;
                obj.DA = item.DA;
                obj.LA = item.LA;
                obj.ThuocNhom = item.ThuocNhom;
                if (obj.MonHocID == -1)
                    Model.Vlu_MonHocs.Add(obj);
            }
            PerformSubmitChanged(ImportSubjectComplete);
        }


        public void GetListTrainingAsync()
        {
            ModelBusiness.GetListTraining(c =>
            {
                if (c.HasError)
                    GetListTrainingComplete(this, new ComplexResultsArgs<ImportTraining>(c.Error));
                else
                    GetListTrainingComplete(this, new ComplexResultsArgs<ImportTraining>(c.Value.ToArray()));
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
                var query = from c in Model.GetVlu_ChuongTrinhDTQuery()
                            where c.ID == id
                            select c;
                PerformQuery(query, GetTrainingComplete, false);
            }
        }

        public void SaveTrainingAsync(Vlu_ChuongTrinhDT obj)
        {
            if (obj.ID == -1)
                Model.Vlu_ChuongTrinhDTs.Add(obj);
            PerformSubmitChanged(SaveTrainingComplete);
        }

        public void DeleteTrainingAsync(ImportTraining obj)
        {
            ModelBusiness.DeleteTraining(obj, c =>
                {
                    if (DeleteTrainingComplete != null)
                        DeleteTrainingComplete(null, new InvokeOperationEventArgs(c));
                }, null);
        }

        public void ImportTrainingAsync(List<ImportTraining> lstData, List<ImportTraining> lstImport)
        {
            List<ImportTraining> lst = lstImport.Where(c => !lstData.Any(d => d.NamHoc == c.NamHoc && 
                d.HocKy != c.HocKy && d.KhoaID == c.KhoaID && d.LopID == d.LopID && d.MonHocID == c.MonHocID)).ToList();
            ModelBusiness.ImportListTraining(lst, c =>
                {
                    if (ImportTrainingComplete != null)
                        ImportTrainingComplete(this, new InvokeOperationEventArgs(c));
                }, null);
        }



        public void GetListSubjectSummaryAsync()
        {
            PerformQuery(Model.GetVlu_DeCuongMonHocQuery(), GetListSubjectSummaryComplete, false);
        }

        public void GetSubjectSummaryAsync(int id)
        {
            if (id == -1)
            {
                Vlu_DeCuongMonHoc obj = new Vlu_DeCuongMonHoc();
                obj.ID = -1;
                obj.NamHoc = -1;
                obj.HocKy = -1;
                obj.MonHocID = -1;
                obj.NoiDung = string.Empty;
                obj.Duyet = false;
                obj.NgayTao = DateTime.Now;
                obj.NguoiTao = SystemConfig.UserName;                
                List<Vlu_DeCuongMonHoc> lst = new List<Vlu_DeCuongMonHoc>();
                lst.Add(obj);
                if (GetSubjectSummaryComplete != null)
                    GetSubjectSummaryComplete(this, new EntityResultsArgs<Vlu_DeCuongMonHoc>(lst.ToArray()));
            }
            else
            {
                var query = from c in Model.GetVlu_DeCuongMonHocQuery()
                            where c.ID == id
                            select c;
                PerformQuery(query, GetSubjectSummaryComplete, false);
            }
        }

        public void SaveSubjectSummaryAsync(Vlu_DeCuongMonHoc obj)
        {
            if (obj.ID == -1)
                Model.Vlu_DeCuongMonHocs.Add(obj);
            PerformSubmitChanged(SaveSubjectSummaryComplete);
        }

        public void DeleteSubjectSummaryAsync(Vlu_DeCuongMonHoc obj)
        {
            Model.Vlu_DeCuongMonHocs.Remove(obj);
            PerformSubmitChanged(DeleteSubjectSummaryComplete);
        }
        #endregion


        
    }
}
