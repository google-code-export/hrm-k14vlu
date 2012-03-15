using System;
using System.Collections.Generic;
using System.ServiceModel.DomainServices.Client;

namespace WebManagement.Common
{
    public class ComplexResultsArgs<T> : ResultsArgs
    {
        public ComplexResultsArgs(Exception ex)
            : base(ex)
        {
        }

        public ComplexResultsArgs(IEnumerable<T> results)
            : base(null)
        {
            Results = results;
        }

        public IEnumerable<T> Results { get; private set; }
    }
}
