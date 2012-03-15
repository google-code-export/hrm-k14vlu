using System;
using System.ComponentModel;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Security.Principal;
using WebManagement.Service;

namespace WebManagement.Common
{
    public interface ITrainingModel : IModelBase
    {
        void GetListRoomAsync();
        event EventHandler<EntityResultsArgs<Vlu_PhongHoc>> GetListRoomComplete;
        void GetRoomAsync(int id);
        event EventHandler<EntityResultsArgs<Vlu_PhongHoc>> GetRoomComplete;
        void GetRoomByKeyAsync(int id, string keyName);
        event EventHandler<EntityResultsArgs<Vlu_PhongHoc>> GetRoomByKeyComplete;
        void SaveRoomAsync(Vlu_PhongHoc obj);
        event EventHandler<SubmitOperationEventArgs> SaveRoomComplete;
        void DeleteRoomAsync(Vlu_PhongHoc obj);
        event EventHandler<SubmitOperationEventArgs> DeleteRoomComplete;

        void GetListDepartmentAsync();
        event EventHandler<EntityResultsArgs<Vlu_Khoa>> GetListDepartmentComplete;
        void GetDepartmentAsync(int id, int handlerType);
        event EventHandler<EntityResultsArgs<Vlu_Khoa>> GetDepartmentComplete;
        event EventHandler<EntityResultsArgs<Vlu_Khoa>> GetDepartmentParentComplete;
        void GetDepartmentByKeyAsync(int id, string keyName);
        event EventHandler<EntityResultsArgs<Vlu_Khoa>> GetDepartmentByKeyComplete;
        void SaveDepartmentAsync(Vlu_Khoa obj);
        event EventHandler<SubmitOperationEventArgs> SaveDepartmentComplete;
        void DeleteDepartmentAsync(Vlu_Khoa obj);
        event EventHandler<SubmitOperationEventArgs> DeleteDepartmentComplete;

        void GetListClassAsync();
        event EventHandler<EntityResultsArgs<Vlu_LopHoc>> GetListClassComplete;
        void GetClassAsync(int id, int handlerType);
        event EventHandler<EntityResultsArgs<Vlu_LopHoc>> GetClassComplete;
        event EventHandler<EntityResultsArgs<Vlu_LopHoc>> GetClassParentComplete;
        void GetClassByKeyAsync(int id, string keyName);
        event EventHandler<EntityResultsArgs<Vlu_LopHoc>> GetClassByKeyComplete;
        void SaveClassAsync(Vlu_LopHoc obj);
        event EventHandler<SubmitOperationEventArgs> SaveClassComplete;
        void DeleteClassAsync(Vlu_LopHoc obj);
        event EventHandler<SubmitOperationEventArgs> DeleteClassComplete;

        void GetListSubjectAsync();
        event EventHandler<EntityResultsArgs<Vlu_MonHoc>> GetListSubjectComplete;
        void GetSubjectAsync(int id);
        event EventHandler<EntityResultsArgs<Vlu_MonHoc>> GetSubjectComplete;
        void GetSubjectByKeyAsync(int id, string keyName);
        event EventHandler<EntityResultsArgs<Vlu_MonHoc>> GetSubjectByKeyComplete;
        void SaveSubjectAsync(Vlu_MonHoc obj);
        event EventHandler<SubmitOperationEventArgs> SaveSubjectComplete;
        void DeleteSubjectAsync(Vlu_MonHoc obj);
        event EventHandler<SubmitOperationEventArgs> DeleteSubjectComplete;

        void GetListTrainingAsync();
        event EventHandler<ComplexResultsArgs<Training>> GetListTrainingComplete;
        void GetTrainingAsync(int id);
        event EventHandler<EntityResultsArgs<Vlu_ChuongTrinhDT>> GetTrainingComplete;
        void SaveTrainingAsync(Vlu_ChuongTrinhDT obj);
        event EventHandler<SubmitOperationEventArgs> SaveTrainingComplete;
        void DeleteTrainingAsync(Vlu_ChuongTrinhDT obj);
        event EventHandler<SubmitOperationEventArgs> DeleteTrainingComplete;
    }
}
