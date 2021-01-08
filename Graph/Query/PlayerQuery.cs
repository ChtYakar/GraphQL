using GraphQL.Types;
using GraphQL_Nsn.Graph.Type;
using GraphQL_Nsn.Interfaces;
using GraphQL_Nsn.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Graph.Query
{
    public class PlayerQuery : IFieldQueryServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<ListGraphType<PlayerGType>>("players",
               arguments: new QueryArguments(
                 new QueryArgument<IntGraphType> { Name = "id" }
               ),
               resolve: context =>
                    {
                        var playerRepo = (IGenericRepository<Player>)sp.GetService(typeof(IGenericRepository<Player>));
                        var baseQuery = playerRepo.GetAll();
                        var _id = context.GetArgument<int>("id");
                        if (_id > 0)
                        {
                            return baseQuery = baseQuery.Where(x => x.Id == _id);
                        }
                        return baseQuery.ToList();
                    });

        }
    }
}
