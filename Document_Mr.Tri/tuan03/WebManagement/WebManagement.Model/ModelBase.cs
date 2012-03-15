using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel.DomainServices.Client;

using WebManagement.Common;
using WebManagement.Service;
using AuthenticationLib.AuthService;

namespace WebManagement.Model
{
    public class ModelBase : IModelBase
    {
        private static VanLangContext _model;
        public VanLangContext Model
        {
            get
            {

                if (_model == null)
                {
                    _model = new VanLangContext();
                    _model.PropertyChanged += new PropertyChangedEventHandler(_model_PropertyChanged);
                }
                return _model;
            }
        }

        private static BusinessContext _modelBusiness;
        public BusinessContext ModelBusiness
        {
            get
            {
                if (_modelBusiness == null)
                    _modelBusiness = new BusinessContext();
                return _modelBusiness;
            }
        }

        public void GetListAuthenticationMenuAsync()
        {
            ModelBusiness.GetListAuthenticationMenu(SystemConfig.UserID, string.Empty, c =>
            {
                if (c.HasError)
                    GetListAuthenticationMenuComplete(null, new ComplexResultsArgs<Authentication>(c.Error));
                else
                {
                    GetListAuthenticationMenuComplete(this, new ComplexResultsArgs<Authentication>(c.Value.ToArray()));
                }
            }, null);
        }
        public event EventHandler<ComplexResultsArgs<Authentication>> GetListAuthenticationMenuComplete;

        public void GetListAuthenticationFormAsync(string keyName)
        {
            ModelBusiness.GetListAuthenticationForm(SystemConfig.UserID, string.Empty, keyName, c =>
            {
                if (c.HasError)
                    GetListAuthenticationFormComplete(null, new ComplexResultsArgs<Authentication>(c.Error));
                else
                {
                    GetListAuthenticationFormComplete(this, new ComplexResultsArgs<Authentication>(c.Value.ToArray()));
                }
            }, null);
        }
        public event EventHandler<ComplexResultsArgs<Authentication>> GetListAuthenticationFormComplete;

        protected void PerformQuery<T>(EntityQuery<T> query, EventHandler<EntityResultsArgs<T>> handler, bool isBusiness) where T : Entity
        {

            if (isBusiness)
            {
                ModelBusiness.Load(query, LoadBehavior.RefreshCurrent, r =>
                {
                    if (handler != null)
                    {
                        try
                        {
                            if (r.HasError)
                            {
                                handler(this, new EntityResultsArgs<T>(r.Error));
                                r.MarkErrorAsHandled();
                            }
                            else
                            {
                                handler(this, new EntityResultsArgs<T>(r.Entities));
                            }
                        }
                        catch (Exception ex)
                        {
                            handler(this, new EntityResultsArgs<T>(ex));
                        }
                    }
                }, null);
            }
            else
            {
                Model.Load(query, LoadBehavior.RefreshCurrent, r =>
                {
                    if (handler != null)
                    {
                        try
                        {
                            if (r.HasError)
                            {
                                handler(this, new EntityResultsArgs<T>(r.Error));
                                r.MarkErrorAsHandled();
                                Model.RejectChanges();
                            }
                            else
                            {
                                handler(this, new EntityResultsArgs<T>(r.Entities));
                            }
                        }
                        catch (Exception ex)
                        {
                            handler(this, new EntityResultsArgs<T>(ex));
                        }
                    }
                }, null);
            }
        }

        protected void PerformSubmitChanged(EventHandler<SubmitOperationEventArgs> handler)
        {
            Model.SubmitChanges(s =>
            {
                if (handler != null)
                {
                    try
                    {
                        Exception ex = null;
                        if (s.HasError)
                        {
                            ex = s.Error;
                            s.MarkErrorAsHandled();
                            Model.RejectChanges();
                        }
                        handler(this, new SubmitOperationEventArgs(s, ex));
                    }
                    catch (Exception ex)
                    {
                        handler(this, new SubmitOperationEventArgs(ex));
                    }
                }
            }, null);
        }

        private Boolean _hasChanges;
        public Boolean HasChanges
        {
            get
            {
                return _hasChanges;
            }

            private set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged("HasChanges");
                }
            }
        }

        private Boolean _isBusy;
        public Boolean IsBusy
        {
            get
            {
                return _isBusy;
            }

            private set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged("IsBusy");
                }
            }
        }

        private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "HasChanges":
                    HasChanges = _model.HasChanges;
                    break;
                case "IsLoading":
                    IsBusy = _model.IsLoading;
                    break;
                case "IsSubmitting":
                    IsBusy = _model.IsSubmitting;
                    break;
            }
        }

        #region "INotifyPropertyChanged Interface implementation"
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
