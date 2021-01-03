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
    public class MatchesQuery:IFieldQueryServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<ListGraphType<MatchesGType>>("matches",
               arguments: new QueryArguments(
                 new QueryArgument<IntGraphType> { Name = "id" },
                 new QueryArgument<IntGraphType> { Name = "homeTeamId" }
               ),
               resolve: context =>
               {
                   var matchesRepository = (IGenericRepository<Matches>)sp.GetService(typeof(IGenericRepository<Matches>));
                   var baseQuery = matchesRepository.GetAll();
                   var _id = context.GetArgument<int>("id");
                   var _homeTeamId = context.GetArgument<int>("homeTeamId");
                   if (_id > 0 )
                   {
                       baseQuery = baseQuery.Where(w => w.Id == _id );
                   }
                   if(_homeTeamId > 0)
                   {
                       baseQuery = baseQuery.Where(w => w.HomeTeamId == _homeTeamId);
                   }
                   return baseQuery.ToList();
               });
        }
    }
}
