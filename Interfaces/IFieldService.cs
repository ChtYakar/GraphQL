using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Interfaces
{
    public interface IFieldService
    {
        void ActivateFields(
            ObjectGraphType objectGraph,
            FieldServiceType fieldType,
            IWebHostEnvironment env,
            IServiceProvider provider);
        void RegisterFields();
    }

    public enum FieldServiceType
    {
        Query,
        Mutation,
        Subscription
    }
}
