using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel.DomainServices.Client;

namespace WebManagement.Common
{
    public class SubmitOperationEventArgs : ResultsArgs
    {
        public SubmitOperationEventArgs(Exception ex)
            : base(ex)
        {
            SubmitOp = null;
        }

        public SubmitOperationEventArgs(SubmitOperation submitOp)
            : base(null)
        {
            SubmitOp = submitOp;
        }

        public SubmitOperationEventArgs(SubmitOperation submitOp, Exception ex)
            : base(ex)
        {
            SubmitOp = submitOp;
        }

        public SubmitOperation SubmitOp { get; private set; }
    }
}
