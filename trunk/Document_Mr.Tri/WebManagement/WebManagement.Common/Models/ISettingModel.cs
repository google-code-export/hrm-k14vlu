using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Security.Principal;
using WebManagement.Service;

namespace WebManagement.Common
{
    public interface ISettingModel : IModelBase
    {
        void GetListSettingAsync();
        event EventHandler<EntityResultsArgs<Vlu_UserSettings>> GetListSettingComplete;

        void SaveListSettingAsync(List<Vlu_UserSettings> lst);
        event EventHandler<SubmitOperationEventArgs> SaveListSettingComplete;
    }
}
