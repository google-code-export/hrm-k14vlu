using System;
using System.ServiceModel.DomainServices.Client.ApplicationServices;

namespace WebManagement.Common
{
    public class LoadUserOperationEventArgs : ResultsArgs
    {
        public LoadUserOperationEventArgs(Exception ex)
            : base(ex)
        {
            LoginOp = null;
        }

        public LoadUserOperationEventArgs(LoadUserOperation loadUserOp)
            : base(null)
        {
            LoginOp = loadUserOp;
        }

        public LoadUserOperationEventArgs(LoadUserOperation loadUserOp, Exception ex)
            : base(ex)
        {
            LoginOp = loadUserOp;
        }

        public LoadUserOperation LoginOp { get; private set; }
    }
}
