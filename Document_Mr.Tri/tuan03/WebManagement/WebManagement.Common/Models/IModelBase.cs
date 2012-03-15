using System;
using System.ComponentModel;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Security.Principal;
using WebManagement.Service;
using AuthenticationLib.AuthService;

namespace WebManagement.Common
{
    public interface IModelBase
    {
        void GetListAuthenticationMenuAsync();
        event EventHandler<ComplexResultsArgs<Authentication>> GetListAuthenticationMenuComplete;
        void GetListAuthenticationFormAsync(string keyName);
        event EventHandler<ComplexResultsArgs<Authentication>> GetListAuthenticationFormComplete;
        Boolean HasChanges { get; }
        Boolean IsBusy { get; }
    }
}
