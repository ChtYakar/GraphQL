using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Interfaces
{
    public interface IFieldServiceItem
    {
        void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp);
    }

    public interface IFieldMutationServiceItem : IFieldServiceItem
    {
    }

    public interface IFieldQueryServiceItem : IFieldServiceItem
    {
    }
    public interface IFieldSubscriptionServiceItem : IFieldServiceItem
    {

    }
}
