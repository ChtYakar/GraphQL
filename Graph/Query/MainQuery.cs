using GraphQL.Types;
using GraphQL_Nsn.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Graph.Query
{
    public class MainQuery : ObjectGraphType
    {
        public MainQuery(IServiceProvider provider, IWebHostEnvironment env, IFieldService fieldService)
        {
            Name = "MainQuery";
            fieldService.ActivateFields(this, FieldServiceType.Query, env, provider);
        }
    }
}
