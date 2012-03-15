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
    [Export(typeof(ISettingModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SettingModel : ModelBase, ISettingModel
    {
        #region Events
        public event EventHandler<EntityResultsArgs<Vlu_UserSettings>> GetListSettingComplete;
        public event EventHandler<SubmitOperationEventArgs> SaveListSettingComplete;
        #endregion

        #region Public Methods
        public void GetListSettingAsync()
        {
            var query = from c in Model.GetVlu_UserSettingsQuery()
                        where c.TaiKhoanID == SystemConfig.UserID
                        select c;
            PerformQuery(query, GetListSettingComplete, false);
        }

        public void SaveListSettingAsync(List<Vlu_UserSettings> lst)
        {
            foreach (var item in lst)
            {
                if (item.ID == -1)
                {
                    item.TaiKhoanID = SystemConfig.UserID;
                    Model.Vlu_UserSettings.Add(item);
                }
            }
            PerformSubmitChanged(SaveListSettingComplete);
        }
        #endregion
    }
}
